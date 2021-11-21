using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using AppS7.Model;
using AppS7;

namespace AppS7
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
        }


        public static IEnumerable<Cliente> SELECT_WHERE(SQLiteConnection db, string usuario, string password)
        {
            return db.Query<Cliente>("Select *from cliente where usuario=? and password=?", usuario, password);
        }
        private void ingresar_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Cliente>();
                IEnumerable<Cliente> resultado = SELECT_WHERE(db, usuario.Text, password.Text);

                if (resultado.Count()> 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("error", "no existe el usuario", "ok");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async void btnRigistrar_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Registro());
        }
    }
}