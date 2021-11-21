using AppS7.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarEquipo : ContentPage
    {
        int id;
        private SQLiteAsyncConnection conn;
        public RegistrarEquipo(int id=0)
        {
            this.id = id;
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
            if (id != 0)
            {
                consulta(id);
            }
            else{
                lblEquipo.Text = "";
                lblEquipo.Text = "Nuevo Equipo";
            } 
        }
        public static IEnumerable<OrdenTrabjo> SELECT_WHERE(SQLiteConnection db, int id)
        {
            return db.Query<OrdenTrabjo>("Select *from ordentrabjo where id=?", id);
        }
        public void consulta(int id)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

            //List<Estudiante> resul = db.Query<Estudiante>("Select *from estudiante where id=?", id);
            db.CreateTable<OrdenTrabjo>();
            IEnumerable<OrdenTrabjo> resultado = SELECT_WHERE(db, id);

            foreach (var re in resultado.ToList())
            {
                cliente.Text = re.cliente;
                equipo.Text = re.equipo;
                modelo.Text = re.modelo;
                serie.Text = re.serie;
                fechaIngreso.Text = re.fechaIngreso;
                estado.Text = re.estado;
                fechaSalida.Text = re.fechaEntrega;
            }
        }
            private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

            db.Query<Estudiante>("Delete from ordentrabjo where id=?", this.id);

            DisplayAlert("Mensaje", "Se elimino correctamente", "ok");
            Navigation.PushAsync(new ConsultarEquipo());
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarEquipo());
        }

        private void btnEliminar_Clicked_1(object sender, EventArgs e)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

            db.Query<OrdenTrabjo>("Delete from ordenTrabjo where id=?", this.id);

            DisplayAlert("Mensaje", "Se elimino correctamente", "ok");
            Navigation.PushAsync(new ConsultarEquipo());

        }

        private void btnActualizar_Clicked_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (this.id == 0)
                {
                    var registros = new OrdenTrabjo { cliente = cliente.Text, equipo = equipo.Text, modelo = modelo.Text, serie = serie.Text, fechaIngreso = fechaIngreso.Text, estado = estado.Text, fechaEntrega = fechaSalida.Text };
                    conn.InsertAsync(registros);
                    DisplayAlert("alerta", "Se guardo correctamente", "ok");

                }
                else
                {
                    var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                    var db = new SQLiteConnection(documentPath);

                    db.Query<OrdenTrabjo>("Update OrdenTrabjo set cliente=?,equipo=?,modelo=?,serie=?,fechaIngreso=?,estado=?,fechaEntrega=? where id=?", cliente.Text, equipo.Text, modelo.Text,serie.Text,fechaIngreso.Text,estado.Text,fechaSalida.Text, this.id);
                    DisplayAlert("Mensaje", "Se actualizo correctamente", "ok");
                    Navigation.PushAsync(new ConsultarEquipo());
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("error", ex.Message, "ok");
            }
        }
    }
}