// Copyright Bastian Eicher
// Licensed under the MIT License

using System.IO;
using System.Text;

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// Extension methods for <see cref="ICSharpType"/>.
    /// </summary>
    public static class CSharpTypeExtensions
    {
        /// <summary>
        /// Writes C# code for the type to a file at <paramref name="path"/>.
        /// </summary>
        public static void WriteToFile(this ICSharpType type, string path)
            => File.WriteAllText(path, type.ToSyntax().ToFullString(), Encoding.UTF8);

        /// <summary>
        /// Writes C# code for the type to a file in the directory at <paramref name="path"/>.
        /// </summary>
        public static void WriteToDirectory(this ICSharpType type, string path)
            => type.WriteToFile(Path.Combine(path, type.Identifier.Name + ".cs"));
    }
}
