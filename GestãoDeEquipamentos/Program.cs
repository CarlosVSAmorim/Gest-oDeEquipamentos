using System;
using GestãoDeEquipamentos;

namespace GestãoDeEquipamentos
{
    internal class Program
    {
        private static MenuEquipamentos menuEquipamentos = new();
        private static MenuChamados menuChamados = new();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Equipamentos\n2. Chamados\n0. Sair");
                switch (Console.ReadLine())
                {
                    case "1": 
                        menuEquipamentos.ExibirMenu();
                        break;
                    case "2": 
                        menuChamados.ExibirMenu();
                        break;
                    case "0": 
                        return;
                    default: 
                        Console.WriteLine("Opção inválida."); 
                        break;
                }
            }
        }
    }
}