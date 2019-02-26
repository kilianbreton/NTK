/********************************
 * OSS : OpenSource SetupSystem *
 * RegUninstall                 *
 * 06/11/2018                   *
 ********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSS
{
    public class RegUninstall
    {
        private RegVar displayVersion;
        private RegVar helpLink;
        private RegVar publisher;
        private RegVar uninstallString;
        private RegVar urlInfoAbout;
        private RegVar urlUpdateInfo;
        private List<RegVar> varlist;

        public RegUninstall(RegVar displayVersion, RegVar helpLink, RegVar publisher, RegVar uninstallString, RegVar urlInfoAbout, RegVar urlUpdateInfo, params RegVar[] othervars)
        {
            this.displayVersion = displayVersion;
            this.helpLink = helpLink;
            this.publisher = publisher;
            this.uninstallString = uninstallString;
            this.urlInfoAbout = urlInfoAbout;
            this.urlUpdateInfo = urlUpdateInfo;
            if(othervars != null)
            {
                varlist = new List<RegVar>();
                varlist.AddRange(othervars);
            }
        }
        public RegUninstall(String displayVersion, String helpLink, String publisher, String uninstallString, String urlInfoAbout, String urlUpdateInfo, params RegVar[] othervars)
        {
            this.displayVersion = new RegVar("",displayVersion);
            this.helpLink = new RegVar("", helpLink);
            this.publisher = new RegVar("", publisher);
            this.uninstallString = new RegVar("", uninstallString);
            this.urlInfoAbout = new RegVar("", urlInfoAbout);
            this.urlUpdateInfo = new RegVar("", urlUpdateInfo);
            if (othervars != null)
            {
                varlist = new List<RegVar>();
                varlist.AddRange(othervars);
            }
        }

        
    }
}
