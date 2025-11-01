namespace Bando_de_Dados_Elton.Models
{
    public class EquipeViewModel
    {    
        public int Id_Equipe { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public string Aniversário { get; set; }
        public string Numero_Titulo { get; set; }
        public string Seção { get; set; }
        public string Zona { get; set; }
        public string Local_Votação { get; set; }
        public int Potencial_votos_Pessoal { get; set; }
        public string Responsabilidades { get; set; }
        public bool Atua_como_liderança { get; set; }
        public string Bairro_atuação { get; set; }
        public int Potencial_votos_como_Liderança { get; set; }


        //public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
