using AppS7.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> tablaEstudiante;
        int id;
        public Elemento(int id)
        {
            this.id = id;
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();
            consulta(id);

        }
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Select *from estudiante where id=?", id);
        }
        public  void consulta(int id)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

         //   List<Estudiante> resul = db.Query<Estudiante>("Select *from estudiante where id=?", id);
            db.CreateTable<Estudiante>();
            IEnumerable<Estudiante> resultado = SELECT_WHERE(db,id);

            foreach ( var re in resultado.ToList())
            {
                name.Text = re.nombre;
                usuario.Text = re.usuario;
                password.Text = re.password;
            }
           
           
          

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }

        private void actualizar(string name,string usuario,string password)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

            db.Query<Estudiante>("Update estudiante set nombre=?,usuario=?,password=? where id=?", name,usuario,password,this.id);
            DisplayAlert("Mensaje", "Se actualizo correctamente", "ok");
            Navigation.PushAsync(new ConsultaRegistro());
        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaRegistro());
        }

        private void btnGuardar_Clicked_1(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            actualizar(name.Text,usuario.Text,password.Text);
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(documentPath);

            db.Query<Estudiante>("Delete from estudiante where id=?", this.id);

            DisplayAlert("Mensaje", "Se elimino correctamente", "ok");
            Navigation.PushAsync(new ConsultaRegistro());

        }
    }
}