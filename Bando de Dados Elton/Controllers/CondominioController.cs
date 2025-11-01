using Bando_de_Dados_Elton.Models;
using Bando_de_Dados_Elton.Properties.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Bando_de_Dados_Elton.Controllers
{
    public class CondominioController : Controller
    {
        private readonly AppDbContext _context;

        public CondominioController(AppDbContext context)
        {
            _context = context;
        }    
        public async Task<IActionResult> Listar_Condominio()
        {
            var condominio = await _context.Condominio.FromSqlRaw("CALL ListarCondominio()").ToListAsync();
            return View(condominio);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir_Condominio(CondominioViewModel condominio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        "CALL InserirCondominio(@Nome_do_Condomínio, @Endereço_do_Condomínio, @Liderança_Elton, @Endereço_da_Liderança,@Sindico ,@Telefone_Liderança, @Aniversário, @Unidades_Habitacionais, @Histórico_de_Serviços)",
                        new MySqlParameter("@Nome_do_Condomínio", condominio.Nome_do_Condomínio),
                        new MySqlParameter("@Endereço_do_Condomínio", condominio.Endereço_do_Condomínio),
                        new MySqlParameter("@Sindico", condominio.Sindico),
                        new MySqlParameter("@Liderança_Elton", condominio.Liderança_Elton),
                        new MySqlParameter("@Endereço_da_Liderança", condominio.Endereço_da_Liderança),
                        new MySqlParameter("@Telefone_Liderança", condominio.Telefone_Liderança),
                        new MySqlParameter("@Aniversário", condominio.Aniversário),
                        new MySqlParameter("@Unidades_Habitacionais", condominio.Unidades_Habitacionais),
                        new MySqlParameter("@Histórico_de_Serviços", condominio.Histórico_de_Serviços)
                    );
                    return RedirectToAction(nameof(Listar_Condominio));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    return StatusCode(500, "Ocorreu um erro ao tentar inserir o Condominio.");
                }
            }
            return View(condominio);
        }

    }
}
