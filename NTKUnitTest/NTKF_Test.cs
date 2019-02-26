using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTK;
using NTK.Other;
using System.Collections.Generic;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static NTK.Other.NTKF;

namespace NTKUnitTest
{
    [TestClass]
    public class NTKF_Test
    {
       

        [TestMethod]
        public void NTKF_nbchar()
        {
            AreEqual(nbChar("     ", ' '), 5);
            AreEqual(nbChar("12321452682sqfr22", '2'), 6);
            AreEqual(nbChar("Salut ça va ?A", 'A'), 1);
            AreEqual(nbChar("$'(gfr$$tr-! ", '$'), 3);
            AreEqual(nbChar("ABCDbreESFbB", 'b'), 2);
            AreEqual(nbChar("GNHJKshftuyu_ç1234", '8'), 0);
        }
        [TestMethod]
        public void TestSubsep()
        {
            String basee = @"Salut /\ça::va?";
            AreEqual("ça", subsep(basee, @"/\", "::"));
            AreEqual("va?", subsep(basee, "::"));
            AreEqual("Salut ", subsep(basee, 0, @"/\"));
        }
        [TestMethod]
        public void TestDelsep()
        {
            String basee = "test::1234**AZE!!";
            AreEqual("test::1234", delseps(basee, "**", "!!"));
        }

        [TestMethod]
        public void TestVerifArg()
        {
            String base1 = "1234, azer?|;";
            String base2 = "1234 azer?";
            String base3 = "1234 azer? {|}";

            AreEqual(false, verifArgs(base1));
            AreEqual(true, verifArgs(base2));
            AreEqual(true, verifArgs(base1, true));
            AreEqual(false, verifArgs(base3, true));

        }

        [TestMethod]
        public void TestCTYPE()
        {
            AreEqual(CTYPE.BASIC, setCtype("BASIC"));
            AreEqual(CTYPE.AUTH_ADM, setCtype("AUTH_ADM"));
            AreEqual(CTYPE.AUTH_ADM_SUBS, setCtype("AUTH_ADM_SUBS"));
            AreEqual(CTYPE.AUTH_USER_O, setCtype("AUTH_USER_O"));
           
        }
        [TestMethod]
        public void TestULVL()
        {
            AreEqual(USER_LVL.ADMIN, setULVL("ADMIN"));
            AreEqual(USER_LVL.SUPER_ADMIN, setULVL("SUPER_ADMIN"));
            AreEqual(USER_LVL.BOT, setULVL("BOT"));
            AreEqual(USER_LVL.SUB_SERVER, setULVL("SUB_SERVER"));
            AreEqual(USER_LVL.USER, setULVL("USER"));

        }
        [TestMethod]
        public void TestGenerateToken()
        {
            AreNotEqual(generateToken(10), generateToken(10));
        }

        [TestMethod]
        public void TestGenerateStr()
        {
            AreEqual("**********", generStr(10, '*'));
            AreEqual(10, generStr(10, '*').Length);
        }

        [TestMethod]
        public void TestSha256()
        {
            AreEqual("9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08", sha256("test").ToUpper());
            AreEqual("856DD0DA2011C7BAD5764FDD9AD6D254C2E4054DBE259C46700350D12510FF6D", sha256("sqdqsd45q6s4dq56s4d65qs4d65q4s6d4").ToUpper());
           
        }


        [TestMethod]
        public void TestAlreadyConnected()
        {
            List<NTKUser> lst = new List<NTKUser>
            {
                new NTKUser("Kilian"),
                new NTKUser("Jean"),
                new NTKUser("Arnaud"),
                new NTKUser("Louis"),
                new NTKUser("Pierre"),
                new NTKUser("Kylian")
            };

            AreEqual(false, alreadyConnected("SFKL", lst));
            AreEqual(false, alreadyConnected("sdFDSL", lst));
            AreEqual(true, alreadyConnected("Louis", lst));
            AreEqual(true, alreadyConnected("Kilian", lst));
            AreEqual(true, alreadyConnected("Kylian", lst));
        }

        [TestMethod]
        public void TestgetUserName()
        {
            List<NTKUser> lst = new List<NTKUser>
            {
                new NTKUser("Kilian"),
                new NTKUser("Jean"),
                new NTKUser("Arnaud"),
                new NTKUser("Louis"),
                new NTKUser("Pierre"),
                new NTKUser("Kylian")
            };

            /////////////////////////////////////////////////////////

            AreEqual(0, getUserid("Kilian", lst));
           AreEqual(1, getUserid("Jean", lst));
           AreEqual(2, getUserid("Arnaud", lst));
           AreEqual(3, getUserid("Louis", lst));
           AreEqual(4, getUserid("Pierre", lst));
           AreEqual(5, getUserid("Kylian", lst));
           AreEqual(-1, getUserid("KyfDSFJSDKsan", lst));
        }

    }

}
