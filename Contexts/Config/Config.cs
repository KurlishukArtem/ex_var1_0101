using Microsoft.EntityFrameworkCore;

namespace ex_var1.Contexts.Config
{
    public class Config
    {
        public static readonly string connect = "server=127.0.0.1;port=3307;database=pizza_db;uid=root;pwd=;";
        public  static MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8,0,11));
    }
}
