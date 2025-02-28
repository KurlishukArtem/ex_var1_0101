using Microsoft.EntityFrameworkCore;

namespace ex_var1.Contexts.Config
{
    public class Config
    {
        public static readonly string connect = "";
        public MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8,0,11));
    }
}
