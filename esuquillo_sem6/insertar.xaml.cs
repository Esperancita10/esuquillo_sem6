using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esuquillo_sem6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class insertar : ContentPage
    {
        public insertar()
        {
            InitializeComponent();
        }

        private void btnInser_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string url = "http://192.168.100.235/servicios/post.php";
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApelldio.Text);
                parametros.Add("edad", txtEdad.Text);

                client.UploadValues(url, "POST", parametros);
                // DisplayAlert("Alerta", "ingreso correcto ", "cerrar");

                var mensaje = "REGISTRO DE DATO";

                DependencyService.Get<mmensajes>().LongAlert(mensaje);

                Navigation.PushAsync(new Page1());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}