using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RestStandards.Rql.Queries;
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
        public void ShouldReturnUnknowQueryIfNotRecongnized()
        {
            var parser = GetParser("asdsdsasda");
            var query = parser.query();
            var visitor = new RqlVisitor();
            var type = visitor.VisitQuery(query);
            Assert.IsInstanceOfType(type, typeof(UnknownQuery));
        }

        [TestMethod]
        public void ShouldHandleEqual()
        {
            var parser = GetParser("eq(foo,3)");
            var query = parser.query();
            var visitor = new RqlVisitor();
            var type = visitor.VisitQuery(query);
            Assert.IsInstanceOfType(type, typeof(CompareQuery));

            var compareQuery = (CompareQuery)type;
            Assert.AreEqual(CompareType.Equal, compareQuery.Type);
        }
    }
}
