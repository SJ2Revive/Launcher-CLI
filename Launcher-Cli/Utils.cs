using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Launcher_Cli.Utils
{
    /*
     * Autor: ZRD
     * 28.09.2023
     * w tej klasie będą różnie narzędzia i czasem np webclient aby nie walał sie po wszystkich innych klasach tylko poprostu byl jeden jedyny w jednej klasie
     */
    public static class Utils
    {
        public static WebClient client = new WebClient();
        public static string Version = "1.0.2";
    }
}
