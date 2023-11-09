using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class PickUp : Vehiculo
    {
        private string modelo;
        private static int valorHora;
        public int ValorPorHora { get { return valorHora; } set { valorHora = value; } }
        static PickUp()
        {
            valorHora = 70;  
        }
        public PickUp(string patente, string Modelo) : base(patente)
        {
            modelo = Modelo;
        }
        public PickUp(string patente,string modelo, int ValorHora):this(patente,modelo)
        {
          ValorPorHora = ValorHora;
        }
        public override string ImprimirTicket()
        {
            return $"Patente: {Patente}, Horas de Ingreso y Egreso:{base.ImprimirTicket()}, Valor Por Hora:{valorHora}";
        }

        public override string ConsultarDatos()
        {
            return $"{Patente},Valor Por Hora:{ValorPorHora}, Modelo:{modelo}, Tipo Vehiculo:{GetType().Name}";
        }
    }
}
