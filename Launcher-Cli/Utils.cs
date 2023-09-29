using System;
using System.Net;
using System.Threading;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

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
        public static string Version = "1.2";
        


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
        // funkcja od zapisywania ustawien
        public static void SaveConfig()
        {
            // sprawdzamy czy folder z configiem istnieje
            if(!Directory.Exists("C:\\SJ2Revive\\"))
            {
                // jesli nie. tworzymy go
                Directory.CreateDirectory("C:\\SJ2Revive\\");
                var config = new Config
                {
                    RandomUser = new Random().Next(1000000, 9999999).ToString()
                };
                // konwertujemy model configu na json
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(config);
                // tworzymy i zapisujemy wszystko do configu
                System.IO.File.WriteAllText("C:\\SJ2Revive\\config.json", json);
            } else
            {
                if(File.Exists("C:\\SJ2Revive\\config.json"))
                {
                    // jezeli config istnieje nie ma potrzeby zapisywania go więc zglaszamy koniec funkcji
                    return;
                }
            }
        }
        //funkcja od wczytywania ustawień
        public static void ReadConfig()
        {
            if (!Directory.Exists("C:\\SJ2Revive\\"))
            {
                SaveConfig();
                // po utworzeniu configu wymagany jest restarta aby aplikacja nie sypala bledu
                Environment.Exit(1);
            } else
            {
                // odczytujemy zawartosc configu
                string jsonFromFile = System.IO.File.ReadAllText("C:\\SJ2Revive\\config.json");
                // deserializujemy zawartosc jego
                var configFromFile = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(jsonFromFile);
                // ustawiamy wartosc w aplikacji na ta w configu
                ConfigData.User = configFromFile.RandomUser;
            }
        }
    }
}
