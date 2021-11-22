using AppS7.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarEquipo : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<OrdenTrabjo> tablaOrden;
        public ConsultarEquipo()
        {
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
            consulta();
        }
        public async void consulta()
        {
            var registros = await conn.Table<OrdenTrabjo>().ToListAsync();

            tablaOrden = new ObservableCollection<OrdenTrabjo>(registros);

            ListaEquipo.ItemsSource = tablaOrden;

        }

        private void ListaEquipo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (OrdenTrabjo)e.SelectedItem;

            var item = obj.id.ToString();
            int id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new RegistrarEquipo(id));
            }
            catch (Exception ex)
            {

                DisplayAlert("error", ex.Message, "ok");
            }
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrarEquipo());
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}