using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
namespace PocCodificacaoSegura.Controllers;
public class SqlInjectionController : Controller {
 [HttpGet] public IActionResult Index()=>View();
 [HttpPost, ValidateAntiForgeryToken]
 public IActionResult Index(string usuario,string senha) {
  using var c=new SqliteConnection("Data Source=:memory:"); c.Open();
  using(var seed=c.CreateCommand()){seed.CommandText="CREATE TABLE Usuarios (Usuario TEXT, Senha TEXT); INSERT INTO Usuarios VALUES ('joao','demo123');";seed.ExecuteNonQuery();}
  bool vuln; using(var q=c.CreateCommand()){q.CommandText=$"SELECT COUNT(*) FROM Usuarios WHERE Usuario = '{usuario}' AND Senha = '{senha}'";vuln=Convert.ToInt32(q.ExecuteScalar())>0;}
  bool safe; using(var q=c.CreateCommand()){q.CommandText="SELECT COUNT(*) FROM Usuarios WHERE Usuario=$usuario AND Senha=$senha";q.Parameters.AddWithValue("$usuario",usuario??"");q.Parameters.AddWithValue("$senha",senha??"");safe=Convert.ToInt32(q.ExecuteScalar())>0;}
  ViewBag.Usuario=usuario;ViewBag.Senha=senha;ViewBag.Vulneravel=vuln;ViewBag.Seguro=safe;return View();
 }
}