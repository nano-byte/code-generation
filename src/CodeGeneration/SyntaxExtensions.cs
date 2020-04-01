// Copyright Bastian Eicher
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NanoByte.CodeGeneration
{
    public static class SyntaxExtensions
    {
        public static TSyntax WithDocumentation<TSyntax>(this TSyntax node, string? summary)
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
    }
}
