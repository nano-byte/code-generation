// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// A property on a <see cref="CSharpInterface"/> or <see cref="CSharpClass"/>.
/// </summary>
/// <param name="type">The type of the property.</param>
/// <param name="name">The name of the property.</param>
public class CSharpProperty(CSharpIdentifier type, string name)
{
    /// <summary>
    /// The type of the property.
    /// </summary>
    public CSharpIdentifier Type { get; } = type ?? throw new ArgumentNullException(nameof(type));

    /// <summary>
    /// The name of the property.
    /// </summary>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// A summary used for an XML documentation comment.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Attributes to apply to the property.
    /// </summary>
    public List<CSharpAttribute> Attributes { get; } = new();

    /// <summary>
    /// The property's initializer (sets default value).
    /// </summary>
    /// <remarks>Mutually exclusive with <see cref="InitializerExpression"/> and <see cref="GetterExpression"/>.</remarks>
    public CSharpObjectCreation? Initializer { get; set; }

    /// <summary>
    /// The property's initializer as a raw C# expression (e.g. <c>null!</c>).
    /// </summary>
    /// <remarks>Mutually exclusive with <see cref="Initializer"/> and <see cref="GetterExpression"/>.</remarks>
    public string? InitializerExpression { get; set; }

    /// <summary>
    /// An expression body for the property's getter.
    /// </summary>
    /// <remarks>Mutually exclusive with <see cref="Initializer"/> and <see cref="InitializerExpression"/>.</remarks>
    public CSharpObjectCreation? GetterExpression { get; set; }

    /// <summary>
    /// Indicates whether the property has a setter.
    /// </summary>
    public bool HasSetter { get; set; }

    /// <summary>
    /// Indicates whether the property is marked with the <c>required</c> modifier.
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// Returns a list of all namespaces referenced/used in this property.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        foreach (string ns in Type.GetNamespaces())
            yield return ns;

        foreach (string? ns in Attributes.Select(x => x.Identifier.Namespace))
        {
            if (ns != null)
                yield return ns;
        }

        if (Initializer != null)
        {
            foreach (string ns in Initializer.GetNamespaces())
                yield return ns;
        }

        if (GetterExpression != null)
        {
            foreach (string ns in GetterExpression.GetNamespaces())
                yield return ns;
        }
    }

    /// <summary>
    /// Returns a Roslyn syntax for the property.
    /// </summary>
    /// <param name="makePublic">Controls whether to make the property public or not.</param>
    internal PropertyDeclarationSyntax ToSyntax(bool makePublic = false)
    {
        var declaration = PropertyDeclaration(Type.ToSyntax(), Identifier(Name));

        if (makePublic)
        {
            declaration = IsRequired
                ? declaration.AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.RequiredKeyword))
                : declaration.AddModifiers(Token(SyntaxKind.PublicKeyword));
        }

        declaration = declaration.WithAttributeLists(List(Attributes.Select(x => x.ToSyntax())))
                                 .WithDocumentation(Summary);

        if (new[] {Initializer != null, InitializerExpression != null, GetterExpression != null}.Count(x => x) > 1)
            throw new InvalidOperationException($"Only one of {nameof(Initializer)}, {nameof(InitializerExpression)} and {nameof(GetterExpression)} may be set for the same {nameof(CSharpProperty)}.");

        if (GetterExpression != null)
        {
            if (HasSetter)
                throw new InvalidOperationException($"{nameof(GetterExpression)} and {nameof(HasSetter)} may not be both set for the same {nameof(CSharpProperty)}.");

            declaration = declaration.WithExpressionBody(ArrowExpressionClause(GetterExpression.ToInvocationSyntax()))
                                     .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }
        else
        {
            var accessors = new List<SyntaxKind> {SyntaxKind.GetAccessorDeclaration};
            if (HasSetter) accessors.Add(SyntaxKind.SetAccessorDeclaration);

            declaration = declaration.WithAccessorList(AccessorList(List(
                accessors.Select(x => AccessorDeclaration(x).WithSemicolonToken(Token(SyntaxKind.SemicolonToken))))));
        }

        ExpressionSyntax? initializer = Initializer?.ToInvocationSyntax()
                                     ?? (InitializerExpression == null ? null : ParseExpression(InitializerExpression));
        if (initializer != null)
        {
            declaration = declaration.WithInitializer(EqualsValueClause(initializer))
                                     .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
        }

        return declaration;
    }

    /// <summary>
    /// Returns the name of the property.
    /// </summary>
    public override string ToString()
        => Name;
}
