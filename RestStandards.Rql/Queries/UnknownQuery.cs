using Antlr4.Runtime.Tree;

namespace RestStandards.Rql.Queries
{
    [SupportedOperators]
    public class UnknownQuery : QueryBase
    {
        public UnknownQuery(IParseTree tree) : base(tree)
        {

        }
    }
}
