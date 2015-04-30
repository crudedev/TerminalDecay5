using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class MessageConstants
    {
        public static readonly string messageCompleteToken = "/.,,./.,/.,/.,";
        public static readonly string splitMessageToken = "][]#'#'#;.,";
        public static readonly string nextMessageToken = "=-=-#[;#'.,";

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
        }

    }
}
