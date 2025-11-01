using Bando_de_Dados_Elton.Models;
using Bando_de_Dados_Elton.Properties.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Bando_de_Dados_Elton.Controllers
{
    public class EquipeController : Controller
    {
        private readonly AppDbContext _context;

        public EquipeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Listar_Equipe()
        {
            var equipe = await _context.Equipe.FromSqlRaw("CALL ListarEquipe()").ToListAsync();
            return View(equipe);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir_Equipe(EquipeViewModel equipe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync("CALL InserirEquipe(@Nome, @Endereço, @Telefone, @Aniversário, @Numero_Titulo,@Seção,@Zona,@Local_Votação,@Potencial_votos_Pessoal,@Responsabilidades,@Atua_como_liderança,@Bairro_atuação,@Potencial_votos_como_Liderança)",
                    new MySqlParameter("@Nome", equipe.Nome),
                    new MySqlParameter("@Endereço", equipe.Endereço),
                    new MySqlParameter("@Telefone", equipe.Telefone),
                    new MySqlParameter("@Aniversário", equipe.Aniversário),
                    new MySqlParameter("@Numero_Titulo", equipe.Numero_Titulo),
                    new MySqlParameter("@Seção", equipe.Seção),
                    new MySqlParameter("@Zona", equipe.Zona),
                    new MySqlParameter("@Local_Votação", equipe.Local_Votação),
                    new MySqlParameter("@Potencial_votos_Pessoal", equipe.Potencial_votos_Pessoal),
                    new MySqlParameter("@Responsabilidades", equipe.Responsabilidades),
                    new MySqlParameter("@Atua_como_liderança", equipe.Atua_como_liderança),
                    new MySqlParameter("@Bairro_atuação", equipe.Bairro_atuação),
                    new MySqlParameter("@Potencial_votos_como_Liderança", equipe.Potencial_votos_como_Liderança)


                );
                    return RedirectToAction(nameof(Listar_Equipe));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    return StatusCode(500, "Ocorreu um erro ao tentar inserir o veículo. Por favor, tente novamente mais tarde.");
                }
            }
            return View(equipe);
        }

        public async Task<IActionResult> Alterar_Equipe(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound("Integrante não encontrado.");
            }
            return View(equipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar_Equipe(int id, EquipeViewModel equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Dados da equipe inválidos.");
            }

            if (id != equipe.Id_Equipe)
            {
                return BadRequest("ID da Equipe na URL não corresponde ao ID do Equipe.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Database.ExecuteSqlRawAsync(
                    "CALL EditarEquipe(@Id_Equipe, @Nome, @Endereço, @Telefone, @Aniversário, @Numero_Titulo,@Seção,@Zona,@Local_Votação,@Potencial_votos_Pessoal,@Responsabilidades,@Atua_como_liderança,@Bairro_atuação,@Potencial_votos_como_Liderança)",
                    new MySqlParameter("@Id_Equipe", equipe.Id_Equipe),
                    new MySqlParameter("@Nome", equipe.Nome),
                    new MySqlParameter("@Endereço", equipe.Endereço),
                    new MySqlParameter("@Telefone", equipe.Telefone),
                    new MySqlParameter("@Aniversário", equipe.Aniversário),
                    new MySqlParameter("@Numero_Titulo", equipe.Numero_Titulo),
                    new MySqlParameter("@Seção", equipe.Seção),
                    new MySqlParameter("@Zona", equipe.Zona),
                    new MySqlParameter("@Local_Votação", equipe.Local_Votação),
                    new MySqlParameter("@Potencial_votos_Pessoal", equipe.Potencial_votos_Pessoal),
                    new MySqlParameter("@Responsabilidades", equipe.Responsabilidades),
                     new MySqlParameter("@Atua_como_liderança", equipe.Atua_como_liderança),
                    new MySqlParameter("@Bairro_atuação", equipe.Bairro_atuação),
                    new MySqlParameter("@Potencial_votos_como_Liderança", equipe.Potencial_votos_como_Liderança)

                    );
                    return RedirectToAction(nameof(Listar_Equipe));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    return StatusCode(500, "Ocorreu um erro ao tentar atualizar a Equipe. Por favor, tente novamente mais tarde.");
                }
            }
            return View(equipe);
        }

        public async Task<IActionResult> Excluir_Equipe(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        [HttpPost, ActionName("Excluir_Equipe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir_EquipeConfirmado(int id)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL ExcluirEquipe(@Id)", new MySqlParameter("@Id", id));
                return RedirectToAction(nameof(Listar_Equipe));
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Ocorreu um erro ao tentar excluir a Equipe. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
