﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;

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
        static void Main(string[] args)
        {
            Thread newThread = new Thread(new ThreadStart(Utils.Utils.AnimatedTitle)); // działa? działa. jest dobrze? działa
            newThread.Start();
             
            
            
            // nwm fajnie wyglada xd
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
 ____________________________
|                            |
|                            |
|         SJ2Revive          |
|         Launcher           |
|           Lite             |
|           "+v+@"            |
|                            |
|                            |
|                            |
|____________________________|");
            // ale juz wracamy do normalnego koloru
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine($"\nAktualnie jest aktywne {Api.GetCurrentActiveUsers()} użytkoników");
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
