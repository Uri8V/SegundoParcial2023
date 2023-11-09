using SegundoParcial2023.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UrielVergaraPOO.Datos
{
    public class Estacionamiento
    {
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        private Estacionamiento()
        {
           vehiculos= new List<Vehiculo>();
        }
        public Estacionamiento(string nombre, int EspacioDisponible):this()
        {
            this.nombre=nombre;
            this.espacioDisponible=EspacioDisponible;
        }
        public List<Vehiculo> GetVehiculos()
        {
            return vehiculos;
        }

        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb= new StringBuilder();
            foreach (var item in e.vehiculos)
            {
                sb.AppendLine(item.ImprimirTicket());
            }
            sb.AppendLine($"Espacios Disponibles: {e.espacioDisponible}");
            return sb.ToString();
        }
        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            foreach (var item in e.vehiculos)
            {
                if (item.Patente == v.Patente)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Estacionamiento estacionamiento, Vehiculo v)
        {
           return !(estacionamiento == v);
        }
        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if (e != v)
            {
                if (v.ValidadorPatente(v.Patente))
                {
                    if (e.espacioDisponible > e.vehiculos.Count)
                    {
                        e.vehiculos.Add(v);
                        e.espacioDisponible--;
                    }
                  
                }
            
            }
            return e;
        }

        public static bool operator -(Estacionamiento e, Vehiculo v)
        {
            if (e == v)
            {
                e.vehiculos.Remove(v);
                return true;
            }
            Console.WriteLine("El vehiculo no es parte del estacionamiento");
            return false;
        }

        public string GetEstadia(Vehiculo v)
        {
            StringBuilder sb = new StringBuilder();
            DateTime horaSalida= DateTime.Now;
            TimeSpan estadia = horaSalida.Subtract(v.ingreso);
            int horas = estadia.Hours;
            int minutos= estadia.Minutes;
            int sec = estadia.Seconds;
            int total=(int)estadia.TotalHours;
            if (v.GetType() == typeof(Moto))
            {
                total *= ((Moto)v).ValorPorHora;
            }
            else if (v.GetType() == typeof(PickUp))
            {
                total *= ((PickUp)v).ValorPorHora;
            }
            else if (v.GetType() == typeof(Automovil))
            {
                total *= ((Automovil)v).ValorPorHora;
            }
            sb.AppendLine($"Patente:{v.Patente}");
            sb.AppendLine($"Fecha:{v.ingreso.ToShortDateString()}");
            sb.AppendLine($"Hora Ingreso:{v.ingreso.ToShortTimeString()}");
            sb.AppendLine($"Hora Egreso:{estadia.ToString()}");
            sb.AppendLine($"Estadia{estadia.TotalHours}");
            sb.AppendLine($"Costo:{total}");
            return sb.ToString();
        }
    }
}
