// Copyright Bastian Eicher
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// Describes a C# enum for which code can be generated.
    /// </summary>
    public class CSharpEnum : CSharpType
    {
        /// <summary>
        /// Creates a new C# enum.
        /// </summary>
        /// <param name="identifier">The fully qualified name of the enum.</param>
        public CSharpEnum(CSharpIdentifier identifier)
            : base(identifier)
        {}

        /// <summary>
        /// A list of possible values for the enum.
        /// </summary>
        public List<CSharpEnumValue> Values { get; } = new List<CSharpEnumValue>();

        /// <inheritdoc/>
        protected override MemberDeclarationSyntax GetMemberDeclaration()
            => EnumDeclaration(Identifier.Name)
               .WithMembers(SeparatedList(Values.Select(value => value.ToSyntax())));
    }
}
