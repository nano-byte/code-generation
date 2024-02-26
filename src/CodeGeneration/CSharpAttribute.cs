// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// An attribute on a <see cref="CSharpInterface"/>, <see cref="CSharpClass"/> or <see cref="CSharpProperty"/>.
/// </summary>
/// <param name="identifier">The type of the attribute.</param>
public class CSharpAttribute(CSharpIdentifier identifier)
{
    /// <summary>
    /// The type of the attribute.
    /// </summary>
    public CSharpIdentifier Identifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));

    /// <summary>
    /// Arguments for the attribute.
    /// </summary>
    public List<object> Arguments { get; } = new();

    /// <summary>
    /// Named Arguments for the attribute.
    /// </summary>
    public List<(string name, object value)> NamedArguments { get; } = new();

    /// <summary>
    /// Returns a Roslyn syntax for the attribute.
    /// </summary>
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
