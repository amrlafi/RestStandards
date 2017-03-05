using Antlr4.Runtime.Misc;
using RestStandards.Rql.Grammar;

namespace RestStandards.Rql
{
    public class RqlVisitor : RqlBaseVisitor<object>
    {
        private readonly OperationDiscovery _operationDiscovery;

        public RqlVisitor()
        {
            _operationDiscovery = new OperationDiscovery();
        }

        #region Overrides

        public override object VisitOpr([NotNull] RqlParser.OprContext context)
        {
            return _operationDiscovery.Discover(context);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
