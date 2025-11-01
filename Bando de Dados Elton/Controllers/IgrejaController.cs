using Bando_de_Dados_Elton.Models;
using Bando_de_Dados_Elton.Properties.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


namespace Bando_de_Dados_Elton.Controllers
{
    public class IgrejaController : Controller
    { 
        
            private readonly AppDbContext _context;

            public IgrejaController(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Listar_Igreja()
            {
                var igreja = await _context.Igreja.FromSqlRaw("CALL ListarIgreja()").ToListAsync();
                return View(igreja);
            }
        public async Task<IActionResult> Inserir_Igreja(IgrejaViewModel igreja)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("CALL InserirIgreja(@Nome_Igreja, @Endereço_Igreja, @Pastor_Presidente, @Telefone_Pastores,@Quantidade_membros,@Eventos,@Liderança_de_Elton,@Telefone_Liderança,@Histórico_de_Serviço)",
                    new MySqlParameter("@Nome", igreja.Nome_Igreja),
                    new MySqlParameter("@Endereço", igreja.Endereço_Igreja),
                    new MySqlParameter("@Telefone", igreja.Pastor_Presidente),
                    new MySqlParameter("@Aniversário", igreja.Telefone_Pastores),
                    new MySqlParameter("@Numero_Titulo", igreja.Quantidade_membros),
                    new MySqlParameter("@Seção", igreja.Eventos),
                    new MySqlParameter("@Zona", igreja.Liderança_de_Elton),
                    new MySqlParameter("@Local_Votação", igreja.Telefone_Liderança),
                    new MySqlParameter("@Potencial_votos_Pessoal", igreja.Histórico_de_Serviços)                   

                );
                    return RedirectToAction(nameof(Listar_Igreja));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    return StatusCode(500, "Ocorreu um erro ao tentar inserir o veículo. Por favor, tente novamente mais tarde.");
                }
            }
            return View(igreja);
        }
    }
}
