// Copyright Bastian Eicher
// Licensed under the MIT License

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration;

/// <summary>
/// Extension methods for <see cref="SyntaxNode"/>s.
/// </summary>
internal static class SyntaxExtensions
{
    /// <summary>
    /// Returns a copy of the Roslyn <paramref name="node"/> with an XML documentation comment containing the <paramref name="summary"/> added.
    /// </summary>
    internal static TSyntax WithDocumentation<TSyntax>(this TSyntax node, string? summary)
        where TSyntax : SyntaxNode
    {
        if (string.IsNullOrEmpty(summary)) return node;

        var tokens = new List<SyntaxToken> {XmlTextNewLine("\n")};
        foreach (string line in summary.Split('\n'))
        {
            tokens.Add(XmlTextLiteral(" " + line));
            tokens.Add(XmlTextNewLine("\n"));
        }
        tokens.Add(XmlTextLiteral(" "));

        return node.WithLeadingTrivia(TriviaList(Trivia(DocumentationCommentTrivia(
            SyntaxKind.MultiLineDocumentationCommentTrivia,
            List(new XmlNodeSyntax[]
            {
                XmlText().WithTextTokens(TokenList(XmlTextLiteral(TriviaList(DocumentationCommentExterior("///")), " ", " ", TriviaList()))),
                XmlSummaryElement(SingletonList<XmlNodeSyntax>(XmlText(TokenList(tokens)))),
                XmlText().WithTextTokens(TokenList(XmlTextNewLine("\n", continueXmlDocumentationComment: false)))
            })))));
    }

    /// <summary>
    /// Converts a <paramref name="value"/> to a Roslyn literal expression.
    /// </summary>
    internal static LiteralExpressionSyntax ToLiteralSyntax(this object value)
        => value switch
        {
            bool x => LiteralExpression(x ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression),
            int x => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(x)),
            long x => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(x)),
            float x => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(x)),
            double x => LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(x)),
            string x => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(x)),
            _ => throw new InvalidOperationException($"{value} is not literal/constant value.")
        };
}
