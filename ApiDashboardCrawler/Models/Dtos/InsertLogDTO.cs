using System.ComponentModel.DataAnnotations;

namespace ApiDashboardCrawler.Models.Dtos
{
    public class InsertLogDTO
    {

        [Required(ErrorMessage = "Insira o código do robô")]
        public int Codigorobo { get; set; }
        [Required(ErrorMessage = "Insira o nome do dev")]

        public string Nomedev { get; set; } = null!;
        [Required(ErrorMessage = "Insira o Nome do produto")]

        public string Nomeproduto { get; set; } = null!;
        [Required(ErrorMessage = "Insira o valor do produto no mercado livre")]

        public double Valor1 { get; set; }
        [Required(ErrorMessage = "Insira o valor do produto na magazine luiza")]

        public double Valor2 { get; set; }
        [Required(ErrorMessage = "Insira o valor da economia")]

        public double Economia { get; set; }
    }
}
