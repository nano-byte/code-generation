using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public class CSharpClass : CSharpInterface
    {
        public CSharpClass(CSharpIdentifier identifier)
            : base(identifier)
        {}

        public CSharpClassConstruction? BaseClass { get; set; }

        public CSharpClassConstruction GetConstruction()
        {
            var result = new CSharpClassConstruction(Identifier);
            if (BaseClass != null)
                result.Parameters.AddRange(BaseClass.Parameters.Where(x => !x.HasStaticValue));
            return result;
        }

        protected override ISet<string> GetNamespaces()
        {
            var namespaces = base.GetNamespaces();

            if (BaseClass != null)
            {
                foreach (string ns in BaseClass.GetNamespaces())
                    namespaces.Add(ns);
            }

            return namespaces;
        }

        protected override TypeDeclarationSyntax GetTypeDeclaration()
            => ClassDeclaration(Identifier.Name);

        protected override IEnumerable<BaseTypeSyntax> GetBaseTypes()
        {
            if (BaseClass != null)
                yield return SimpleBaseType(BaseClass.Type.ToSyntax());

            foreach (var type in base.GetBaseTypes())
                yield return type;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetMemberDeclarations()
        {
            if (BaseClass != null && BaseClass.Parameters.Count != 0)
                yield return BaseClass.ToConstructorSyntax(Identifier.Name);

            foreach (var member in base.GetMemberDeclarations())
                yield return member.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));
        }
    }
}
