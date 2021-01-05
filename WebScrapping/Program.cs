using System;
using System.Net;

namespace WebScrapping
{
    class Program
    {
        static void Main(string[] args)
        {
           
            WebClient Cliente = new WebClient();
           string Pagina = Cliente.DownloadString("https://wol.jw.org/pt/wol/dt/r5/lp-t/2020/11/4");
            

         

        }
    }
}
