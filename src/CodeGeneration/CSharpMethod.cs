// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// A method on a <see cref="CSharpInterface"/> or <see cref="CSharpClass"/>.
/// </summary>
/// <param name="returnType">The type returned by the method.</param>
/// <param name="name">The name of the method.</param>
public class CSharpMethod(CSharpIdentifier returnType, string name)
{
    /// <summary>
    /// The type returned by the method.
    /// </summary>
    public CSharpIdentifier ReturnType { get; } = returnType ?? throw new ArgumentNullException(nameof(returnType));

    /// <summary>
    /// The name of the method.
    /// </summary>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// The parameters the method takes.
    /// </summary>
    public List<CSharpParameter> Parameters { get; } = new();

    /// <summary>
    /// A summary used for an XML documentation comment.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// The interface to explicitly implement this method for; <c>null</c> for a regular member.
    /// </summary>
    public CSharpIdentifier? ExplicitInterface { get; set; }

    /// <summary>
    /// An expression body for the method as a raw C# expression (e.g. <c>CreateAsync(entity)</c>).
    /// </summary>
    public string? BodyExpression { get; set; }

    /// <summary>
    /// Returns a list of all namespaces referenced/used in this method.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        foreach (string ns in ReturnType.GetNamespaces())
            yield return ns;

        foreach (string ns in Parameters.SelectMany(x => x.Type.GetNamespaces()))
            yield return ns;

        if (ExplicitInterface != null)
        {
            foreach (string ns in ExplicitInterface.GetNamespaces())
                yield return ns;
        }
    }

    /// <summary>
    /// Returns a Roslyn syntax for the method.
    /// </summary>
    /// <param name="makePublic">Controls whether to make the method public or not. Ignored if <see cref="ExplicitInterface"/> is set.</param>
    internal MethodDeclarationSyntax ToSyntax(bool makePublic = false)
    {
        var declaration = MethodDeclaration(ReturnType.ToSyntax(), Identifier(Name))
           .WithParameterList(ParameterList(SeparatedList(Parameters.Select(x => x.ToParameterSyntax()))));

        // Explicit interface implementations may not have access modifiers
        if (ExplicitInterface == null)
        {
            if (makePublic) declaration = declaration.AddModifiers(Token(SyntaxKind.PublicKeyword));
        }
        else
            declaration = declaration.WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier(ExplicitInterface.ToNameSyntax()));

        declaration = declaration.WithDocumentation(Summary);

        return (BodyExpression == null
                ? declaration
                : declaration.WithExpressionBody(ArrowExpressionClause(ParseExpression(BodyExpression))))
           .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
    }

    /// <summary>
    /// Returns the signature of the method.
    /// </summary>
    public override string ToString()
        => $"{ReturnType} {Name}({string.Join(", ", Parameters)})";
}
