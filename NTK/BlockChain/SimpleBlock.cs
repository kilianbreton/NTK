using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NTK.Security;

namespace NTK.BlockChain
{
    public class SimpleBlock : Block<String>
    {
        private static int nb = 0;
        private int id;
        private String name;
        private String lastName;
        private int lastNonce = 0;
        private List<String> datalst = new List<String>();
        private IHash hashAlgo;



        public SimpleBlock(string lastName, IHash algo)
        {
            this.lastName = lastName;
            this.hashAlgo = algo;
            this.id = ++nb;
        }

        //Déstructeur
        ~SimpleBlock()
        {
            SimpleBlock.nb -= 1;
        }


        public override void addData(string data)
        {
            this.datalst.Add(data);
        }

        public override string compute(int nonce)
        {
            String ret;
            ret = lastName;
            foreach(String data in datalst)
            {
                ret += data;
            }
            ret += nonce;
            return hashAlgo.getHash(ret);
        }

        public override bool compute(string regex)
        {
            Regex rx = new Regex(regex);
            String hash = "x";
            int cpt = 0;
            
            bool end = false;
            while (!rx.IsMatch(hash))
            {
                String ret;
                ret = lastName;
                foreach (String data in datalst)
                {
                    ret += data;
                }
                ret += cpt;
                hash = hashAlgo.getHash(ret);
                this.lastNonce=cpt++;
            }
            this.name = hash;

            return end;
        }

        public override string getData()
        {
            String ret = "";

            foreach (String data in datalst)
            {
                ret += data;
            }
            return ret;
        }
    }
}
