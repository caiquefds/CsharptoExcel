using System;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;



namespace AtualizaTodosOsProdutos
{
    class Program
    {
        static void Main(string[] args)
        {






            MySqlConnection connection1 = new MySqlConnection("Server = Servidor;Port= 3306;Database = sysadmdata;Uid = newuser;Pwd = 32568021;");
            connection1.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT*FROM produto", connection1);
            System.Data.DataTable Tabela;
            Tabela = new System.Data.DataTable();
            mySqlDataAdapter.Fill(Tabela);
            Console.WriteLine(connection1.State);







            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(Tabela, "Tabela para contagem");
                workbook.ShowGridLines = true;
                
                workbook.SaveAs($@"F:\Estoque\Todos os Produtos.xlsx");
            }


            Console.WriteLine("Foi");




        }
    }
}

