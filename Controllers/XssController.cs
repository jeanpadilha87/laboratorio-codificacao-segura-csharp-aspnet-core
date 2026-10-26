using Microsoft.AspNetCore.Mvc;
namespace PocCodificacaoSegura.Controllers;
public class XssController : Controller { [HttpGet] public IActionResult Index()=>View(); }