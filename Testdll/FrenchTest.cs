using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;

namespace Testdll
{
    public class FrenchTest : Language
    {
        private List<String> texts;

        public FrenchTest()
        {
            texts = new List<String>();
            texts.Add("1");
            texts.Add("1");
            texts.Add("2");
            texts.Add("11");
            texts.Add("");
            texts.Add("1");
            texts.Add("");
            texts.Add("1");
            texts.Add("1");
            texts.Add("2");
            texts.Add("5");
            texts.Add("5");
            texts.Add("98");
            texts.Add("77");  
            texts.Add("231231");
            texts.Add("");
            texts.Add("111");
            texts.Add("0");
            texts.Add("000");
            texts.Add("");
            texts.Add("11");
            texts.Add("1");
            texts.Add("");
            texts.Add("");
            texts.Add("");
        }

        public override string NTK => throw new NotImplementedException();

        public override string LOADING_SERVICE => throw new NotImplementedException();

        public override string LISTENING => throw new NotImplementedException();

        public override string DISCONNECTED => throw new NotImplementedException();

        public override string HELP => throw new NotImplementedException();

        public override string CI_DB => throw new NotImplementedException();

        public override string CI_CLIENT => throw new NotImplementedException();

        public override string CI_SERVER => throw new NotImplementedException();

        public override string CI_PLUGINS => throw new NotImplementedException();

        public override string CI_ENCRYPTION => throw new NotImplementedException();

        public override string CI_CGI => throw new NotImplementedException();

        public override string CI_EXIT => throw new NotImplementedException();

        public override string CI_ASK_SERVER => throw new NotImplementedException();

        public override string CI_ASK_USER => throw new NotImplementedException();

        public override string CI_ASK_BASE => throw new NotImplementedException();

        public override string CI_DB_RC => throw new NotImplementedException();

        public override string CI_db8ask => throw new NotImplementedException();

        public override string CI_DB_Q => throw new NotImplementedException();

        public override string CI_AYS => throw new NotImplementedException();

        public override string CI_SKS_TITLE => throw new NotImplementedException();
    }
}
