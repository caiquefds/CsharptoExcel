using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Atalhos_do_Estoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Data.DataTable Tabela;
        DataTable TabelaExcel = new DataTable();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            List<int> Lista = new List<int>();
           
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());
            TabelaExcel.Columns.Add(new DataColumn());

            

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

               
                string[] SKU = textBox1.Text.Split(','); 

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


                            TabelaExcel.Rows.Add(data[0], data[1], data[2], data[4]);


                        }








                    }








                }










            }










        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(Tabela, "Tabela para contagem");
                workbook.ShowGridLines = true;

                workbook.SaveAs($@"F:\Estoque\Todos os Produtos.xlsx");
            }


         

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection connection1 = new MySqlConnection("Server = Servidor;Port= 3306;Database = sysadmdata;Uid = newuser;Pwd = 32568021;");
            connection1.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT*FROM produto", connection1);
            Tabela = new System.Data.DataTable();
            mySqlDataAdapter.Fill(Tabela);
            
        }
    }
}
