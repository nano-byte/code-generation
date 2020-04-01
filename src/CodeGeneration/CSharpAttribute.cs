// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<object> Arguments { get; } = new List<object>();

        public List<(string name, object value)> NamedArguments { get; } = new List<(string name, object value)>();

        internal AttributeListSyntax ToSyntax()
        {
            var attribute = Attribute(IdentifierName(TrimAttributeSuffix(Identifier.Name)));

            var arguments = GetArguments().ToList();
            if (arguments.Count != 0)
                attribute = attribute.WithArgumentList(AttributeArgumentList(SeparatedList(arguments)));

            return AttributeList(SingletonSeparatedList(attribute));
        }

        private IEnumerable<AttributeArgumentSyntax> GetArguments()
        {
            foreach (var value in Arguments)
                yield return AttributeArgument(value.ToLiteralSyntax());

            foreach ((string name, var value) in NamedArguments)
                yield return AttributeArgument(value.ToLiteralSyntax()).WithNameEquals(NameEquals(name));
        }

        private static string TrimAttributeSuffix(string name)
            => name.EndsWith("Attribute")
                ? name.Remove(name.Length - "Attribute".Length)
                : name;
    }
}
