using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppS7.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Cliente> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
            consulta();
        }

        public async void consulta()
        {
            var registros = await conn.Table<Cliente>().ToListAsync();

            tablaEstudiante = new ObservableCollection<Cliente>(registros);

            ListaUsuario.ItemsSource= tablaEstudiante;

        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Cliente)e.SelectedItem;

            var item = obj.id.ToString();
            int id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(id));
            }
            catch (Exception ex){

                DisplayAlert("error", ex.Message, "ok");
            }

        }

        private void btnEquipo_Clicked(object sender, EventArgs e)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);
            db.CreateTable<OrdenTrabjo>();
            Navigation.PushAsync(new ConsultarEquipo());
        }
    }
}