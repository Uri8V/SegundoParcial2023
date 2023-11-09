using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private static short ruedas;
        private static int valorHOra;
        public int ValorPorHora { get { return valorHOra; } set { valorHOra = value; } }
        static Moto()
        {
            valorHOra = 30;
            ruedas = 2;
        }
        public Moto(string patente, int cilindrada) : base(patente)
        {
            this.cilindrada=cilindrada;
        }
        public Moto(string patente, int cilindrada, short Ruedas):this(patente,cilindrada)
        {
            ruedas = Ruedas;
        }
        public Moto(string patente, int cilindrada, short ruedas, int ValorPorHora) : this(patente, cilindrada, ruedas)
        {
            this.ValorPorHora= ValorPorHora;
        }
        public override string ImprimirTicket()
        {
            return $"Patente: {Patente}, Horas de Ingreso y Egreso:{base.ImprimirTicket()}, Valor Por Hora:{valorHOra}";
        }
        public override string ConsultarDatos()
        {
            return $"{Patente}, Ruedas:{ruedas}, ValorPorHora:{valorHOra},Cilindrada:{cilindrada}, Tipo{GetType().Name}";
        }
    }
}
