// Copyright Bastian Eicher
// Licensed under the MIT License

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public partial class CSharpIdentifier
    {
        public static CSharpIdentifier Bool => new("bool");

        public static CSharpIdentifier Int => new("int");

        public static CSharpIdentifier Long => new("long");

        public static CSharpIdentifier Float => new("float");

        public static CSharpIdentifier Double => new("double");

        public static CSharpIdentifier String => new("string");

        public static CSharpIdentifier Object => new("object");

        public static CSharpIdentifier Uri => new("System", "Uri");

        public static CSharpIdentifier ListOf(CSharpIdentifier type) => new("System.Collections.Generic", "List") {TypeArguments = {type}};

        public static CSharpIdentifier DictionaryOf(CSharpIdentifier keyType, CSharpIdentifier valueType) => new("System.Collections.Generic", "Dictionary") {TypeArguments = {keyType, valueType}};

        private static TypeSyntax? GetPredefinedType(string name)
            => name switch
            {
                "bool" => PredefinedType(Token(SyntaxKind.BoolKeyword)),
                "int" => PredefinedType(Token(SyntaxKind.IntKeyword)),
                "long" => PredefinedType(Token(SyntaxKind.LongKeyword)),
                "float" => PredefinedType(Token(SyntaxKind.FloatKeyword)),
                "double" => PredefinedType(Token(SyntaxKind.DoubleKeyword)),
                "string" => PredefinedType(Token(SyntaxKind.StringKeyword)),
                "object" => PredefinedType(Token(SyntaxKind.ObjectKeyword)),
                _ => null
            };
    }
}
