namespace Bando_de_Dados_Elton.Models
{
    public class IgrejaViewModel
    {       
        public int Id_Igreja { get; set; }
        public string Nome_Igreja { get; set; }
        public string Endereço_Igreja { get; set; }
        public string Pastor_Presidente { get; set; }
        public string Pastores_Auxiliares { get; set; }
        public string Telefone_Pastores { get; set; }
        public int Quantidade_membros { get; set; }
        public string Eventos { get; set; }
        public string Liderança_de_Elton { get; set; }
        public string Telefone_Liderança { get; set; }
        public string Histórico_de_Serviços { get; set; }

        //public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
