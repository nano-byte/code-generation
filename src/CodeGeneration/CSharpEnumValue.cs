// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// A possible value for a <see cref="CSharpEnum"/>.
    /// </summary>
    public class CSharpEnumValue
    {
        /// <summary>
        /// The name of the enum value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates a new enum value.
        /// </summary>
        /// <param name="name">The name of the enum value.</param>
        public CSharpEnumValue(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// A summary used for an XML documentation comment.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Attributes to apply to the enum value.
        /// </summary>
        public List<CSharpAttribute> Attributes { get; } = new();

        /// <summary>
        /// Returns a list of all namespaces referenced/used in this enum value.
        /// </summary>
        internal IEnumerable<string> GetNamespaces()
        {
            foreach (var attribute in Attributes)
            {
                if (attribute.Identifier.Namespace != null)
                    yield return attribute.Identifier.Namespace;
            }
        }

        /// <summary>
        /// Returns a Roslyn syntax for the enum value.
        /// </summary>
        internal EnumMemberDeclarationSyntax ToSyntax()
            => EnumMemberDeclaration(Identifier(Name))
              .WithAttributeLists(List(Attributes.Select(x => x.ToSyntax())))
              .WithDocumentation(Summary);

        /// <summary>
        /// Returns the name of the enum value.
        /// </summary>
        public override string ToString()
            => Name;
    }
}
