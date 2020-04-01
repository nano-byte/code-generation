// Copyright Bastian Eicher
// Licensed under the MIT License

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// Describes a C# type for which code can be generated.
    /// </summary>
    public interface ICSharpType
    {
        /// <summary>
        /// The fully qualified name of the type.
        /// </summary>
        CSharpIdentifier Identifier { get; }

        /// <summary>
        /// Returns a Roslyn syntax for a file containing the type.
        /// </summary>
        CompilationUnitSyntax ToSyntax();
    }
}
