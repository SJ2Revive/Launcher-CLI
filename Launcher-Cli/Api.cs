using System;
using Launcher_Cli.Structs;
using Launcher_Cli.Utils;
using Newtonsoft.Json;

namespace Launcher_Cli
{
    /*
     * To jest napewno do zrobienia ale nie wiem czy nie zostanie to dopiero
     * dodane w pelnej wersji(nie chodzi mi o pelna wersje lite czy cos)
     * 
     * Autor: ZRD
     * 28.09.2023
     * tutaj znajdą się różne skrypty do interakcji z api sj2r np. api od modow, logowania itd
     */
    public class Api
    {
        // narazie jeszcze nie mamy samej czesci backendu zrobionej wiec narazie nie dziala to wszystko (zabiore sie za to kiedy bede mial checi i czas)
        public static string GetCurrentActiveUsers()
        {
            // todo
            return Utils.Utils.client.DownloadString("https://sj2r.zndev.xyz/api/v1/GetUsersConnected.php");
        }
        public static void UserConnected()
        {
            // mozliwe ze kiedys upublicznie ta czesc backendu aby kod zrodlowy caly byl a nie sam launcher
            Utils.Utils.client.DownloadString("https://sj2r.zndev.xyz/api/v1/UserConnected.php?username="+ConfigData.User);
        }
        public static void UserDisconnected()
        {
            // mozliwe ze kiedys upublicznie ta czesc backendu aby kod zrodlowy caly byl a nie sam launcher
            Utils.Utils.client.DownloadString("https://sj2r.zndev.xyz/api/v1/UserDisconnected.php?username=" + ConfigData.User);
        }
        public static Object[] GetMods() 
        {
            var res = Utils.Utils.client.DownloadString("https://sj2r.zndev.xyz/api/v1/GetMods.php"); // oczywiscie ze api nawet nadal nie jest zrobione wiec to url moze sie zmienic
            return JsonConvert.DeserializeObject<Mod[]>(res);
        }
    }
}
