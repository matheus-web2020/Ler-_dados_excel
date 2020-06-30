using System;
using System.Collections.Generic;
using System.IO;

namespace Aula28_POO
{
    public class Produto
    {
        public int Codigo { get; set; } 

      public string Nome { get; set; }

      public float Preco { get; set; } 

      private const string PATH = "Database/produto.csv";

      public Produto(){

          

          string Pasta = PATH.Split('/')[0];

          if(!Directory.Exists(Pasta)){
              Directory.CreateDirectory(Pasta);
          }

          if(File.Exists(PATH)){
             File.Create(PATH).Close(); 
              }
          }
      
/// <summary>
/// Cadastra o produto
/// </summary>
/// <param name="prod"></param>
      public void Cadastrar(Produto prod){
        var linha = new string[]  { PrepararLinha(prod)};


          File.AppendAllLines(PATH, linha);


      }
/// <summary>
/// Lê o CSV
/// </summary>
/// <returns></returns>
      public List<Produto> Ler(){

      //Criar lista de Produtos
      List<Produto> produtos = new List<Produto>();

      // Transformas as linhas em array de strings
      string[] linhas = File.ReadAllLines(PATH);

      //Varremos o array de strings
      foreach(var linha in linhas){
          //Quebramos cada linha em partes
          string[] dados = linha.Split(";");

          //Tratamos os dadso e adicionamos em um novo produto
          Produto prod = new Produto();
          prod.Codigo = Int32.Parse(Separar(dados[0]));
          prod.Nome = Separar(dados[1]);
          prod.Preco = float.Parse(Separar(dados[2]));

          produtos.Add(prod);

      }

      return produtos;
      }
      /// <summary>
      /// Separa os dados
      /// </summary>
      /// <param name="_coluna"></param>
      /// <returns></returns>
      private string Separar(string _coluna){
          return _coluna.Split("=")[1];
      }

/// <summary>
/// Retorna texto
/// </summary>
/// <param name="p"></param>
/// <returns></returns>
      public string PrepararLinha(Produto p){
          return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
      }
    }
}