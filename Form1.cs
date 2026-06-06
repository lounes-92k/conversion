using System;
using System.Windows.Forms;

namespace conversion
{
    public partial class Form1 : Form
    {
        ComboBox cmbType;
        ComboBox cmbDe;
        ComboBox cmbVers;
        TextBox txtValeur;
        Button btnConvertir;
        Label lblResultat;

        Temperature temperature = new Temperature();
        Unites unites = new Unites();
        Devises devises = new Devises();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Conversion";
            this.Size = new System.Drawing.Size(400, 300);

            Label l1 = new Label();
            l1.Text = "Type :";
            l1.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(l1);

            cmbType = new ComboBox();
            cmbType.Location = new System.Drawing.Point(20, 40);
            cmbType.Width = 150;
            cmbType.Items.Add("Température");
            cmbType.Items.Add("Unités");
            cmbType.Items.Add("Devises");
            cmbType.SelectedIndex = 0;
            cmbType.SelectedIndexChanged += cmbType_Changed;
            this.Controls.Add(cmbType);

            Label l2 = new Label();
            l2.Text = "Valeur :";
            l2.Location = new System.Drawing.Point(20, 80);
            this.Controls.Add(l2);

            txtValeur = new TextBox();
            txtValeur.Location = new System.Drawing.Point(20, 100);
            txtValeur.Width = 100;
            this.Controls.Add(txtValeur);

            Label l3 = new Label();
            l3.Text = "De :";
            l3.Location = new System.Drawing.Point(20, 135);
            this.Controls.Add(l3);

            cmbDe = new ComboBox();
            cmbDe.Location = new System.Drawing.Point(20, 155);
            cmbDe.Width = 120;
            this.Controls.Add(cmbDe);

            Label l4 = new Label();
            l4.Text = "Vers :";
            l4.Location = new System.Drawing.Point(160, 135);
            this.Controls.Add(l4);

            cmbVers = new ComboBox();
            cmbVers.Location = new System.Drawing.Point(160, 155);
            cmbVers.Width = 120;
            this.Controls.Add(cmbVers);

            btnConvertir = new Button();
            btnConvertir.Text = "Convertir";
            btnConvertir.Location = new System.Drawing.Point(20, 195);
            btnConvertir.Width = 100;
            btnConvertir.Height = 35;
            btnConvertir.Click += btnConvertir_Click;
            this.Controls.Add(btnConvertir);

            lblResultat = new Label();
            lblResultat.Text = "Résultat : ";
            lblResultat.Location = new System.Drawing.Point(20, 235);
            lblResultat.Width = 300;
            this.Controls.Add(lblResultat);

            remplirListes();
        }

        void cmbType_Changed(object sender, EventArgs e)
        {
            remplirListes();
        }

        void remplirListes()
        {
            cmbDe.Items.Clear();
            cmbVers.Items.Clear();

            if (cmbType.SelectedItem.ToString() == "Température")
            {
                cmbDe.Items.Add("Celsius");
                cmbDe.Items.Add("Fahrenheit");
                cmbDe.Items.Add("Kelvin");
                cmbVers.Items.Add("Celsius");
                cmbVers.Items.Add("Fahrenheit");
                cmbVers.Items.Add("Kelvin");
            }
            else if (cmbType.SelectedItem.ToString() == "Unités")
            {
                cmbDe.Items.Add("Km");
                cmbDe.Items.Add("Miles");
                cmbDe.Items.Add("Kg");
                cmbDe.Items.Add("Livres");
                cmbVers.Items.Add("Km");
                cmbVers.Items.Add("Miles");
                cmbVers.Items.Add("Kg");
                cmbVers.Items.Add("Livres");
            }
            else if (cmbType.SelectedItem.ToString() == "Devises")
            {
                cmbDe.Items.Add("EUR");
                cmbDe.Items.Add("USD");
                cmbDe.Items.Add("GBP");
                cmbVers.Items.Add("EUR");
                cmbVers.Items.Add("USD");
                cmbVers.Items.Add("GBP");
            }

            cmbDe.SelectedIndex = 0;
            cmbVers.SelectedIndex = 1;
        }

        void btnConvertir_Click(object sender, EventArgs e)
        {
            double valeur;
            bool ok = double.TryParse(txtValeur.Text, out valeur);

            if (!ok)
            {
                MessageBox.Show("Entrez un nombre !");
                return;
            }

            double resultat = 0;
            string de = cmbDe.SelectedItem.ToString();
            string vers = cmbVers.SelectedItem.ToString();

            if (cmbType.SelectedItem.ToString() == "Température")
                resultat = temperature.Convertir(valeur, de, vers);
            else if (cmbType.SelectedItem.ToString() == "Unités")
                resultat = unites.Convertir(valeur, de, vers);
            else if (cmbType.SelectedItem.ToString() == "Devises")
                resultat = devises.Convertir(valeur, de, vers);

            lblResultat.Text = "Résultat : " + Math.Round(resultat, 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
