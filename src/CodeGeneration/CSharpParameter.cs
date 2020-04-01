// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
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

        public ParameterSyntax ToParameterSyntax()
            => Parameter(Identifier(Name)).WithType(Type.ToSyntax());

        public ArgumentSyntax ToArgumentSyntax()
        {
            var literal = Value switch
            {
                bool value => LiteralExpression(value ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression),
                int value => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)),
                long value => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)),
                float value => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)),
                double value => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)),
                string value => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value)),
                _ => null
            };
            return literal switch
            {
                null => Argument(IdentifierName(Name)),
                _ => Argument(literal).WithNameColon(NameColon(IdentifierName(Name)))
            };
        }

        public override string ToString()
            => Value == null
                ? Type + " " + Name
                : Type + " " + Name + " = " + Value;
    }
}
