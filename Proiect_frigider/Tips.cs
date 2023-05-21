using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Proiect_frigider
{
    public partial class Tips : Form
    {
        public Tips()
        {
            InitializeComponent();
        }


        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private void Tips_Load(object sender, EventArgs e)
        {
            // creăm o conexiune la baza de date utilizând cheia de conexiune din App.config
            //string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // creăm interogarea SQL care selectează toate înregistrările din tabela "tips"
            string query = "SELECT TOP 20 poza, titlu FROM tips";
            SqlCommand command = new SqlCommand(query, connection);

            // deschidem conexiunea la baza de date
            connection.Open();

            // executăm interogarea SQL și obținem un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // parcurgem toate înregistrările returnate și afișăm informațiile în PictureBox-uri și Label-uri corespunzătoare
            int i = 1;
            while (reader.Read())
            {
                // obținem adresa URL a pozei și titlul din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);

                // descărcăm imaginea de la adresa URL utilizând clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // convertim datele imaginii într-un obiect Image și îl afișăm în controlul PictureBox corespunzător
                MemoryStream stream = new MemoryStream(imageData);
                PictureBox pictureBox = this.Controls.Find("pictureBox" + i, true).FirstOrDefault() as PictureBox;
                pictureBox.Image = Image.FromStream(stream);

                // afișăm titlul în controlul Label corespunzător
                Button button = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                button.Text = titlu;

                // eliberăm resursele folosite de obiectele WebClient și MemoryStream
                client.Dispose();
                stream.Dispose();

                i++;
            }

            // închidem SqlDataReader și conexiunea la baza de date și eliberăm resursele
            reader.Close();
            command.Dispose();
            connection.Close();



        }

        //Tips_descriere td = new Tips_descriere();

        private void button1_Click(object sender, EventArgs e)
        {

            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT TOP 1 poza, titlu, descriere FROM tips";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 3";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 4";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 5";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 6";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 7";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 8";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 9";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 10";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 11";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 12";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 13";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 14";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 15";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 16";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 17";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 18";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 19";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 20";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Creaza o noua instanta a formei Tips_descriere
            Tips_descriere formDescriere = new Tips_descriere();

            // Creaza o conexiune la baza de date utilizand cheia de conexiune din App.config
            // string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            // Creaza interogarea SQL care selecteaza poza, titlul si descrierea primului rand din tabela "tips"
            string query = "SELECT poza, titlu, descriere FROM tips WHERE ID = 21";
            SqlCommand command = new SqlCommand(query, connection);

            // Deschide conexiunea la baza de date
            connection.Open();

            // Executa interogarea SQL si obtine un obiect SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Citeste randul si obtine poza, titlul si descrierea
            if (reader.Read())
            {
                // Obtine adresa URL a pozei, titlul si descrierea din baza de date
                string pozaUrl = reader.GetString(0);
                string titlu = reader.GetString(1);
                string descriere = reader.GetString(2);

                // Descarca imaginea de la adresa URL utilizand clasa WebClient
                WebClient client = new WebClient();
                byte[] imageData = client.DownloadData(pozaUrl);

                // Converteste datele imaginii intr-un obiect Image
                MemoryStream stream = new MemoryStream(imageData);
                Image imagine = Image.FromStream(stream);

                // Afiseaza poza, titlul si descrierea in formDescriere
                formDescriere.Text = titlu;
                formDescriere.pictureBox1.Load(pozaUrl);
                formDescriere.textBox1.Text = descriere;
                //form.Show();

                // Elibereaza resursele folosite de obiectele WebClient si MemoryStream
                client.Dispose();
                stream.Dispose();

                // Inchide SqlDataReader si conexiunea la baza de date si elibereaza resursele
                reader.Close();
                command.Dispose();
                connection.Close();

                // Afiseaza fereastra formDescriere
                formDescriere.Show();
            }
        }
    }
}
