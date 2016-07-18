using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cliente
{
    /// <summary>
    /// Interaction logic for WinMatricula.xaml
    /// </summary>
    public partial class WinMatricula : Window
    {
        public string ip = "link";

        public WinMatricula()
        {
            InitializeComponent();
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ip);

            Models.Matricula f = new Models.Matricula
            {

                Id = 0,
                Aluno =  txtAluno.Text,
                Pacote = comboBox.Text,
                Data = Convert.ToDateTime(data.SelectedDate)
            };
    // ta mandado de um em um nao precisa de lista
            string s = "=" + JsonConvert.SerializeObject(f);

            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");

            await httpClient.PostAsync("/api/matricula", content);
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ip);
            //var response = await httpClient.GetAsync("/20131011110061/api/restaurante");
            var response = await httpClient.GetAsync("/api/matricula");

            var str = response.Content.ReadAsStringAsync().Result;

            List<Models.Matricula> obj = JsonConvert.DeserializeObject<List<Models.Matricula>>(str);
            listBox.ItemsSource = obj;
        }
    }
}
