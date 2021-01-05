using System;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using Spectre.Console;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection connection1 = new MySqlConnection("Server = Servidor;Port= 3306;Database = sysadmdata;Uid = newuser;Pwd = 32568021;");
            MySqlConnection connection2 = new MySqlConnection("Server = localhost;Port= 3306;Uid = qtdmin;Pwd = 32568021;");
            connection1.Open();
            connection2.Open();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT*FROM produto", connection1);
            DataTable Tabela;
            Tabela = new DataTable();
            mySqlDataAdapter.Fill(Tabela);

            MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter("SELECT * FROM quantidade_minima.produtos", connection2);
            DataTable Tabela2;
            Tabela2 = new DataTable();
            mySqlDataAdapter2.Fill(Tabela2);
           
           


            var table = new Table();
            table.AddColumn("SKU");
            table.AddColumn("Descrição");
            table.AddColumn("Quantidade Mínima");
            table.AddColumn("Estoque");
            table.Border = TableBorder.Rounded;

           
            foreach (DataRow row in Tabela2.Rows) {
                  foreach (DataRow row2 in Tabela.Rows) {

                    if (row[0].ToString() == row2[0].ToString()) 
                    {
                        int minimo = Convert.ToInt32(row[2]);
                        int real = Convert.ToInt32(row2[4]);
                       

                        if (real <= minimo) 
                        { 
                          table.AddRow("[yellow]"+row[0].ToString()+"[/]",row[1].ToString(), row[2].ToString(), real.ToString());

                        }
                        


                    }
                
                
                
                
                
                
                }
               
               
                
            
            };

           
            table.Centered();
            AnsiConsole.Render(table);
            Console.ReadKey();
            
        }
    }
    
}
