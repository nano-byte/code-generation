// Copyright Bastian Eicher
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public class CSharpInterface : CSharpType
    {
        public CSharpInterface(CSharpIdentifier identifier)
            : base(identifier)
        {}

        public List<CSharpIdentifier> Interfaces { get; } = new List<CSharpIdentifier>();

        public List<CSharpProperty> Properties { get; } = new List<CSharpProperty>();

        protected override MemberDeclarationSyntax GetMemberDeclaration()
        {
            var declaration = GetTypeDeclaration().WithMembers(List(GetMemberDeclarations()));

            var baseTypes = GetBaseTypes().ToList();
            return baseTypes.Any()
                ? declaration.WithBaseList(BaseList(SeparatedList(baseTypes)))
                : declaration;
        }

        protected virtual TypeDeclarationSyntax GetTypeDeclaration()
            => InterfaceDeclaration(Identifier.Name);

        protected override ISet<string> GetNamespaces()
        {
            var namespaces = base.GetNamespaces();

            foreach (string ns in Interfaces.SelectMany(x => x.GetNamespaces()))
                namespaces.Add(ns);

            foreach (string ns in Properties.SelectMany(x => x.GetNamespaces()))
                namespaces.Add(ns);

            return namespaces;
        }

        protected virtual IEnumerable<BaseTypeSyntax> GetBaseTypes()
            => Interfaces.Select(x => SimpleBaseType(x.ToSyntax()));

        protected virtual IEnumerable<MemberDeclarationSyntax> GetMemberDeclarations()
            => Properties.Select(property => property.ToSyntax());
    }
}
