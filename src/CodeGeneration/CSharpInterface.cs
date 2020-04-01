﻿// Copyright Bastian Eicher
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// Describes a C# interface for which code can be generated.
    /// </summary>
    public class CSharpInterface : CSharpType
    {
        /// <summary>
        /// Creates a new C# interface.
        /// </summary>
        /// <param name="identifier">The fully qualified name of the interface.</param>
        public CSharpInterface(CSharpIdentifier identifier)
            : base(identifier)
        {}

        /// <summary>
        /// A list of interfaces this type implements.
        /// </summary>
        public List<CSharpIdentifier> Interfaces { get; } = new List<CSharpIdentifier>();

        /// <summary>
        /// A list of properties this type exposes.
        /// </summary>
        public List<CSharpProperty> Properties { get; } = new List<CSharpProperty>();

        /// <inheritdoc/>
        protected override MemberDeclarationSyntax GetMemberDeclaration()
        {
            var declaration = GetTypeDeclaration().WithMembers(List(GetMemberDeclarations()));

            var baseTypes = GetBaseTypes().ToList();
            return baseTypes.Any()
                ? declaration.WithBaseList(BaseList(SeparatedList(baseTypes)))
                : declaration;
        }

        /// <summary>
        /// Returns a Roslyn syntax for the type.
        /// </summary>
        protected virtual TypeDeclarationSyntax GetTypeDeclaration()
            => InterfaceDeclaration(Identifier.Name);

        /// <inheritdoc/>
        protected override ISet<string> GetNamespaces()
        {
            var namespaces = base.GetNamespaces();

            foreach (string ns in Interfaces.SelectMany(x => x.GetNamespaces()))
                namespaces.Add(ns);

            foreach (string ns in Properties.SelectMany(x => x.GetNamespaces()))
                namespaces.Add(ns);

            return namespaces;
        }

        /// <summary>
        /// Returns a list of Roslyn syntax for references to base types of this type.
        /// </summary>
        protected virtual IEnumerable<BaseTypeSyntax> GetBaseTypes()
            => Interfaces.Select(x => SimpleBaseType(x.ToSyntax()));

        /// <summary>
        /// Returns a list of Roslyn syntax for members of this type.
        /// </summary>
        protected virtual IEnumerable<MemberDeclarationSyntax> GetMemberDeclarations()
            => Properties.Select(property => property.ToSyntax());
    }
}
