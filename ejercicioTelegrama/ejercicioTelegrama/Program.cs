using System;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm: new Form());
        }
    }
    public partial class Form1 : Form
    {
        private TextBox txtTelegrama;
        private TextBox txtPrecio;
        private CheckBox cbUrgente;
        private Button button1;

        public Form1()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            // Crear y configurar controles
            txtTelegrama = new TextBox { Left = 20, Top = 20, Width = 250 };
            cbUrgente = new CheckBox { Left = 20, Top = 50, Text = "Urgente" };
            button1 = new Button { Left = 20, Top = 80, Text = "Calcular" };
            txtPrecio = new TextBox { Left = 20, Top = 120, Width = 150, ReadOnly = true };

            // Asociar evento
            button1.Click += button1_Click;

            // Agregar controles al formulario
            Controls.Add(txtTelegrama);
            Controls.Add(cbUrgente);
            Controls.Add(button1);
            Controls.Add(txtPrecio);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o';
            int numPalabras;
            double coste;

            // Leo el telegrama 
            textoTelegrama = txtTelegrama.Text;

            // telegrama urgente?
            if (cbUrgente.Checked)
                tipoTelegrama = 'u';

            // Obtengo el número de palabras
            numPalabras = textoTelegrama.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                    coste = 2.5;
                else
                    coste = 0.5 * numPalabras;
            }
            else // Si el telegrama es urgente
            {
                if (numPalabras <= 10)
                    coste = 5;
                else
                    coste = 5 + 0.75 * (numPalabras - 10);
            }

            txtPrecio.Text = coste.ToString("0.00") + " euros";
        }
    }

}


