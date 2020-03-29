using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NanoByte.CodeGeneration
{
    public interface ICSharpType
    {
        CSharpIdentifier Identifier { get; }

        CompilationUnitSyntax ToSyntax();
    }
}
