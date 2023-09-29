using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

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
        public static string Version = "1.0.3";
        public static Clientwebsocket


        // jak sama nazwa funckji mówi, jest to odpowiedzialne za animowany tytuł konsoli
        public static void AnimatedTitle()
        {
            string title = " SJ2REVIVE NAJLEPSZE MODY DO SJ2 -> https://sj2r.zndev.xyz";
            while (true)
            {
                for (int i = 0; i < title.Length; i++)
                {
                    Console.Title = title.Substring(i) + title.Substring(0, i);
                    Thread.Sleep(200);
                }
            }
        }
    }
}
