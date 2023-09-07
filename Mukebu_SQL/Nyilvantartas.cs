using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;


namespace Mukebu_SQL
{
    public partial class Nyilvantartas : Form
    {
        DataTable nyilvtabla = new DataTable();
        private List<string> felvesz = new List<string>();
        private string ir;
        private string olvas;
        private string arkatment;
        private string berazo;
        private string teljes;

        private void ElsoBetolt()
        {
            nyilvtabla.Columns.Add("Dátum", typeof(string));
            nyilvtabla.Columns.Add("Foglalásazonosító", typeof(string));
            nyilvtabla.Columns.Add("Ügyfélazonosító", typeof(string));
            nyilvtabla.Columns.Add("Autóazonosító", typeof(string));
            nyilvtabla.Columns.Add("Bérlés kezdőnap", typeof(string));
            nyilvtabla.Columns.Add("Bérlés zárónap", typeof(string));
            nyilvtabla.Columns.Add("Bérlés összege", typeof(string));
            nyilvtabla.Columns.Add("Teljes összeg", typeof(string));

            dataGridView1.DataSource = nyilvtabla;

            dateTimePicker1.CustomFormat = "YYYY-MM-DD";
            dateTimePicker2.CustomFormat = "YYYY-MM-DD";

        }
        private void Clear()
        {
            comboBox4.Text = string.Empty;
            comboBox4.Items.Clear();
            comboBox5.Text = string.Empty;
            comboBox5.Items.Clear();
            comboBox8.Text = string.Empty;
            comboBox8.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox8.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();

        }
        private void AzoBetolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("Select berlesazo FROM nyilvantartas", kapcsolat);
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                comboBox8.Items.Add(mrd["berlesazo"].ToString());
            }

