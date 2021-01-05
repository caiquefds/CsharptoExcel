using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=teste;Uid=Programa;Pwd=piscinagua@17;");
            try {
                connection.Open();
                Console.WriteLine("Aberto");
                    
                    
                    }
            catch { Console.WriteLine("Erro"); }
         


        }
    }
}
