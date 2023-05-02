using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMae tela = new TelaMae();

            int chances = 0;

            while (chances != 3)
            {
                tela.MenuPrincipal();

                chances++;
            }

            Console.ReadKey();
        }
    }
}
