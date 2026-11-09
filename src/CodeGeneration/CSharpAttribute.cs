// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// An attribute on a <see cref="CSharpType"/>, <see cref="CSharpProperty"/> or <see cref="CSharpEnumValue"/>.
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
    /// <remarks>
    /// Can be a literal (<see cref="string"/>, <see cref="bool"/>, <see cref="int"/>, <see cref="long"/>, <see cref="float"/> or <see cref="double"/>) or a <see cref="CSharpIdentifier"/> (emitted as <c>typeof(...)</c>).
    /// </remarks>
    public List<object> Arguments { get; } = new();

    /// <summary>
    /// Named arguments for the attribute.
    /// </summary>
    /// <remarks>
    /// Values can be anything <see cref="Arguments"/> accepts.
    /// </remarks>
    public List<(string name, object value)> NamedArguments { get; } = new();

    /// <summary>
    /// Returns a list of all namespaces referenced/used by this attribute, including those of <c>typeof(...)</c> arguments.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        if (!string.IsNullOrEmpty(Identifier.Namespace))
            yield return Identifier.Namespace;

        foreach (var identifier in Arguments.Concat(NamedArguments.Select(x => x.value)).OfType<CSharpIdentifier>())
        {
            foreach (string ns in identifier.GetNamespaces())
                yield return ns;
        }
    }

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
            yield return AttributeArgument(ToExpressionSyntax(value));

        foreach ((string name, var value) in NamedArguments)
            yield return AttributeArgument(ToExpressionSyntax(value)).WithNameEquals(NameEquals(name));
    }

    private static ExpressionSyntax ToExpressionSyntax(object value)
        => value is CSharpIdentifier identifier
            ? TypeOfExpression(identifier.ToSyntax())
            : value.ToLiteralSyntax();

    private static string TrimAttributeSuffix(string name)
        => name.EndsWith("Attribute")
            ? name.Remove(name.Length - "Attribute".Length)
            : name;
}
