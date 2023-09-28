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
        public static string GetCurrentActiveUsers()
        {
            // todo
            return string.Empty;
        }
        public static Object[] GetMods() 
        {
            var res = Utils.Utils.client.DownloadString("https://sj2r.zndev.xyz/api/v1/GetMods.php"); // oczywiscie ze api nawet nadal nie jest zrobione wiec to url moze sie zmienic
            return JsonConvert.DeserializeObject<Mod[]>(res);
        }
    }
}
