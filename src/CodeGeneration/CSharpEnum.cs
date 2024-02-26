// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// Describes a C# enum for which code can be generated.
/// </summary>
/// <param name="identifier">The fully qualified name of the enum.</param>
public class CSharpEnum(CSharpIdentifier identifier) : CSharpType(identifier)
{
    /// <summary>
    /// A list of possible values for the enum.
    /// </summary>
    public List<CSharpEnumValue> Values { get; } = new();

    /// <inheritdoc/>
    protected override MemberDeclarationSyntax GetMemberDeclaration()
        => EnumDeclaration(Identifier.Name)
          .AddModifiers(Token(SyntaxKind.PublicKeyword))
          .WithMembers(SeparatedList(Values.Select(value => value.ToSyntax())));

    /// <inheritdoc/>
    protected override ISet<string> GetNamespaces()
    {
        var namespaces = base.GetNamespaces();

        foreach (string ns in Values.SelectMany(x => x.GetNamespaces()))
            namespaces.Add(ns);

        return namespaces;
    }
}
