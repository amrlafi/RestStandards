using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RestStandards.Rql.Operations;
using RestStandards.Rql.Grammar;

namespace RestStandards.Rql.UnitTests
{
    [TestClass]
    public class GrammarUnitTests
    {
        private RqlParser GetParser(string input)
        {
            var inputStream  = new AntlrInputStream(input);
            var lexer = new RqlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            return new RqlParser(commonTokenStream);
        }


        [TestMethod]
        public void ShouldReturnUnknowOperationIfNotRecongnized()
        {
            var parser = GetParser("asdsdsasda");
            var opr = parser.opr();
            var visitor = new RqlVisitor();
            var type = visitor.VisitOpr(opr);
            Assert.IsInstanceOfType(type, typeof(UnknownOperation));
        }

        [TestMethod]
        public void ShouldHandleEqual()
        {
            var parser = GetParser("eq(foo,3)");
            var opr = parser.opr();
            var visitor = new RqlVisitor();
            var type = visitor.VisitOpr(opr);
            Assert.IsInstanceOfType(type, typeof(CompareOperation));

            var compareOperation = (CompareOperation)type;
            Assert.AreEqual(Comparison.Equal, compareOperation.Comparison);
            Assert.AreEqual("foo", compareOperation.ID);
            Assert.AreEqual("3", compareOperation.Value);
        }
    }
}
