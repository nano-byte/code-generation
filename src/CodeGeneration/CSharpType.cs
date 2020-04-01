// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public abstract class CSharpType : ICSharpType
    {
        public CSharpIdentifier Identifier { get; }

        protected CSharpType(CSharpIdentifier identifier)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }

        public string? Description { get; set; }

        public List<CSharpAttribute> Attributes { get; } = new List<CSharpAttribute>();

        public CompilationUnitSyntax ToSyntax()
        {
            var namespaces = GetNamespaces();
            if (!string.IsNullOrEmpty(Identifier.Namespace))
                namespaces.Remove(Identifier.Namespace);

            var member = GetMemberDeclaration()
                        .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword))
                        .WithAttributeLists(List(Attributes.Select(x => x.ToSyntax())))
                        .WithDocumentation(Description);

            return CompilationUnit()
                  .WithUsings(List(namespaces.Select(x => UsingDirective(IdentifierName(x)))))
                  .AddMembers(NamespaceDeclaration(IdentifierName(Identifier.Namespace)).AddMembers(member))
                  .NormalizeWhitespace();
        }

        protected virtual ISet<string> GetNamespaces()
        {
            var namespaces = new SortedSet<string>();

            foreach (string? ns in Attributes.Select(x => x.Identifier.Namespace))
            {
                if (ns != null)
                    namespaces.Add(ns);
            }

            return namespaces;
        }

        protected abstract MemberDeclarationSyntax GetMemberDeclaration();

        public override string ToString() => Identifier.ToString();
    }
}
