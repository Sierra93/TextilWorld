using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextilWorld.Data {
    /// <summary>
    /// Класс описывает строку подключения.
    /// </summary>
    public class Connection {
        public static string GetConnectionString() {
            string connectionString = "Server=skyhorizen.ru,1433; Initial Catalog=u0772479_textildb; Persist Security Info=False; User ID=u0772479_admin; Password=K3sxb30*; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
            return connectionString;
        }
    }
}
