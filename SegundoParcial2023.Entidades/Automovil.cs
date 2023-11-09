using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Automovil:Vehiculo
    {
        private static int  valorPorHora;
        private ConsoleColor color;
        public int ValorPorHora { get { return valorPorHora; } set { valorPorHora = value; } }

        static Automovil()
        {
            valorPorHora = 50;
        }

        public Automovil(string patente, ConsoleColor color) : base(patente)
        {
            this.color = color;
        }

        public Automovil(string patente, ConsoleColor color, int ValorPorHora):this(patente,color)
        {
            this.ValorPorHora = ValorPorHora;
        }
        public override string ImprimirTicket()
        {
            return $"Patente: {Patente}, Horas de Ingreso y Egreso:{base.ImprimirTicket()}, Valor Por Hora:{valorPorHora}";
        }
        public override string ConsultarDatos()
        {
           return $"{Patente}, Color:{color}, ValorPorHora: {valorPorHora}";
        }
    }
}
