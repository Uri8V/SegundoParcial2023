using SegundoParcial2023.Entidades;
using System.Security.Cryptography;
using UrielVergaraPOO.Datos;

namespace SegundoParcial2023.Consola
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Estacionamiento e = new Estacionamiento("Cachito", 10);
			Console.WriteLine("Motos");
			Vehiculo v = new Moto("ASD123", 75, 4);
			Console.WriteLine(v.ConsultarDatos());
			Moto moto = new Moto("ASD123", 175);
			if (v == moto)
			{
				Console.WriteLine(moto.ConsultarDatos());
			}
			
			Moto moto1 = new Moto("QWE 312", 175, 4, 35);
			Console.WriteLine(moto1.ConsultarDatos());
			Console.WriteLine("PickUp");
			PickUp p1 = new PickUp("TYR 753", "MODEL A");
			Console.WriteLine(p1.ConsultarDatos());
			PickUp p2 = new PickUp("TYR 753", "MODEL A");
			if (p1 != p2) { 
			Console.WriteLine(p2.ConsultarDatos()); 
			}
            Console.WriteLine("Automoviles");
			Automovil a = new Automovil("POI 952", ConsoleColor.Red);
            Console.WriteLine(a.ConsultarDatos());
			Automovil a2 = new Automovil("MNB 651", ConsoleColor.DarkCyan, 23);
            Console.WriteLine(a2.ConsultarDatos());
            Console.WriteLine("-------------------");
            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
			e += moto;
			e += p1;
			e += a;
			e += a2;
            Console.WriteLine((string)e);

            Console.ReadLine();
        }
	}
}