﻿using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.Compiler.Lexer;

namespace HandlebarsDotNet.Compiler
{
    internal class CommentAndLayoutConverter : TokenConverter
    {
        public static IEnumerable<object> Convert(IEnumerable<object> sequence)
        {
            return new CommentAndLayoutConverter().ConvertTokens(sequence).ToList();
        }

        private CommentAndLayoutConverter()
        {
        }

        public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
        {
            return sequence.Select(Convert);
        }

        private static object Convert(object item)
        {
            if (item is CommentToken commentToken)
            {
                return HandlebarsExpression.Comment(commentToken.Value);
            }

            if (item is LayoutToken)
            {
                return HandlebarsExpression.Comment(null);
            }

            return item;
        }
    }
}

