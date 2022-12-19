using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MainAndroid.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("{login}/{password}")]
        public string getRole(string login, string password)
        {
            string stringconn = $"Data Source=LAPTOP-FPR118VN\\SQLEXPRESS;" +
                $"Initial Catalog=androidApp;Integrated Security=True;" +
                $"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                $"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string result = "err";

            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"select [role] from Users where [login] = '{login}' and [password] = '{password}'";
                var command = new SqlCommand(sql, conn);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetString(0).ToString();
                    if (result == "1")
                        result = "one";
                    else 
                        result = "two";
                }
            }
            catch
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
