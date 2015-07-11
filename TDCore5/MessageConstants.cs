using System;
using System.Collections.Generic;

namespace TDCore5
{
    public class MessageConstants
    {
        public static readonly string completeToken = "/.,,./.,/.,/.,";
        public static readonly string splitToken = "][]#'#'#;.,";
        public static readonly string nextToken = "=-=-#[;#'.,";

        public static Dictionary<Int64, string> MessageTypes;

        public static void InitValues()
        {
            MessageTypes = new Dictionary<long, string>();
            MessageTypes.Add(0, "GetMep[]'##]~#]@@'#?%$sdf");
            MessageTypes.Add(1, "CreateAccount'##]@@''~dfs");
            MessageTypes.Add(2, "LoginToAccount'''~##?%$]@");
            MessageTypes.Add(3, "ViewMainMap~##i#]@@?%$ssd");
            MessageTypes.Add(4, "ViewResTile~###'~## d$ssd");
            MessageTypes.Add(5, "ViewBuildTile~##]@?$sd!!!");
            MessageTypes.Add(6, "SendPlayerRes~##:@123rcvb");
            MessageTypes.Add(7, "SendBuildList~##:@~@:xcvb");
            MessageTypes.Add(8, "SendBuildRequest~y6s'sye7");
            MessageTypes.Add(9, "SendDefBuildList~xstfzbyj");
            MessageTypes.Add(10, "SendDefBuildRequest}P{Lf:");
            MessageTypes.Add(11, "SendOffenceListad54$^$Fdc");
            MessageTypes.Add(12, "SendOffenceBuildRequest%&");
            MessageTypes.Add(13, "SendOffence^^&ssdef%6565&");
            MessageTypes.Add(14, "SendAttacku>|&sf65ff%%!!!");
            MessageTypes.Add(15, "GetMessagesagvsik.p#75wgj");
            MessageTypes.Add(16, "ReadMessageajl623dcrioxmk");
            MessageTypes.Add(17, "ViewSolarMap^&^&%**%d.1sa");
            MessageTypes.Add(18, "ViewClusterMapxxdjgrymn,4");
            MessageTypes.Add(19, "ViewUniverse,4dk,meiu8hg6");
            MessageTypes.Add(20, "FetchPlayerHomeSl.tryhsvf");
            MessageTypes.Add(21, "GetAllUnits.zxctuym,olDJE");
            MessageTypes.Add(22, "SendReinforcements.uym*oD");
            MessageTypes.Add(23, "RemoveBuildQclement198/*/");
            MessageTypes.Add(24, "RemoveOffenceQ%*dd[[[as12");
            MessageTypes.Add(25, "RemoveDeffence.,.,222saAA");
            MessageTypes.Add(26, "MoveBase;a/l.47iyhqwp92in");
        }

    }
}
