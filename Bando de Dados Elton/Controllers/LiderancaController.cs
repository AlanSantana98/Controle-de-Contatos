using Bando_de_Dados_Elton.Properties.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bando_de_Dados_Elton.Controllers
{
    public class LiderancaController : Controller
    {
        private readonly AppDbContext _context;

        public LiderancaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Listar_Lideranca()
        {
            var lideranca = await _context.Lideranca.FromSqlRaw("CALL ListarLideranca()").ToListAsync();
            return View(lideranca);
        }
    }
}
