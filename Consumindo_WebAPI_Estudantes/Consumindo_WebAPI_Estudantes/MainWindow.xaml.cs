using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace Consumindo_WebAPI_Estudantes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            List<string> generoLista = new List<string>();
            generoLista.Add("Masculino");
            generoLista.Add("Femenino");
            cbxGenero.ItemsSource = generoLista;

            client.BaseAddress = new Uri("http://localhost:51133");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                HttpResponseMessage response = await client.GetAsync("/api/estudantes");
                response.EnsureSuccessStatusCode();
                var estudantes = await response.Content.ReadAsAsync<IEnumerable<Estudante>>();
                estudantesListView.ItemsSource = estudantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnGetEstudante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/estudantes/" + txtID.Text);
                response.EnsureSuccessStatusCode(); 
                var estudantes = await response.Content.ReadAsAsync<Estudante>();
                estudanteDetalhesPanel.Visibility = Visibility.Visible;
                estudanteDetalhesPanel.DataContext = estudantes;
            }
            catch (Exception)
            {
                MessageBox.Show("Estudante no localizado");
            }
        }

        private async void btnNovoEstudante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var estudante = new Estudante()
                {
                    nome = txtNomeEstudante.Text,
                    id = int.Parse(txtIDEstudante.Text),
                    genero = cbxGenero.SelectedItem.ToString(),
                    idade = int.Parse(txtIdade.Text)
                };
                var response = await client.PostAsJsonAsync("/api/estudantes/", estudante);
                response.EnsureSuccessStatusCode(); 
                MessageBox.Show("Estudante incluído con exito", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                estudantesListView.ItemsSource = await GetAllEstudantes();
                estudantesListView.ScrollIntoView(estudantesListView.ItemContainerGenerator.Items[estudantesListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "-" + "O Estudante no fue registrado. (Verifique se o ID no esta duplicado)");
            }
        }

        private async void btnAtualiza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var estudante = new Estudante()
                {
                    nome = txtNomeEstudante.Text,
                    id = int.Parse(txtIDEstudante.Text),
                    genero = cbxGenero.SelectedItem.ToString(),
                    idade = int.Parse(txtIdade.Text)
                };
                var response = await client.PutAsJsonAsync("/api/estudantes/", estudante);
                response.EnsureSuccessStatusCode(); 
                MessageBox.Show("Estudiante atualizado con exito", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                estudantesListView.ItemsSource = await GetAllEstudantes();
                estudantesListView.ScrollIntoView(estudantesListView.ItemContainerGenerator.Items[estudantesListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDeletEstudante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/estudantes/" + txtID.Text);
                response.EnsureSuccessStatusCode(); 
                MessageBox.Show("Estudiante delete con exito");
                estudantesListView.ItemsSource = await GetAllEstudantes();
                estudantesListView.ScrollIntoView(estudantesListView.ItemContainerGenerator.Items[estudantesListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<IEnumerable<Estudante>> GetAllEstudantes()
        {
            HttpResponseMessage response = await client.GetAsync("/api/estudantes");
            response.EnsureSuccessStatusCode(); 
            var estudantes = await response.Content.ReadAsAsync<IEnumerable<Estudante>>();
            return estudantes;
        }
    }
}
