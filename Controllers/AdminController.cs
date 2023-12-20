using Application_GS_ecole.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Application_GS_ecole.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "Data Source=KHALIL\\SQLEXPRESS;Initial Catalog=MvcecoleDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;";
        }

        [HttpPost]
        public IActionResult Verify(Admin admin)
        {
                ConnectionString();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Admins WHERE Login=@Login AND MotDePasse=@MotDePasse";
                cmd.Parameters.AddWithValue("@Login", admin.Login);
                cmd.Parameters.AddWithValue("@MotDePasse", admin.MotDePasse);
                rd = cmd.ExecuteReader();

            if (rd.Read())
            {
               // HttpContext.Session.SetString("AdminLoggedIn", "true");
                con.Close();
                return Redirect("~/Home/Index");
            }
            else
                {
                    con.Close();
                    return View("error");
                }
            }
         
        
    }

}
