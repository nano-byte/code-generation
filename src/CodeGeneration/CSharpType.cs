// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// Describes a C# type for which code can be generated.
    /// </summary>
    public abstract class CSharpType : ICSharpType
    {
        /// <inheritdoc/>
        public CSharpIdentifier Identifier { get; }

        /// <summary>
        /// Creates a new C# type.
        /// </summary>
        /// <param name="identifier">The fully qualified name of the type.</param>
        protected CSharpType(CSharpIdentifier identifier)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }

        /// <inheritdoc/>
        public string? Summary { get; set; }

        /// <inheritdoc/>
        public List<CSharpAttribute> Attributes { get; } = new();

        /// <inheritdoc/>
        public CompilationUnitSyntax ToSyntax()
        {
            var namespaces = GetNamespaces();
            if (!string.IsNullOrEmpty(Identifier.Namespace))
                namespaces.Remove(Identifier.Namespace);

            var member = GetMemberDeclaration()
                        .WithAttributeLists(List(Attributes.Select(x => x.ToSyntax())))
                        .WithDocumentation(Summary);

            return CompilationUnit()
                  .WithUsings(List(namespaces.Select(x => UsingDirective(IdentifierName(x)))))
                  .AddMembers((Identifier.Namespace == null) ? member : NamespaceDeclaration(IdentifierName(Identifier.Namespace)).AddMembers(member))
                  .NormalizeWhitespace();
        }

        /// <summary>
        /// Returns a list of all namespaces referenced/used in this type.
        /// </summary>
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

        /// <summary>
        /// Returns a Roslyn syntax for the type.
        /// </summary>
        protected abstract MemberDeclarationSyntax GetMemberDeclaration();

        /// <summary>
        /// Returns the name of the type.
        /// </summary>
        public override string ToString()
            => Identifier.ToString();
    }
}
