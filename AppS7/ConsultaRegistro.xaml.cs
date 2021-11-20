using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
            consulta();
        }

        public async void consulta()
        {
            var registros = await conn.Table<Estudiante>().ToListAsync();

            tablaEstudiante = new ObservableCollection<Estudiante>(registros);

            ListaUsuario.ItemsSource= tablaEstudiante;

        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;

            var item = obj.id.ToString();
            int id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(id));
            }
            catch (Exception ex){ 
            
            }

        }
    }
}