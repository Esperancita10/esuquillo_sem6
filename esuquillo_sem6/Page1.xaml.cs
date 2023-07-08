using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esuquillo_sem6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private const string url = "http://192.168.100.235/servicios/post.php";
        private readonly HttpClient client = new HttpClient();

        private ObservableCollection<esuquillo_sem6.Datos> post;
        public Page1()
        {
            InitializeComponent();
            visualizar();
        }
        public async void visualizar()
        {

            var contenido = await client.GetStringAsync(url);
            List<esuquillo_sem6.Datos> listapost =  JsonConvert.DeserializeObject<List<esuquillo_sem6.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listapost);
            Lista_Estudiante.ItemsSource = post;

        }
        private void btnInser_Clicked(object sender, EventArgs e)
        {

        }

        private void Lista_Estudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoestudiante = (Datos)e.SelectedItem;
            /*int codigo  = Convert.ToInt32(objetoestudiante.codigo.ToString());  
            string nombre  =objetoestudiante.nombre.ToString();
            string apellido = objetoestudiante.apellido .ToString();
            int edad = Convert.ToInt32(objetoestudiante.edad.ToString()); 
            este codigo sirve para enviar dato por dato*/

            Navigation.PushAsync(new actualizar (objetoestudiante));
        }
    }
}