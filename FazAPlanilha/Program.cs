using System;
using MySql.Data.MySqlClient;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Collections.Generic;

namespace FazAPlanilha
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



            List<int> Lista = new List<int>();
            DataTable TabelaExcel = new DataTable();
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());

            Console.WriteLine("Insira o Código dos Produtos:");


            CriarTabela();




            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(TabelaExcel, "Tabela para contagem");
                worksheet.Cell("A1").Value = "SKU";
                worksheet.Cell("B1").Value = "Descrição";
                worksheet.Cell("C1").Value = "Fornecedor";
                worksheet.Cell("D1").Value = "Qtd";
                worksheet.Cell("E1").Value = "Loja";
                worksheet.Cell("F1").Value = "Requisção";
                worksheet.Cell("G1").Value = "Estoque";
                workbook.SaveAs($@"F:\Estoque\Contagem\Tabela de Contagem {DateTime.Today.ToString("dd.MM.yyyy")}.xlsx");
            }

            


            void CriarTabela()
            {


                string[] SKU = Console.ReadLine().Split(",");

                for (int i = 0; SKU.Length > i; i++)
                {
                                 
                   
                    Lista.Add(Convert.ToInt32(SKU[i]));
                   
                }






                foreach (int Produto in Lista)
                {


                    foreach (DataRow data in Tabela.Rows)
                    {

                        if (Produto == Convert.ToInt32(data[0]))
                        {


                            TabelaExcel.Rows.Add(data[0],data[1], data[2], data[4]);


                        }

                      






                    }








                }










            }




        }
    }
}

            










        






