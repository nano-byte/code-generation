// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public class CSharpConstructor
    {
        public CSharpIdentifier Type { get; }

        public CSharpConstructor(CSharpIdentifier type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public List<CSharpParameter> Parameters { get; } = new List<CSharpParameter>();

        internal IEnumerable<string> GetNamespaces()
        {
            foreach (string ns in Type.GetNamespaces())
                yield return ns;

            foreach (string ns in Parameters.SelectMany(x => x.Type.GetNamespaces()))
                yield return ns;
        }

        internal ObjectCreationExpressionSyntax ToInvocationSyntax()
            => ObjectCreationExpression(Type.ToSyntax())
               .WithArgumentList(GetArgumentList(thisKeyword: true));

        internal ConstructorDeclarationSyntax ToDeclarationSyntax(string typeName)
            => ConstructorDeclaration(Identifier(typeName))
              .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
              .WithParameterList(GetParameterList())
              .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, GetArgumentList(thisKeyword: false)))
              .WithBody(Block());

        private ArgumentListSyntax GetArgumentList(bool thisKeyword)
            => ArgumentList(SeparatedList(
                Parameters.Select(x => thisKeyword && x.Value is ThisReference
                    ? Argument(ThisExpression())
                    : x.ToArgumentSyntax())));

        private ParameterListSyntax GetParameterList()
            => ParameterList(SeparatedList(
                Parameters.Where(x => !x.HasStaticValue)
                          .Select(x => x.ToParameterSyntax())));

        public override string ToString() => Type.ToString();
    }
}
