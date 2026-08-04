// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// An indexer on a <see cref="CSharpInterface"/> or <see cref="CSharpClass"/>.
/// </summary>
/// <param name="type">The type of the value returned by the indexer.</param>
/// <param name="parameter">The parameter the indexer is addressed with.</param>
public class CSharpIndexer(CSharpIdentifier type, CSharpParameter parameter)
{
    /// <summary>
    /// The type of the value returned by the indexer.
    /// </summary>
    public CSharpIdentifier Type { get; } = type ?? throw new ArgumentNullException(nameof(type));

    /// <summary>
    /// The parameter the indexer is addressed with.
    /// </summary>
    public CSharpParameter Parameter { get; } = parameter ?? throw new ArgumentNullException(nameof(parameter));

    /// <summary>
    /// A summary used for an XML documentation comment.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// The interface to explicitly implement this indexer for; <c>null</c> for a regular member.
    /// </summary>
    public CSharpIdentifier? ExplicitInterface { get; set; }

    /// <summary>
    /// An expression body for the indexer's getter as a raw C# expression (e.g. <c>this[id]</c>).
    /// </summary>
    public string? GetterExpression { get; set; }

    /// <summary>
    /// Returns a list of all namespaces referenced/used in this indexer.
    /// </summary>
    internal IEnumerable<string> GetNamespaces()
    {
        foreach (string ns in Type.GetNamespaces())
            yield return ns;

        foreach (string ns in Parameter.Type.GetNamespaces())
            yield return ns;

        if (ExplicitInterface != null)
        {
            foreach (string ns in ExplicitInterface.GetNamespaces())
                yield return ns;
        }
    }

    /// <summary>
    /// Returns a Roslyn syntax for the indexer.
    /// </summary>
    /// <param name="makePublic">Controls whether to make the indexer public or not. Ignored if <see cref="ExplicitInterface"/> is set.</param>
    internal IndexerDeclarationSyntax ToSyntax(bool makePublic = false)
    {
        var declaration = IndexerDeclaration(Type.ToSyntax())
           .WithParameterList(BracketedParameterList(SingletonSeparatedList(Parameter.ToParameterSyntax())));

        // Explicit interface implementations may not have access modifiers
        if (ExplicitInterface == null)
        {
            if (makePublic) declaration = declaration.AddModifiers(Token(SyntaxKind.PublicKeyword));
        }
        else
            declaration = declaration.WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier(ExplicitInterface.ToNameSyntax()));

        declaration = declaration.WithDocumentation(Summary);

        return GetterExpression == null
            ? declaration.WithAccessorList(AccessorList(SingletonList(
                AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)))))
            : declaration.WithExpressionBody(ArrowExpressionClause(ParseExpression(GetterExpression)))
                         .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
    }

    /// <summary>
    /// Returns the signature of the indexer.
    /// </summary>
    public override string ToString()
        => $"{Type} this[{Parameter}]";
}
