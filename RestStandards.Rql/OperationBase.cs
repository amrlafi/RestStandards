using Antlr4.Runtime.Tree;

namespace RestStandards.Rql
{
    public abstract class OperationBase : IOperation
    {
        private readonly IParseTree _tree;

        public OperationBase(IParseTree tree)
        {
            _tree = tree;
        }

        protected IParseTree Tree { get { return _tree; } }

        public abstract void Build();
    }
}
