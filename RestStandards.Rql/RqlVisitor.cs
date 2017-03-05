using Antlr4.Runtime.Misc;
using RestStandards.Rql.Grammar;

namespace RestStandards.Rql
{
    public class RqlVisitor : RqlBaseVisitor<object>
    {
        private readonly OperationDiscoverer _operationDiscoverer;

        public RqlVisitor()
        {
            _operationDiscoverer = new OperationDiscoverer();
        }

        #region Overrides

        public override object VisitOpr([NotNull] RqlParser.OprContext context)
        {
            return _operationDiscoverer.Discover(context);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
