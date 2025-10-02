using System;

namespace Ejercicio1.Models
{
    public class Cuenta : IComparable
    {
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public double Importe { get; set; }

        public Cuenta(string nombre, int dni, double importe) 
        {
            Nombre = nombre;
            DNI = dni;
            Importe = importe;
        }

        public override string ToString()
        {
            return $"Cuenta de {Nombre} \r\n dni {DNI} \r\n Importe: {Importe}";
        }

        public int CompareTo(object obj)
        {
            Cuenta cuenta = obj as Cuenta;

            if (cuenta != null)
            {
                return this.DNI.CompareTo(cuenta.DNI);
            }
            return -1 ;
        }
    }
}
