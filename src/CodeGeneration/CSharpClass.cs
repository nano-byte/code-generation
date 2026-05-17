// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// Describes a C# class for which code can be generated.
/// </summary>
/// <param name="identifier">The fully qualified name of the class.</param>
public class CSharpClass(CSharpIdentifier identifier) : CSharpInterface(identifier)
{
    /// <summary>
    /// The base constructor invocation for this class; <c>null</c> if there is no base class.
    /// </summary>
    public CSharpObjectCreation? BaseConstructor { get; set; }

    /// <summary>
    /// Returns an object creation expression for instantiating this class.
    /// </summary>
    public CSharpObjectCreation ToObjectCreation()
    {
        var result = new CSharpObjectCreation(Identifier);
        if (BaseConstructor != null)
            result.Parameters.AddRange(BaseConstructor.Parameters.Where(x => !x.HasLiteralValue));
        return result;
    }

    /// <inheritdoc/>
    protected override ISet<string> GetNamespaces()
    {
        var namespaces = base.GetNamespaces();

        if (BaseConstructor != null)
        {
            foreach (string ns in BaseConstructor.GetNamespaces())
                namespaces.Add(ns);
        }

        return namespaces;
    }

    /// <inheritdoc/>
    protected override TypeDeclarationSyntax GetTypeDeclaration()
        => ClassDeclaration(Identifier.Name);

    /// <inheritdoc/>
    protected override IEnumerable<BaseTypeSyntax> GetBaseTypes()
    {
        if (BaseConstructor != null)
            yield return SimpleBaseType(BaseConstructor.Type.ToSyntax());

        foreach (var type in base.GetBaseTypes())
            yield return type;
    }

    /// <inheritdoc/>
    protected override IEnumerable<MemberDeclarationSyntax> GetMemberDeclarations()
    {
        if (BaseConstructor != null && BaseConstructor.Parameters.Count != 0)
            yield return BaseConstructor.ToDeclarationSyntax(Identifier.Name);

        foreach (var member in Properties.Select(property => property.ToSyntax(makePublic: true)))
            yield return member;
    }
}
