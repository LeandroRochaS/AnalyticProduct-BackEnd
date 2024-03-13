using System;
using System.Collections.Generic;

namespace ApiDashboardCrawler.models
{
    public partial class Logbenchdashboard
    {
        public int Id { get; set; }
        public int Codigorobo { get; set; }
        public string Nomedev { get; set; } = null!;
        public DateTime Dataatualizacao { get; set; }
        public string Nomeproduto { get; set; } = null!;
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public double Economia { get; set; }
    }
}
