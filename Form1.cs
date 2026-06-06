using System;
using System.Windows.Forms;
using System.Drawing;

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
            this.Text = "Application de Conversion";
            this.Size = new System.Drawing.Size(420, 350);
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Titre en haut
            Label titre = new Label();
            titre.Text = "🔄 Convertisseur";
            titre.Font = new Font("Arial", 14, FontStyle.Bold);
            titre.ForeColor = Color.FromArgb(50, 50, 150);
            titre.Location = new Point(20, 10);
            titre.AutoSize = true;
            this.Controls.Add(titre);

            // Label Type
            Label l1 = new Label();
            l1.Text = "Type :";
            l1.Font = new Font("Arial", 9, FontStyle.Bold);
            l1.Location = new System.Drawing.Point(20, 50);
            l1.AutoSize = true;
            this.Controls.Add(l1);

            // ComboBox Type
            cmbType = new ComboBox();
            cmbType.Location = new System.Drawing.Point(20, 70);
            cmbType.Width = 160;
            cmbType.Height = 30;
            cmbType.Font = new Font("Arial", 9);
            cmbType.Items.Add("Température");
            cmbType.Items.Add("Unités");
            cmbType.Items.Add("Devises");
            cmbType.SelectedIndex = 0;
            cmbType.SelectedIndexChanged += cmbType_Changed;
            this.Controls.Add(cmbType);

            // Label Valeur
            Label l2 = new Label();
            l2.Text = "Valeur :";
            l2.Font = new Font("Arial", 9, FontStyle.Bold);
            l2.Location = new System.Drawing.Point(20, 110);
            l2.AutoSize = true;
            this.Controls.Add(l2);

            // TextBox Valeur
            txtValeur = new TextBox();
            txtValeur.Location = new System.Drawing.Point(20, 130);
            txtValeur.Width = 160;
            txtValeur.Height = 30;
            txtValeur.Font = new Font("Arial", 10);
            txtValeur.BorderStyle = BorderStyle.FixedSingle;
            txtValeur.BackColor = Color.White;
            this.Controls.Add(txtValeur);

            // Label De
            Label l3 = new Label();
            l3.Text = "De :";
            l3.Font = new Font("Arial", 9, FontStyle.Bold);
            l3.Location = new System.Drawing.Point(20, 170);
            l3.AutoSize = true;
            this.Controls.Add(l3);

            // ComboBox De
            cmbDe = new ComboBox();
            cmbDe.Location = new System.Drawing.Point(20, 190);
            cmbDe.Width = 130;
            cmbDe.Font = new Font("Arial", 9);
            this.Controls.Add(cmbDe);

            // Label Vers
            Label l4 = new Label();
            l4.Text = "Vers :";
            l4.Font = new Font("Arial", 9, FontStyle.Bold);
            l4.Location = new System.Drawing.Point(170, 170);
            l4.AutoSize = true;
            this.Controls.Add(l4);

            // ComboBox Vers
            cmbVers = new ComboBox();
            cmbVers.Location = new System.Drawing.Point(170, 190);
            cmbVers.Width = 130;
            cmbVers.Font = new Font("Arial", 9);
            this.Controls.Add(cmbVers);

            // Bouton Convertir
            btnConvertir = new Button();
            btnConvertir.Text = "Convertir";
            btnConvertir.Location = new System.Drawing.Point(20, 235);
            btnConvertir.Width = 120;
            btnConvertir.Height = 35;
            btnConvertir.Font = new Font("Arial", 10, FontStyle.Bold);
            btnConvertir.BackColor = Color.FromArgb(50, 50, 150);
            btnConvertir.ForeColor = Color.White;
            btnConvertir.FlatStyle = FlatStyle.Flat;
            btnConvertir.FlatAppearance.BorderSize = 0;
            btnConvertir.Click += btnConvertir_Click;
            this.Controls.Add(btnConvertir);

            // Label Résultat
            lblResultat = new Label();
            lblResultat.Text = "Résultat : ";
            lblResultat.Location = new System.Drawing.Point(20, 285);
            lblResultat.Width = 350;
            lblResultat.Font = new Font("Arial", 11, FontStyle.Bold);
            lblResultat.ForeColor = Color.FromArgb(50, 50, 150);
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
