namespace Bando_de_Dados_Elton.Models
{
    public class CondominioViewModel
    {       
        public int Id_Condominio { get; set; }
        public string Nome_do_Condomínio { get; set; }
        public string Endereço_do_Condomínio { get; set; }
        public string Sindico { get; set; }
        public string Liderança_Elton { get; set; }
        public string Endereço_da_Liderança { get; set; }
        public string Telefone_Liderança { get; set; }
        public DateOnly Aniversário { get; set; }
        public int Unidades_Habitacionais { get; set; }
        public string Histórico_de_Serviços { get; set; }

        //public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
