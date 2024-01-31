using ListPerson_1._3_Grupo__4.Models;

namespace ListPerson_1._3_Grupo__4
{
    public partial class MainPage : ContentPage
    {
        //Variebl del tipo PersonControllers
        Controllers.PersonasControllers PersonDB;
        
        //Constructor que recibe parametros de BD
        public MainPage(Controllers.PersonasControllers dbpath)
        {
            InitializeComponent();
            PersonDB = dbpath;
        }

        public MainPage() {

            InitializeComponent();
            PersonDB = new Controllers.PersonasControllers();  
        }

        async void Save_info(System.Object sender, System.EventArgs e)
        {
            var person = new Models.Personas
            {
                Name = Nombre.Text,
                Apellido = Apellido.Text,
                Edad = Convert.ToInt32(Edad.Text),
                Correo = correo.Text,
                Direccion = direccion.Text,
            };

            if (PersonDB != null)
            {
              /*  try
                {*/
                    if (await PersonDB.StorePerson(person) > 0)
                    {
                        await DisplayAlert("Aviso", "Registro Ingresado con exito!!", "ok");
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "El controlador de la base de datos no esta inicializado", "ok");
                    }
              /*  }
                catch (Exception ex)
                {
                    // Manejar la excepción de StorePerson
                    Console.WriteLine($"Error al almacenar la persona: {ex.Message}");
                    // También puedes mostrar un mensaje al usuario si es necesario
                    await DisplayAlert("Error", "Hubo un problema al almacenar la persona.", "OK");
                }*/
            }
            else
            {
                await DisplayAlert("Aviso", "Personas esta vacio", "ok");
            }
        }
    }
}
