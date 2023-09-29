using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;
using Launcher_Cli.Utils;
using System.Runtime.InteropServices;

namespace Launcher_Cli
{
    /*
     * Autor: ZRD
     * Główna Klasa Launchera
     * 
     * 28.09.2023
     */

    public class Launcher
    {
        private static string v = Utils.Utils.Version;
        #region unmanaged
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        #endregion
        private static bool isclosing = false;
        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_CLOSE_EVENT:
                    isclosing = true;
                    Api.UserDisconnected();
                    break;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Thread newThread = new Thread(new ThreadStart(Utils.Utils.AnimatedTitle)); // działa? działa. jest dobrze? działa
            newThread.Start();
            Utils.Utils.ReadConfig();
            Api.UserConnected();
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
            
            

            // nwm fajnie wyglada xd
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
 ____________________________
|                            |
|                            |
|         SJ2Revive          |
|         Launcher           |
|           Lite             |
|           "+v+@"              |
|                            |
|                            |
|                            |
|____________________________|");
            // ale juz wracamy do normalnego koloru
            Console.ForegroundColor= ConsoleColor.White;
            if(int.Parse(Api.GetCurrentActiveUsers()) >= 1)
            {
                Console.WriteLine($"\nAktualnie jest aktywne {Api.GetCurrentActiveUsers()} użytkoników");
            } else
            {
                Console.WriteLine($"\nAktualnie jest aktywny {Api.GetCurrentActiveUsers()} użytkonik");
            }
            Console.WriteLine($"Twój Identyfikator {ConfigData.User}");
            Console.WriteLine("1) Uruchom Grę"); 
            Console.WriteLine("2) Przeglądaj Mody");
            Console.WriteLine("3) Otwórz strone sj2r");
            Console.WriteLine("4) Wyjdź");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    // prosty check czy napewno użytkownik wrzucił launchera do poprawnego folderu
                    if(!File.Exists(".\\PJ2.exe"))
                    {
                        Console.WriteLine("nie znaleziono gry, czy napewno dobrze zainstalowales launcher?");
                        
                    } else
                    {
                        Process.Start(".\\PJ2.exe");
                    }
                    

                }
                if (key.KeyChar == '2')
                {
                    Console.WriteLine("TODO");
                }
                if (key.KeyChar == '3')
                {
                    Process.Start("https://sj2r.zndev.xyz");
                }
                if (key.KeyChar == '4')
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