            kapcsolat.Close();
        }
        public void AutUgyfAzoBetolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand autoaz = new MySqlCommand("Select azo FROM auto", kapcsolat);
            MySqlDataReader mrda = autoaz.ExecuteReader();

            while (mrda.Read())
            {
                comboBox5.Items.Add(mrda["azo"].ToString());
            }

            kapcsolat.Close();

            kapcsolat.Open();
            MySqlCommand ugyfaz = new MySqlCommand("Select ugyfelazo FROM ugyfel", kapcsolat);
            MySqlDataReader mrdu = ugyfaz.ExecuteReader();

            while (mrdu.Read())
            {
                comboBox4.Items.Add(mrdu["ugyfelazo"].ToString());
            }

            kapcsolat.Close();

        }
        private void MezoKitolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT ugyfelazo, autoazo, kezdonap, zaronap, berletidij, osszeg FROM nyilvantartas WHERE berlesazo=@berlesazo", kapcsolat);
            azonosito.Parameters.AddWithValue("@berlesazo", comboBox8.Text);
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                comboBox4.Text = mrd.GetValue(0).ToString();
                comboBox5.Text = mrd.GetValue(1).ToString();
                dateTimePicker1.Value = mrd.GetDateTime(2);
                dateTimePicker2.Value = mrd.GetDateTime(3);
                textBox4.Text = mrd.GetValue(4).ToString();
                textBox3.Text = mrd.GetValue(5).ToString();


            }

            kapcsolat.Close();
        }
        private void Felvetel()
        {
            teljes = (int.Parse(textBox3.Text) + int.Parse(textBox1.Text)).ToString();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO nyilvantartas(berlesazo, ugyfelazo, autoazo, kezdonap, zaronap, berletidij, osszeg) VALUES(@berlesazo, @ugyfelazo, @autoazo, @kezdonap, @zaronap, @berletidij, @osszeg)", kapcsolat);
            felvitel.Parameters.AddWithValue("@berlesazo", berazo);
            felvitel.Parameters.AddWithValue("@ugyfelazo", int.Parse(comboBox4.Text));
            felvitel.Parameters.AddWithValue("@autoazo", int.Parse(comboBox5.Text));
            felvitel.Parameters.AddWithValue("@kezdonap", DateTime.Parse(dateTimePicker1.Text));
            felvitel.Parameters.AddWithValue("@zaronap", DateTime.Parse(dateTimePicker2.Text));
            felvitel.Parameters.AddWithValue("@berletidij", int.Parse(textBox3.Text));
            felvitel.Parameters.AddWithValue("@osszeg", int.Parse(teljes));

            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Új foglalás felvétele megtörtént!");


        }
        private void Modosit()
        {
            teljes = (int.Parse(textBox3.Text) + int.Parse(textBox1.Text)).ToString();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosito = new MySqlCommand("UPDATE nyilvantartas set berlesazo=@berlesazo, ugyfelazo=@ugyfelazo, autoazo=@autoazo, kezdonap=@kezdonap, zaronap=@zaronap, berletidij=@berletidij, osszeg=@osszeg WHERE berlesazo=@berlesazo", kapcsolat);
            modosito.Parameters.AddWithValue("@berlesazo", comboBox8.Text);
            modosito.Parameters.AddWithValue("@ugyfelazo", int.Parse(comboBox4.Text));
            modosito.Parameters.AddWithValue("@autoazo", int.Parse(comboBox5.Text));
            modosito.Parameters.AddWithValue("@kezdonap", DateTime.Parse(dateTimePicker1.Text));
            modosito.Parameters.AddWithValue("@zaronap", DateTime.Parse(dateTimePicker2.Text));
            modosito.Parameters.AddWithValue("@berletidij", int.Parse(textBox3.Text));
            modosito.Parameters.AddWithValue("@osszeg", int.Parse(teljes));
            modosito.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt autó módosítása megtörtént!");
        }
        private void Torles()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand torol = new MySqlCommand("DELETE FROM nyilvantartas WHERE berlesazo=@berlesazo", kapcsolat);
            torol.Parameters.AddWithValue("@berlesazo", comboBox8.Text);
            torol.ExecuteNonQuery();

            kapcsolat.Close();
        }
        private void UgyfErtek()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("Select nev FROM ugyfel WHERE ugyfelazo=@ugyfelazo", kapcsolat);
            azonosito.Parameters.AddWithValue("@ugyfelazo", int.Parse(comboBox4.Text));
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                textBox2.Text = mrd.GetValue(0).ToString();
            }
            kapcsolat.Close();
        }
        private void AutErtek()
        {

            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand autoaz = new MySqlCommand("Select marka, tipus, arkategoria FROM auto WHERE azo=@azo", kapcsolat);
            autoaz.Parameters.AddWithValue("@azo", int.Parse(comboBox5.Text));
            MySqlDataReader mrd = autoaz.ExecuteReader();
            List<string> autert = new List<string>();

            while (mrd.Read())
            {
                autert.Add(mrd["marka"].ToString());
                autert.Add(mrd["tipus"].ToString());
                autert.Add(mrd["arkategoria"].ToString());
            }
            textBox6.Text = autert[0] + " " + autert[1];
            arkatment = autert[2];
            kapcsolat.Close();
        }
        public void Arkat()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand arkate = new MySqlCommand("Select ar, kaucio FROM arkategoria WHERE kategoria=@kategoria", kapcsolat);
            arkate.Parameters.AddWithValue("@kategoria", arkatment);
            MySqlDataReader mrdar = arkate.ExecuteReader();

            while (mrdar.Read())
            {
                textBox4.Text = mrdar.GetValue(0).ToString();
                textBox1.Text = mrdar.GetValue(1).ToString();
            }
            kapcsolat.Close();
        }
        public void KaucioNap()
        {

            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand arkate = new MySqlCommand("Select kaucio FROM arkategoria WHERE kategoria=@kategoria", kapcsolat);
            arkate.Parameters.AddWithValue("@kategoria", arkatment);
            MySqlDataReader mrdar = arkate.ExecuteReader();

            while (mrdar.Read())
            {
                textBox1.Text = mrdar.GetValue(0).ToString();
            }
            kapcsolat.Close();

            DateTime dt = dateTimePicker1.Value;
            DateTime dt1 = dateTimePicker2.Value;
            TimeSpan difference = dt1 - dt;
            int totalDays = difference.Days + 1;
            Console.WriteLine(difference.TotalDays);  // Positive value
            Console.WriteLine(totalDays);
            textBox8.Text = (totalDays).ToString();
            textBox3.Text = (totalDays * Convert.ToInt32(textBox4.Text)).ToString();

        }
        public void FelveszAdd()
        {
            teljes = (int.Parse(textBox3.Text) + int.Parse(textBox1.Text)).ToString();
            felvesz.Add(DateTime.Now.ToString());
            felvesz.Add(berazo);
            felvesz.Add(comboBox4.Text);
            felvesz.Add(comboBox5.Text);
            felvesz.Add((dateTimePicker1.Value).ToString());
            felvesz.Add((dateTimePicker2.Value).ToString());
            felvesz.Add(textBox3.Text);
            felvesz.Add(teljes);
        }
        private void FileIr()
        {
            if (comboBox7.Text == "Új foglalás felvétele") { ir = "nyilvantartasfelvett.txt"; }
            if (comboBox7.Text == "Foglalás adatainak módosítása") { ir = "nyilvantartasmodosit.txt"; }
            if (comboBox7.Text == "Foglalás törlése") { ir = "nyilvantartastorol.txt"; }

            StreamWriter iras = File.AppendText(ir);
            for (int i = 0; i < felvesz.Count - 1; i++)
            {
                iras.Write(felvesz[i] + ",");
            }
            iras.Write(felvesz[felvesz.Count - 1]);
            iras.Write("\n");
            iras.Close();
            felvesz.Clear();

        }
        private void FileOlvas()
        {
            if (comboBox1.Text == "Új foglalás felvétele") { olvas = "nyilvantartasfelvett.txt"; }
            if (comboBox1.Text == "Foglalás adatainak módosítása") { olvas = "nyilvantartasmodosit.txt"; }
            if (comboBox1.Text == "Foglalás törlése") { olvas = "nyilvantartastorol.txt"; }

            string[] sorok = File.ReadAllLines(olvas);
            string[] ertekek;
            for (int i = 0; i < sorok.Length; i++)
            {
                ertekek = sorok[i].ToString().Split(',');
                string[] row = new string[ertekek.Length];

                for (int j = 0; j < ertekek.Length; j++)
                {
                    row[j] = ertekek[j].Trim();
                }

                nyilvtabla.Rows.Add(row);
                sorok.DefaultIfEmpty();
            }
            sorok.DefaultIfEmpty();
        }
        private void VisszaModosit()
        {
            List<string> visszamod = new List<string>();
            for (int i = 1; i < nyilvtabla.Columns.Count; i++)
            {
                visszamod.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }

            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosit = new MySqlCommand("UPDATE nyilvantartas set berlesazo=@berlesazo, ugyfelazo=@ugyfelazo, autoazo=@autoazo, kezdonap=@kezdonap, zaronap=@zaronap, berletidij=@berletidij, osszeg=@osszeg WHERE berlesazo=@berlesazo", kapcsolat);
            modosit.Parameters.AddWithValue("@berlesazo", visszamod[0]);
            modosit.Parameters.AddWithValue("@ugyfelazo", int.Parse(visszamod[1]));
            modosit.Parameters.AddWithValue("@autoazo", int.Parse(visszamod[2]));
            modosit.Parameters.AddWithValue("@kezdonap", DateTime.Parse(visszamod[3]));
            modosit.Parameters.AddWithValue("@zaronap", DateTime.Parse(visszamod[4]));
            modosit.Parameters.AddWithValue("@berletidij", int.Parse(visszamod[5]));
            modosit.Parameters.AddWithValue("@osszeg", int.Parse(visszamod[6]));
            modosit.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt foglalás módosításának visszaállítása megtörtént!");
            visszamod.Clear();
        }
        private void VisszaTorol()
        {
            List<string> visszatorol = new List<string>();
            for (int i = 1; i < nyilvtabla.Columns.Count; i++)
            {
                visszatorol.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO nyilvantartas(berlesazo, ugyfelazo, autoazo, kezdonap, zaronap, berletidij, osszeg) VALUES(@berlesazo, @ugyfelazo, @autoazo, @kezdonap, @zaronap, @berletidij, @osszeg)", kapcsolat);
            felvitel.Parameters.AddWithValue("@berlesazo", visszatorol[0]);
            felvitel.Parameters.AddWithValue("@ugyfelazo", int.Parse(visszatorol[1]));
            felvitel.Parameters.AddWithValue("@autoazo", int.Parse(visszatorol[2]));
            felvitel.Parameters.AddWithValue("@kezdonap", DateTime.Parse(visszatorol[3]));
            felvitel.Parameters.AddWithValue("@zaronap", DateTime.Parse(visszatorol[4]));
            felvitel.Parameters.AddWithValue("@berletidij", int.Parse(visszatorol[5]));
            felvitel.Parameters.AddWithValue("@osszeg", int.Parse(visszatorol[6]));
            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Törölt foglalás visszaállítása megtörtént!");
            visszatorol.Clear();
        }

        public Nyilvantartas()
        {
            InitializeComponent();
        }
        private void Nyilvantartas_Load(object sender, EventArgs e)
        {
            ElsoBetolt();
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            if (comboBox7.Text == "Új foglalás felvétele")
            {
                comboBox8.Enabled = false;
                AutUgyfAzoBetolt();
            }
            if (comboBox7.Text == "Foglalás adatainak módosítása" || comboBox7.Text == "Foglalás törlése")
            {
                comboBox8.Enabled = true;
                AzoBetolt();
            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Foglalás adatainak módosítása" || comboBox7.Text == "Foglalás törlése")
            {
                MezoKitolt();
                UgyfErtek();
                AutErtek();
                KaucioNap();
                FelveszAdd();
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új foglalás felvétele")
            {
                UgyfErtek();
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új foglalás felvétele")
            {
                AutErtek();
                Arkat();
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && dateTimePicker2.Value > dateTimePicker1.Value)
            {
                DateTime dt = dateTimePicker1.Value;
                DateTime dt1 = dateTimePicker2.Value;
                TimeSpan difference = dt1 - dt;
                int totalDays = difference.Days + 1;
                Console.WriteLine(difference.TotalDays);  // Positive value
                Console.WriteLine(totalDays);
                textBox8.Text = (totalDays).ToString();
                textBox3.Text = (totalDays * Convert.ToInt32(textBox4.Text)).ToString();


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új foglalás felvétele")
            {
                if (dateTimePicker2.Value < dateTimePicker1.Value) { MessageBox.Show("A kezdőnapnál korábbi dátumot adott meg, kérem javítsa!"); }
                else
                {
                    DialogResult felv = MessageBox.Show("Valóban hozzá szeretné adni az új foglalást az adatbázishoz?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (felv == DialogResult.Yes)
                    {
                        List<string> berlesazo = new List<string>();
                        Random rnd = new Random();
                        for (int i = 0; i < 8; i++)
                        {
                            berlesazo.Add(rnd.Next(0, 9).ToString());
                        }
                        berazo = berlesazo[0] + berlesazo[1] + berlesazo[2] + berlesazo[3] + berlesazo[4] + berlesazo[5] + berlesazo[6] + berlesazo[7];

                        FelveszAdd();
                        FileIr();
                        Felvetel();
                        Clear();
                        berlesazo.Clear();
                    }
                }
            }
            if (comboBox7.Text == "Foglalás adatainak módosítása" && comboBox8.Text.Length > 0)
            {
                DialogResult mod = MessageBox.Show("Valóban módosítani szeretné a kijelölt foglalás adatait?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mod == DialogResult.Yes)
                {
                    FileIr();
                    Modosit();
                    Clear();
                }
            }
            if (comboBox7.Text == "Foglalás törlése" && comboBox8.Text.Length > 0)
            {
                DialogResult torl = MessageBox.Show("Valóban törölni szeretné a kijelölt foglalást?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (torl == DialogResult.Yes)
                {
                    FileIr();
                    Torles();
                    Clear();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            { MessageBox.Show("Kéem válasszon a balra található listából!"); }
            else
            {
                nyilvtabla.Rows.Clear();
                FileOlvas();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Módosított autók listája") ;
            {
                VisszaModosit();
                if (comboBox7.Text == "Foglalás adatainak módosítása" || comboBox7.Text == "Foglalás törlése") { AzoBetolt(); }
            }

            if (comboBox1.Text == "Törölt autók listája")
            {
                VisszaTorol();
                if (comboBox7.Text == "Foglalás adatainak módosítása" || comboBox7.Text == "Foglalás törlése") { AzoBetolt(); }
            }
        }
    }
}
