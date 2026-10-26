using Microsoft.AspNetCore.Mvc;
namespace PocCodificacaoSegura.Controllers;
public class CsrfController:Controller {
 [HttpGet] public IActionResult Index(){ViewBag.Email="joao@exemplo.test";return View();}
 [HttpPost,ValidateAntiForgeryToken] public IActionResult AlterarEmail(string email){ViewBag.Email=email;ViewBag.Resultado="Requisição aceita: token antifalsificação válido.";return View("Index");}
 // Rota de teste não altera dados; rejeita deliberadamente tentativa sem token.
 [HttpPost,IgnoreAntiforgeryToken] public IActionResult SimularSemToken()=>BadRequest("Simulação rejeitada; nenhum dado foi alterado.");
}