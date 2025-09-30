using System;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

