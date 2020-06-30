using System;
using System.Collections.Generic;

namespace Aula28_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "Guitarra Gibson";
            p1.Preco = 4500f;
            

            p1.Cadastrar(p1);

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            foreach(Produto item in lista){
                Console.WriteLine($"{item.Preco} - {item.Nome}");
            }
        }
    }
}
