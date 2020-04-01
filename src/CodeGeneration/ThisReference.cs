// Copyright Bastian Eicher
// Licensed under the MIT License

namespace NanoByte.CodeGeneration
{
    /// <summary>
    /// "Magic" value for <see cref="CSharpParameter.Value"/> indicating that the "this" keyword should be inserted.
    /// </summary>
    public class ThisReference
    {
        public override string ToString() => "this";
    }
}
