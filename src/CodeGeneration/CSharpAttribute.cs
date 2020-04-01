// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public class CSharpAttribute
    {
        public CSharpIdentifier Identifier { get; }

        public CSharpAttribute(CSharpIdentifier identifier)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }

        public List<string> Arguments { get; } = new List<string>();

        public AttributeListSyntax ToSyntax()
        {
            var attribute = Attribute(IdentifierName(Identifier.Name));

            if (Arguments.Count != 0)
            {
                attribute = attribute
                   .WithArgumentList(AttributeArgumentList(SeparatedList(Arguments.Select(value =>
                        AttributeArgument(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value)))))));
            }

            return AttributeList(SingletonSeparatedList(attribute));
        }
    }
}
