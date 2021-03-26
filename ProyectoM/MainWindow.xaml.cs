using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _urlApi = "https://localhost:44393";
       
        
        public MainWindow()
        {
            InitializeComponent();
            LlenarComboBox();

        }

        private void LlenarComboBox()
        {
            var client = new RestClient(_urlApi);
            var request = new RestRequest("/api/OrderOptions", Method.GET);
            var response = client.Execute(request);

            var opciones = response.Content.Split(",");                        

            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "Value";

            foreach(var opcion in opciones.ToList())
            {
                string stringOpcion = opcion;
                stringOpcion = stringOpcion.Replace("[", "");
                stringOpcion = stringOpcion.Replace("]", "");
                stringOpcion = stringOpcion.Replace("/", "");
                stringOpcion = stringOpcion.Replace('"', ' ');

                comboBox.Items.Add(new { Text = stringOpcion});            
            }

            comboBox.SelectedIndex = 0;
        }


        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            result.Clear();
            string frase = inputFrase.Text.Trim();
            string opcionCombo = comboBox.SelectedItem.ToString();
            opcionCombo = opcionCombo.Replace("{", "").Replace("}","").Replace("=", "").Replace("Text", "").Trim();
            

            var client = new RestClient(_urlApi);           
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            result.Text = response.Content.ToString();
        }

        private void Estadisticas_Click(object sender, RoutedEventArgs e)
        {
            result.Clear();
            string frase = inputFrase.Text.Trim();

            var client = new RestClient(_urlApi);
            var request = new RestRequest("/api/Statictis", Method.GET);
            request.AddParameter("textToAnalyze", frase);
            var response = client.Execute(request);
            result.Text = response.Content.ToString();
        }
    }
}


