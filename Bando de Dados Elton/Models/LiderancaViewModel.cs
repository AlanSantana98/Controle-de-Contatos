namespace Bando_de_Dados_Elton.Models
{
    public class LiderancaViewModel
    {      
        public int Id_Liderança { get; set; }
        public string Nome_da_Liderança { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public string Aniversario { get; set; }
        public string Função { get; set; }
        public long Numero_Titulo { get; set; }
        public int Seção { get; set; }
        public int Zona { get; set; }
        public string Local_votação { get; set; }
        public string Região_de_Atuação { get; set; }
        public int Potencial_de_Votos { get; set; }
        public string Histórico_de_Serviços { get; set; }

        //public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
