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
        public CSharpIdentifier Type { get; }

        public string Name { get; }

        public object? Value { get; set; }

        public bool HasStaticValue
            => Value != null && !(Value is ThisReference);

        public CSharpParameter(CSharpIdentifier type, string name)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        internal ParameterSyntax ToParameterSyntax()
            => Parameter(Identifier(Name)).WithType(Type.ToSyntax());

        internal ArgumentSyntax ToArgumentSyntax()
        {
            var literal = Value.ToLiteralSyntax();
            return (literal == null)
                ? Argument(IdentifierName(Name))
                : Argument(literal).WithNameColon(NameColon(IdentifierName(Name)));
        }

        public override string ToString()
            => Value == null
                ? Type + " " + Name
                : Type + " " + Name + " = " + Value;
    }
}
