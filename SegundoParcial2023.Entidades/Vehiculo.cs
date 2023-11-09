using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public abstract class Vehiculo
    {
        public DateTime ingreso;
        private string patente;
        public string Patente { get { return patente; } set { patente = value; } }
        public Vehiculo(string patente)
        {
            Patente = patente;
            ingreso = DateTime.Now.AddHours(-3);
        }
        public abstract string ConsultarDatos();
        public override bool Equals(object? obj)
        {
            Vehiculo? vehiculo = obj as Vehiculo;
            if (vehiculo == null || this.Patente != vehiculo.Patente)
            {
                return false;
            }
            return true;
        }
        public virtual string ImprimirTicket()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine ($"{ToString()}");
            sb.AppendLine($"Fecha:{ingreso.ToShortDateString()}");
            sb.AppendLine($"Hora:{ingreso.ToShortTimeString()}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return $"Patente{patente}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vehiculo v, Vehiculo v2)
        {
            if (v.patente == v2.patente)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Vehiculo vehiculo, Vehiculo v)
        {
            return !(vehiculo == v);    
        }
        public bool ValidadorPatente(string patente)
        {
            return VerificarFormato(patente);
        }
        private  bool VerificarFormato(string s)
        {
            if (s == null || (s.Length != 7 && s.Length != 9))
            {
                return false;
            }
            if (s.Length == 9)
            {
                return ValidadorPatenteNueva(s);
            }
            else
            {
                return ValidadorPatenteVieja(s);
            }

        }
        private  bool ValidadorPatenteNueva(string patente) //AA 111 AA
        {
            var array = patente.Split(' ');
            var parteAlfabetica = array[0];
            var parteNumerica = array[1];
            var parteAlfa = array[2];

            return validarParteAlfabetica(parteAlfabetica) && ValidarParNumerica(parteNumerica) && validarParteAlfabetica(parteAlfa);
        }
        private  bool ValidadorPatenteVieja(string patente)
        {
            var array = patente.Split(' ');
            var parteAlfabetica = array[0];
            var parteNumerica = array[1];

            return validarParteAlfabetica(parteAlfabetica) && ValidarParNumerica(parteNumerica);
        }

        private  bool ValidarParNumerica(string parteNumerica)
        {
            foreach (var item in parteNumerica)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }

            }
            return true;
        }

        private  bool validarParteAlfabetica(string parteAlfabetica)
        {
            foreach (var item in parteAlfabetica)
            {
                if (!char.IsLetter(item))
                {
                    return false;
                }

            }
            return true;
        }

        public  string GetTipo(string s)
        {
            if (s == null)
            {
                return "Patente no ingresada";
            }
            else if (s.Length == 7)
            {
                return "La patente tiene un formato viejo";
            }
            else if (s.Length == 9)
            {
                return "La patente tiene un formato nuevo";
            }
            else
            {
                return "Formato no valido";
            }
        }
    }
}
