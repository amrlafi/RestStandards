using Antlr4.Runtime.Tree;

namespace RestStandards.Rql.Operations
{
    [SupportedOperators]
    public class UnknownOperation : CompareOperation
    {
        public UnknownOperation(IParseTree tree) : base(tree)
        {

        }
    }
}
