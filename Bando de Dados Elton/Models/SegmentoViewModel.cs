namespace Bando_de_Dados_Elton.Models
{
    public class SegmentoViewModel
    {      
        public int Id_Segmento { get; set; }
        public string Nome_do_Segmento { get; set; }
        public string Endereço_do_Segmento { get; set; }
        public string Liderança_Elton { get; set; }
        public string Endereço_Liderança { get; set; }
        public string Telefone_Liderança { get; set; }
        public string Aniversário { get; set; }
        public int Numero_Titulo { get; set; }
        public int Seção { get; set; }
        public int Zona { get; set; }
        public string Local_Votação { get; set; }
        public string Região_Atuação { get; set; }
        public int Potencial_votos { get; set; }
        public string Eventos { get; set; }
        public string Histórico_de_Serviços { get; set; }

        //public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
