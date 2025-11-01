using Bando_de_Dados_Elton.Properties.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bando_de_Dados_Elton.Controllers
{
    public class SegmentoController : Controller
    {
        private readonly AppDbContext _context;

        public SegmentoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Listar_Segmento()
        {
            var segmento = await _context.Segmento.FromSqlRaw("CALL ListarSegmento()").ToListAsync();
            return View(segmento);
        }
    }
}
