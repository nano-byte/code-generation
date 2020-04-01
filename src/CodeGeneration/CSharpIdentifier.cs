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
    /// The fully qualified name of a type.
    /// </summary>
    public partial class CSharpIdentifier
    {
        /// <summary>
        /// The namespace containing the type.
        /// </summary>
        public string? Namespace { get; }

        /// <summary>
        /// The name of the type.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Indicates whether the type can have the value <c>null</c>.
        /// </summary>
        public bool Nullable { get; }

        /// <summary>
        /// Creates a new identifier for a built-in type.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="nullable">Indicates whether the type can have the value <c>null</c>.</param>
        private CSharpIdentifier(string name, bool nullable = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Nullable = nullable;
        }

        /// <summary>
        /// Creates a new identifier.
        /// </summary>
        /// <param name="ns">The namespace containing the type.</param>
        /// <param name="name">The name of the type.</param>
        /// <param name="nullable">Indicates whether the type can have the value <c>null</c>.</param>
        public CSharpIdentifier(string? ns, string name, bool nullable = false)
            : this(name, nullable)
        {
            Namespace = ns;
        }

        /// <summary>
        /// Generic type arguments for the type.
        /// </summary>
        public List<CSharpIdentifier> TypeArguments { get; } = new List<CSharpIdentifier>();

        /// <summary>
        /// Returns a list of all namespaces referenced/used in this identifier.
        /// </summary>
        internal IEnumerable<string> GetNamespaces()
        {
            if (!string.IsNullOrEmpty(Namespace))
                yield return Namespace;

            foreach (string ns in TypeArguments.SelectMany(x => x.GetNamespaces()))
                yield return ns;
        }

        /// <summary>
        /// Returns a Roslyn syntax for the type identifier.
        /// </summary>
        internal TypeSyntax ToSyntax()
        {
            var type = GetPredefinedType(Name) ?? IdentifierName(Name);

            if (TypeArguments.Count != 0)
                type = GenericName(Identifier(Name)).WithTypeArgumentList(TypeArgumentList(SeparatedList(TypeArguments.Select(x => x.ToSyntax()))));

            return Nullable ? NullableType(type) : type;
        }

        /// <summary>
        /// Returns a copy of the identifier with <see cref="Nullable"/> set to <c>true</c>.
        /// </summary>
        public CSharpIdentifier ToNullable()
            => new CSharpIdentifier(Namespace, Name, nullable: true);

        /// <summary>
        /// Returns a copy of the identifier with an <c>I</c> prepended to the <see cref="Name"/>.
        /// </summary>
        public CSharpIdentifier ToInterface()
        {
            var result = new CSharpIdentifier(Namespace, "I" + Name);
            result.TypeArguments.AddRange(TypeArguments);
            return result;
        }

        /// <summary>
        /// Returns the name of the type with potential type arguments.
        /// </summary>
        public override string ToString()
            => TypeArguments.Count == 0
                ? Name
                : Name + "<" + string.Join(", ", TypeArguments) + ">";
    }
}
