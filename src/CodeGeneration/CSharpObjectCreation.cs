// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// An object creation expression (a <c>new T(args)</c> call) describing how to instantiate a type.
/// </summary>
/// <param name="type">The fully qualified name of the type to instantiate.</param>
public class CSharpObjectCreation(CSharpIdentifier type)
{
    /// <summary>
    /// The fully qualified name of the type to instantiate.
    /// </summary>
    public CSharpIdentifier Type { get; } = type ?? throw new ArgumentNullException(nameof(type));

    /// <summary>
    /// The arguments to pass to the constructor.
    /// </summary>
    public List<CSharpParameter> Parameters { get; } = new();

    /// <summary>
    /// Returns a list of all namespaces referenced/used in this object creation.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        foreach (string ns in Type.GetNamespaces())
            yield return ns;

        foreach (string ns in Parameters.SelectMany(x => x.Type.GetNamespaces()))
            yield return ns;
    }

    /// <summary>
    /// Returns a Roslyn syntax for invoking the constructor (<c>new</c>).
    /// </summary>
    internal ObjectCreationExpressionSyntax ToInvocationSyntax()
        => ObjectCreationExpression(Type.ToSyntax())
           .WithArgumentList(GetArgumentList(thisKeyword: true));

    /// <summary>
    /// Returns a Roslyn syntax for a constructor declaration that forwards these parameters to a base constructor call.
    /// </summary>
    internal ConstructorDeclarationSyntax ToDeclarationSyntax(string typeName)
        => ConstructorDeclaration(Identifier(typeName))
          .AddModifiers(Token(SyntaxKind.PublicKeyword))
          .WithParameterList(GetParameterList())
          .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, GetArgumentList(thisKeyword: false)))
          .WithBody(Block());

    private ArgumentListSyntax GetArgumentList(bool thisKeyword)
        => ArgumentList(SeparatedList(
            Parameters.Select(x => thisKeyword && x.Value is ThisReference
                ? Argument(ThisExpression())
                : x.ToArgumentSyntax())));

    private ParameterListSyntax GetParameterList()
        => ParameterList(SeparatedList(
            Parameters.Where(x => !x.HasLiteralValue)
                      .Select(x => x.ToParameterSyntax())));

    /// <summary>
    /// Returns the name of the type being instantiated.
    /// </summary>
    public override string ToString()
        => Type.ToString();
}
