using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaPrimerServicioWCF
{
    internal class MetodosVariosClass : IMetodosVariosContract
    {
        public int GetNumeroDoble(int numero)
        {
            return numero * 2;
        }

        public string GetSaludo(string nombre)
        {
            return "Mi primer super Servicio!!! " + nombre;
        }

        public string MetodoInvisible(int numero)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTablaMultiplicar(int numero)
        {
            List<int> tabla = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                int resultado = numero * i;
                tabla.Add(resultado);
            }
            return tabla;
        }
    }
}
