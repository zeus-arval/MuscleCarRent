using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuscleCarRentProject.Pages.Extensions;

namespace Tests.Pages.Extension
{
    [TestClass]
    public class ShowHtmlTests
    {
        [TestMethod]
        public void ShowFunctionTest()
        {
            Assert.AreEqual("A B",ShowHtml.Show("A", "B"));
            Assert.AreEqual("1 2", ShowHtml.Show(1, 2));
            Assert.AreEqual("1,4 2,5", ShowHtml.Show(1.4, 2.5));
            Assert.AreEqual("A 493", ShowHtml.Show("A", 493));
        }

        private string intfunc(int i) => i.ToString();
        private string strfunc(string i) => i;
        private string doublefunc(double i) => i.ToString();

        [TestMethod]
        public void ShowExpressionTest()
        {
            Assert.AreEqual("ABC", ShowHtml.ShowExpression(x => strfunc(x), "ABC"));
            Assert.AreEqual("2", ShowHtml.ShowExpression(x => intfunc(x), 2));
            Assert.AreEqual("2,5", ShowHtml.ShowExpression(x => doublefunc(x), 2.5));
        }
    }
}
