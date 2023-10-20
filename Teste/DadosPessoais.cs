using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{


    public class DadosPessoais
    {
        public bool error { get; set; }
        public string? name { get; set; }
        public string? data_de_nascimento { get; set; }
        public string? pai { get; set; }
        public string? mae { get; set; }
        public string? morada { get; set; }
        public string? type { get; set; }
    }
    public class BilheteService
    {
        private string GetURL(string BI) => $"https://consulta.edgarsingui.ao/consultar/{BI}";
        public async void GetDadosPessoasPorBilhete(string bi, DataGridView dgvDados)
        {
            using (var client = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                HttpResponseMessage response = await client.GetAsync(GetURL(bi));
                if (response.IsSuccessStatusCode)
                {
                    var dataJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<DadosPessoais>(dataJsonString);
                    dgvDados.DataSource = bsDados;
                    dgvDados.Columns["error"].Visible=false;
                    dgvDados.Columns["type"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Falha ao obter os dados pessoais : " + response.StatusCode);
                }
            }
        }
    }


}
