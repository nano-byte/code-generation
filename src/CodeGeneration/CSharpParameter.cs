// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// A parameter for a <see cref="CSharpConstructor"/>.
    /// </summary>
    public class CSharpParameter
    {
        /// <summary>
        /// The type of the parameter.
        /// </summary>
        public CSharpIdentifier Type { get; }

        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The value to set for this parameter when invoking it. Passes through a argument of the same name when not set.
        /// </summary>
        public object? Value { get; set; }

        /// <summary>
        /// Indicates whether a literal (compile-time constant) value is set.
        /// </summary>
        internal bool HasLiteralValue
            => Value != null && !(Value is ThisReference);

        /// <summary>
        /// Creates a new constructor parameter.
        /// </summary>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="name">The name of the parameter.</param>
        public CSharpParameter(CSharpIdentifier type, string name)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Returns a Roslyn syntax for declaring the parameter.
        /// </summary>
        internal ParameterSyntax ToParameterSyntax()
            => Parameter(Identifier(Name)).WithType(Type.ToSyntax());

        /// <summary>
        /// Returns a Roslyn syntax for setting a value for the parameter.
        /// </summary>
        internal ArgumentSyntax ToArgumentSyntax()
            => HasLiteralValue
            ? Argument(Value!.ToLiteralSyntax()).WithNameColon(NameColon(IdentifierName(Name)))
            : Argument(IdentifierName(Name));

        /// <summary>
        /// Returns the type, name and value of the parameter.
        /// </summary>
        public override string ToString()
            => Value == null
                ? Type + " " + Name
                : Type + " " + Name + " = " + Value;
    }
}
