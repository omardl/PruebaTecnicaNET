using PruebaTecnicaNET.Services;
using System.Data;
using System.Text.Json;
using System.Windows.Forms.Design;

namespace PruebaTecnicaNET
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void button_getData(object sender, EventArgs e)
        {
            // Se cambia la apariencia del cursor para indicar que se está realizando la carga de datos en la base local 
            this.Cursor = Cursors.WaitCursor;

            // Comprueba si la tabla existe y genera un diálogo para que el usuario elija sobreescribir los datos o no cargarlos de nuevo de ser el caso
            var exists = await DatabaseService.CheckTableExists();

            if (exists)
            {

                DialogResult dialogAnswer = MessageBox.Show(
                    "Aviso: Se ha detectado que los datos ya están almacenados en local. ¿Desea sobreescribirlos?",
                    "Datos existentes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogAnswer != DialogResult.Yes)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            // Obtiene los datos del servicio y los guarda en la base local
            try
            {

                JsonElement items = await ApiService.GetItems();
                await DatabaseService.StoreData(items);

                MessageBox.Show("Los datos se han almacenado correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            this.Cursor = Cursors.Default;
        }

        private async void button_showData(object sender, EventArgs e)
        {
            // Crea una segunda pantalla sobre la que muestra los datos almacenados en local aplicando el criterio de filtrado
            FormDataGridView formDataGridView = new FormDataGridView();

            DataTable datos = await DatabaseService.ShowData();
            formDataGridView.dataGridView.DataSource = datos;

            formDataGridView.ShowDialog();
        }
    }
}
