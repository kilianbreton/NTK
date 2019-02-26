using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTK.Security;

namespace NTKUnitTest
{
    [TestClass]
    public class AesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NTKAes aes = new NTKAes(NTKAes.CreateKey(7542,32));
            NTKAes aes2 = new NTKAes(NTKAes.CreateKey(7542, 32));
            NTKAes aesgk = new NTKAes(aes.AesKey.key, aes.AesKey.iv);
            String plaintext = "test>>-è_ç'è-ç_èéç(; !";
            String encryptedBy1 = aes.encrypt(plaintext);
            //Key & Iv 
            Assert.AreNotEqual(aes.AesKey.key, aes2.AesKey.key);
            Assert.AreNotEqual(aes.AesKey.iv, aes2.AesKey.iv);
            //Encryption
            Assert.AreNotEqual(plaintext, aes.encrypt(plaintext));
            Assert.AreNotEqual(aes.encrypt(plaintext), aes2.encrypt(plaintext));
            Assert.AreEqual(aesgk.decrypt(encryptedBy1), aes.decrypt(encryptedBy1));
            

        }


        [TestMethod]
        public void TestMethodMultiLine()
        {
            NTKAes aes = new NTKAes(NTKAes.CreateKey(7542, 32));
            NTKAes aes2 = new NTKAes(NTKAes.CreateKey(7542, 32));
            NTKAes aesgk = new NTKAes(aes.AesKey.key, aes.AesKey.iv);

            var db = NTK.Database.NTKD_MySql.getInstance("127.0.0.1", "root", "", "tekno");
            String query = "SELECT Login,Name,GrpID,OnLine,AvatarID FROM sn_users ";
            db.queryOverNTK(query, true);
            String plaintext = "te//st>>1-è_ç'è-ç_èéç(<>; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \ntest>>-è_ç'è-ç_èéç(; dsdjfkhsdjfhsjkdhfjkhsdjkfhsdjkhfjksdhjkfhsjkdhfjkshdjkfhsdjkhfjksdhjkfhsdjkhfjskdhfjkshdjkfhsjkdhfjksdhfjkhsdjkfhsjkdhfjkshdfjkhsdjkhfjkshfjkshdfezuroizefusdihcvsdhvjkbdskjvbjkqhfuioahsjfhjkqsdfjkqshfiq\ndfhsdjkhjhgjsd\nsdfjsdjkghdksj!\n rzegzeeg \n";
            plaintext = db.queryOverNTK(query, true);
            String encryptedBy1 = aes.encrypt(plaintext);
            //Key & Iv 
            Assert.AreNotEqual(aes.AesKey.key, aes2.AesKey.key);
            Assert.AreNotEqual(aes.AesKey.iv, aes2.AesKey.iv);
            //Encryption
            Assert.AreNotEqual(plaintext, aes.encrypt(plaintext));
            Assert.AreNotEqual(aes.encrypt(plaintext), aes2.encrypt(plaintext));
            Assert.AreEqual(aesgk.decrypt(encryptedBy1), aes.decrypt(encryptedBy1));

        }

        [TestMethod]
        public void TestOverSocket()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(1141);
            server.Start();





        }
    }
}
