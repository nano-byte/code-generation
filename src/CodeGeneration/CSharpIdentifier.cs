// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public partial class CSharpIdentifier
    {
        public string? Namespace { get; }

        public string Name { get; }

        public bool Nullable { get; }

        private CSharpIdentifier(string name, bool nullable = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Nullable = nullable;
        }

        public CSharpIdentifier(string? ns, string name, bool nullable = false)
            : this(name, nullable)
        {
            Namespace = ns;
        }

        public List<CSharpIdentifier> TypeArguments { get; } = new List<CSharpIdentifier>();

        internal IEnumerable<string> GetNamespaces()
        {
            if (!string.IsNullOrEmpty(Namespace))
                yield return Namespace;

            foreach (string ns in TypeArguments.SelectMany(x => x.GetNamespaces()))
                yield return ns;
        }

        internal TypeSyntax ToSyntax()
        {
            var type = GetPredefinedType(Name) ?? IdentifierName(Name);

            if (TypeArguments.Count != 0)
                type = GenericName(Identifier(Name)).WithTypeArgumentList(TypeArgumentList(SeparatedList(TypeArguments.Select(x => x.ToSyntax()))));

            return Nullable ? NullableType(type) : type;
        }

        public CSharpIdentifier ToNullable()
            => new CSharpIdentifier(Namespace, Name, nullable: true);

        public CSharpIdentifier ToInterface()
        {
            var result = new CSharpIdentifier(Namespace, "I" + Name);
            result.TypeArguments.AddRange(TypeArguments);
            return result;
        }

        public override string ToString()
            => TypeArguments.Count == 0
                ? Name
                : Name + "<" + string.Join(", ", TypeArguments) + ">";
    }
}
