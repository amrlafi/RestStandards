﻿using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace RestStandards.Rql.Queries
{
    [SupportedOperators("eq", "lt", "le", "gt", "ge", "ne")]
    public class CompareQuery : QueryBase
    {
        private readonly CompareType _type;

        public CompareQuery(IParseTree tree) : base(tree)
        {
            var common = new CommonToken(34);

            /*
            var walker = new ParseTreeWalker();
            var listener = new RqlListener();
            walker.Walk(listener, tree);
            */
            
           

            var Id = Trees.FindAllTokenNodes(tree, 38).First().GetText();

            var opr = tree.GetChild(0).GetText();
            switch (opr)
            {
                case "eq":
                    _type = CompareType.Equal;
                    break;
                case "lt":
                    _type = CompareType.LessThan;
                    break;
                case "le":
                    _type = CompareType.LessThanOrEqual;
                    break;
                case "gt":
                    _type = CompareType.GreaterThan;
                    break;
                case "ge":
                    _type = CompareType.GreaterThanOrEqual;
                    break;
                case "ne":
                    _type = CompareType.NotEqual;
                    break;
                default:
                    throw new UnsupportedOperatorException(opr, typeof(CompareQuery));
            }
        }

        public CompareType Type { get { return _type; } }

    }

    public enum CompareType
    {
        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual
    }
}