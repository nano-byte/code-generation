// Copyright Bastian Eicher
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// Describes a C# class for which code can be generated.
/// </summary>
public class CSharpClass : CSharpInterface
{
    /// <summary>
    /// Creates a new C# class.
    /// </summary>
    /// <param name="identifier">The fully qualified name of the class.</param>
    public CSharpClass(CSharpIdentifier identifier)
        : base(identifier)
    {}

    /// <summary>
    /// The base class of this class; <c>null</c> if none.
    /// </summary>
    public CSharpConstructor? BaseClass { get; set; }

    /// <summary>
    /// Returns a constructor for instantiating this class.
    /// </summary>
    public CSharpConstructor GetConstruction()
    {
        var result = new CSharpConstructor(Identifier);
        if (BaseClass != null)
            result.Parameters.AddRange(BaseClass.Parameters.Where(x => !x.HasLiteralValue));
        return result;
    }

    /// <inheritdoc/>
    protected override ISet<string> GetNamespaces()
    {
        var namespaces = base.GetNamespaces();

        if (BaseClass != null)
        {
            foreach (string ns in BaseClass.GetNamespaces())
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
        if (BaseClass != null)
            yield return SimpleBaseType(BaseClass.Type.ToSyntax());

        foreach (var type in base.GetBaseTypes())
            yield return type;
    }

    /// <inheritdoc/>
    protected override IEnumerable<MemberDeclarationSyntax> GetMemberDeclarations()
    {
        if (BaseClass != null && BaseClass.Parameters.Count != 0)
            yield return BaseClass.ToDeclarationSyntax(Identifier.Name);

        foreach (var member in Properties.Select(property => property.ToSyntax(makePublic: true)))
            yield return member;
    }
}
