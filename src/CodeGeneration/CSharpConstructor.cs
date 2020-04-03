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
    /// <summary>
    /// A constructor for a <see cref="CSharpClass"/>.
    /// </summary>
    public class CSharpConstructor
    {
        /// <summary>
        /// The fully qualified name of the class that the constructor instantiates.
        /// </summary>
        public CSharpIdentifier Type { get; }

        /// <summary>
        /// Creates a new constructor.
        /// </summary>
        /// <param name="type">The fully qualified name of the class that the constructor instantiates.</param>
        public CSharpConstructor(CSharpIdentifier type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// The parameters for the constructor.
        /// </summary>
        public List<CSharpParameter> Parameters { get; } = new List<CSharpParameter>();

        /// <summary>
        /// Returns a list of all namespaces referenced/used in this constructor.
        /// </summary>
        internal IEnumerable<string> GetNamespaces()
        {
            foreach (string ns in Type.GetNamespaces())
                yield return ns;

            foreach (string ns in Parameters.SelectMany(x => x.Type.GetNamespaces()))
                yield return ns;
        }

        /// <summary>
        /// Returns a Roslyn syntax for invoking the constructor (<c>new</c>).
        /// </summary>
        internal ObjectCreationExpressionSyntax ToInvocationSyntax()
            => ObjectCreationExpression(Type.ToSyntax())
               .WithArgumentList(GetArgumentList(thisKeyword: true));

        /// <summary>
        /// Returns a Roslyn syntax for declaring the constructor.
        /// </summary>
        internal ConstructorDeclarationSyntax ToDeclarationSyntax(string typeName)
            => ConstructorDeclaration(Identifier(typeName))
              .AddModifiers(Token(SyntaxKind.PublicKeyword))
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
                Parameters.Where(x => !x.HasLiteralValue)
                          .Select(x => x.ToParameterSyntax())));

        /// <summary>
        /// Returns the name of the class that the constructor instantiates.
        /// </summary>
        public override string ToString()
            => Type.ToString();
    }
}
