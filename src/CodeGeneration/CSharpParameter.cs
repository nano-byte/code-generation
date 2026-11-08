// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// A parameter for a <see cref="CSharpObjectCreation"/>.
/// </summary>
/// <param name="type">The type of the parameter.</param>
/// <param name="name">The name of the parameter.</param>
public class CSharpParameter(CSharpIdentifier type, string name)
{
    /// <summary>
    /// The type of the parameter.
    /// </summary>
    public CSharpIdentifier Type { get; } = type ?? throw new ArgumentNullException(nameof(type));

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// The value to set for this parameter when invoking it. Passes through an argument of the same name when not set.
    /// </summary>
    /// <remarks>
    /// Can be a literal (<see cref="string"/>, <see cref="bool"/>, <see cref="int"/>, <see cref="long"/>, <see cref="float"/> or <see cref="double"/>), a <see cref="CSharpObjectCreation"/> (e.g. <c>new MyType()</c>) or a <see cref="ThisReference"/>.
    /// </remarks>
    public object? Value { get; set; }

    /// <summary>
    /// Indicates whether a fixed value (a literal or an object creation) is set, rather than passing through an argument.
    /// </summary>
    internal bool HasLiteralValue
        => Value != null && !(Value is ThisReference);

    /// <summary>
    /// Returns a list of all namespaces referenced/used by this parameter, including those of an object creation value.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        foreach (string ns in Type.GetNamespaces())
            yield return ns;

        if (Value is CSharpObjectCreation objectCreation)
        {
            foreach (string ns in objectCreation.GetNamespaces())
                yield return ns;
        }
    }

    /// <summary>
    /// Returns a Roslyn syntax for declaring the parameter.
    /// </summary>
    internal ParameterSyntax ToParameterSyntax()
        => Parameter(Identifier(Name)).WithType(Type.ToSyntax());

    /// <summary>
    /// Returns a Roslyn syntax for setting a value for the parameter.
    /// </summary>
    internal ArgumentSyntax ToArgumentSyntax()
        => Value switch
        {
            CSharpObjectCreation objectCreation => Argument(objectCreation.ToInvocationSyntax()).WithNameColon(NameColon(IdentifierName(Name))),
            _ when HasLiteralValue => Argument(Value!.ToLiteralSyntax()).WithNameColon(NameColon(IdentifierName(Name))),
            _ => Argument(IdentifierName(Name))
        };

    /// <summary>
    /// Returns the type, name and value of the parameter.
    /// </summary>
    public override string ToString()
        => Value == null
            ? Type + " " + Name
            : Type + " " + Name + " = " + Value;
}
