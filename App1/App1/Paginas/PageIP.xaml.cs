using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Clases;
using App1.Servicios;



namespace App1.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //Le Bindeamos la clase Principal para "pasarle los objetos (lbls botones etc) que hemos creado enesa clase a el XAML"
            this.BindingContext = new Principal();
        }//Fin del constructor

        public async void BtnConsultar_Clicked(object sender, EventArgs e)
        {

            //Creamos un objeto NUEVO (que tendrá las qtiquetas vacías)
            Principal principal = new Principal();

            //Comprobamos el estado del botón y según sea, actuará
            if (BtnConsultar.Text.ToString().Equals("Consultar IP")) {

                try
                {
                    //Recibimos el objeto "PRINCIPAL" que nos devolverá la consulta
                    principal = await ServicioConsultaIP.ConsultarIp();

                }
                catch (Exception)
                {
                   
                }
                //Comprobamos que trae información de la IP si no... mostraremos un error
                if (!principal.LblDos.ToString().Equals("")){
                    //Seteamos las propiedades de los Elementos
                    LblUnoXaml.TextColor = Color.White;
                    principal.LblUno = "Tu IP es:";
                    BtnConsultar.Text = "Reset Result";

             
                }else{
                    BtnConsultar.Text = "Reset Result";
                    LblUnoXaml.TextColor = Color.Red;
                    principal.LblUno = "Se ha producido un ERROR\n" +
                    $"No se ha recibido la información esperada\n\nRecibido:{principal.LblDos}";
                }//Fin del if que comprueba Si EXISTE algo en el "LblDos" del objeto recibido

                //Pasamos el objeto al XAML para setear los Botones y etiquetas
                this.BindingContext = principal;


            }
            else{
                //Seteamos el botón ya que arriba de declaró un objeto vacío
                BtnConsultar.Text = "Consultar IP";
                //Pasamos el objeto al XAML para setear los Botones y etiquetas
                this.BindingContext = principal;
            }//Fin del IF que comprueba el estado del BOTON

        }

    }//Fin del la clase
}