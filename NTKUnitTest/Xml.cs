using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTK.IO.Xml;

namespace NTKUnitTest
{
    [TestClass]
    public class Xml
    {
        private string xml;
        private XmlDocument doc;

        [TestInitialize]
        public void init()
        {
            this.xml = "<test>" +
                        "   <nodeattr a1=\"value\" a2=\"value2\"\\>" +     //Node with attr & autoclose
                        "   <node>value</node>" +
                        "   <node2 att=\"test\">value2</node2>" +
                        "   <node3>" +
                        "       <node>t" +
                        "       </node>" +
                        "   </node3>" +
                        "</test>";
            this.doc = new XmlDocument(xml, false);
        }

        [TestMethod]
        public void TestGetters()
        {
            Assert.AreEqual(2, doc[0].getAllNodes("node").Count);
            Assert.AreEqual(1, doc[0].getChildsByAttribute("nodeattr", "a1", "value").Count);
            Assert.AreEqual(1, doc[0].getChildsByAttribute("a1", "value").Count);
            Assert.AreEqual(1, doc[0].getChildsByAttribute("att", "test").Count);
            Assert.AreEqual(1, doc[0].getChildsByValue("value").Count);
            Assert.IsFalse(doc[0].haveAttributes());

        }
    }
}
