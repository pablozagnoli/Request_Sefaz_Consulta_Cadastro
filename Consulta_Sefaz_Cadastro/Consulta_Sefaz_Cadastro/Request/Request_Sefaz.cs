using Consulta_Sefaz_Cadastro.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;


namespace Consulta_Sefaz_Cadastro.Request
{
    class Request_Sefaz
    {
        public static void Reques_Sergipe()
        {
            try
            {
                var vClient = new HttpClient();
                vClient.BaseAddress = new Uri("https://security.sefaz.se.gov.br");

                var vHeader = new Model_Request_Header();
                vHeader.AppName = " ";
                vHeader.TransId = " ";
                vHeader.cdCnpj = " ";
                vHeader.cdPessoaContribuinte = "";
                vHeader.dsImagem = " ";
                vHeader.cdImagem = " ";
                var vHeaderJson = JsonConvert.SerializeObject(vHeader);
                var vHeaderPost = new System.Net.Http.StringContent(vHeaderJson, Encoding.UTF8, "application/x-www-form-urlencoded");
                var vResult = vClient.PostAsync("/SIC/sintegra/result.jsp", vHeaderPost).Result;

                var vResulStr = vResult.Content.ReadAsStringAsync();

                Console.WriteLine("-----------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO");
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
