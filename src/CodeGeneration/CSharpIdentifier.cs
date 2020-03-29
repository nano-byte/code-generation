using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public class CSharpIdentifier
    {
        public static CSharpIdentifier Bool => new CSharpIdentifier("bool");
        public static CSharpIdentifier Int => new CSharpIdentifier("int");
        public static CSharpIdentifier Long => new CSharpIdentifier("long");
        public static CSharpIdentifier Float => new CSharpIdentifier("float");
        public static CSharpIdentifier Double => new CSharpIdentifier("double");
        public static CSharpIdentifier String => new CSharpIdentifier("string");
        public static CSharpIdentifier Object => new CSharpIdentifier("object");
        public static CSharpIdentifier Uri => new CSharpIdentifier("System", "Uri");

        public static CSharpIdentifier ListOf(CSharpIdentifier type)
            => new CSharpIdentifier("System.Collections.Generic", "List") {TypeArguments = {type}};

        public static CSharpIdentifier DictionaryOf(CSharpIdentifier keyType, CSharpIdentifier valueType)
            => new CSharpIdentifier("System.Collections.Generic", "Dictionary") {TypeArguments = {keyType, valueType}};

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

        public CSharpIdentifier AsNullable()
            => new CSharpIdentifier(Namespace, Name, nullable: true);

        public List<CSharpIdentifier> TypeArguments { get; } = new List<CSharpIdentifier>();

        public IEnumerable<string> GetNamespaces()
        {
            if (!string.IsNullOrEmpty(Namespace))
                yield return Namespace;

            foreach (string ns in TypeArguments.SelectMany(x => x.GetNamespaces()))
                yield return ns;
        }

        public TypeSyntax ToSyntax()
        {
            var type = Name switch
            {
                "bool" => PredefinedType(Token(SyntaxKind.BoolKeyword)),
                "int" => PredefinedType(Token(SyntaxKind.IntKeyword)),
                "long" => PredefinedType(Token(SyntaxKind.LongKeyword)),
                "float" => PredefinedType(Token(SyntaxKind.FloatKeyword)),
                "double" => PredefinedType(Token(SyntaxKind.DoubleKeyword)),
                "string" => PredefinedType(Token(SyntaxKind.StringKeyword)),
                "object" => PredefinedType(Token(SyntaxKind.ObjectKeyword)),
                _ => (TypeArguments.Count == 0 ? (TypeSyntax)IdentifierName(Name) : GenericName(Identifier(Name)).WithTypeArgumentList(TypeArgumentList(SeparatedList(TypeArguments.Select(x => x.ToSyntax())))))
            };
            return Nullable ? NullableType(type) : type;
        }

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
