using System.Web;

namespace BetSystem.Common.Constants
{
    public class Resource
    {
        public static readonly string DbSeedPath = HttpContext.Current.Server.MapPath("~/App_Data/dbSeed.json");
    }
}
