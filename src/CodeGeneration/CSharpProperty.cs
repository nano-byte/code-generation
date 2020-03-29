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
    public class CSharpProperty
    {
        public CSharpIdentifier Type { get; }

        public string Name { get; }

        public string? Description { get; set; }

        public List<CSharpAttribute> Attributes { get; } = new List<CSharpAttribute>();

        public CSharpProperty(CSharpIdentifier type, string name)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public CSharpConstructor? GetterExpression { get; set; }

        public bool HasSetter { get; set; }

        public IEnumerable<string> GetNamespaces()
        {
            foreach (string? ns in Attributes.Select(x => x.Identifier.Namespace))
            {
                if (ns != null)
                    yield return ns;
            }

            foreach (string ns in Type.GetNamespaces())
                yield return ns;

            if (GetterExpression != null)
            {
                foreach (string ns in GetterExpression.GetNamespaces())
                    yield return ns;
            }
        }

        public PropertyDeclarationSyntax ToSyntax()
        {
            var propertyDeclaration =
                PropertyDeclaration(Type.ToSyntax(), Identifier(Name))
                   .WithAttributeLists(List(Attributes.Select(x => x.ToSyntax())))
                   .WithDocumentation(Description);

            return (GetterExpression == null)
                ? propertyDeclaration.WithAccessorList(AccessorList(List(GetAccessors())))
                : propertyDeclaration.WithExpressionBody(ArrowExpressionClause(GetterExpression.ToInvocationSyntax()))
                                     .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }

        private IEnumerable<AccessorDeclarationSyntax> GetAccessors()
        {
            AccessorDeclarationSyntax Declaration(SyntaxKind kind) => AccessorDeclaration(kind).WithSemicolonToken(Token(SyntaxKind.SemicolonToken));

            yield return Declaration(SyntaxKind.GetAccessorDeclaration);
            if (HasSetter) yield return Declaration(SyntaxKind.SetAccessorDeclaration);
        }

        public override string ToString() => Name;
    }
}
