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
    public partial class Arkategoria : Form
    {
        DataTable arkattabla = new DataTable();
        private List<string> felvesz = new List<string>();
        private string ir;
        private string olvas;

        private void ElsoBetolt()
        {
            arkattabla.Columns.Add("Dátum", typeof(string));
            arkattabla.Columns.Add("Kategória", typeof(string));
            arkattabla.Columns.Add("Kaució", typeof(string));
            arkattabla.Columns.Add("Egységár", typeof(string));

            dataGridView1.DataSource = arkattabla;

        }
        private void Clear()
        {
            comboBox8.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
        }
        private void KatBetolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT kategoria FROM arkategoria", kapcsolat);
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                comboBox8.Items.Add(mrd["kategoria"].ToString());
            }

            kapcsolat.Close();
        }
        private void MezoKitolt()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand azonosito = new MySqlCommand("SELECT kaucio, ar, kategoria FROM arkategoria WHERE kategoria=@kategoria", kapcsolat);
            azonosito.Parameters.AddWithValue("@kategoria", comboBox8.Text);
            MySqlDataReader mrd = azonosito.ExecuteReader();

            while (mrd.Read())
            {
                textBox1.Text = mrd.GetValue(0).ToString();
                textBox2.Text = mrd.GetValue(1).ToString();              
            }

            kapcsolat.Close();
        }    
        private void Felvetel()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO arkategoria(kaucio, ar, kategoria) VALUES(@kaucio, @ar, @kategoria)", kapcsolat);
            felvitel.Parameters.AddWithValue("@kategoria", comboBox8.Text);
            felvitel.Parameters.AddWithValue("@ar", textBox2.Text);
            felvitel.Parameters.AddWithValue("@kaucio", textBox1.Text);

            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Új kategória felvétele megtörtént!");

        }
        private void Modosit()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosito = new MySqlCommand("UPDATE arkategoria SET kaucio=@kaucio, ar=@ar WHERE kategoria=@kategoria", kapcsolat);
            modosito.Parameters.AddWithValue("@kategoria", comboBox8.Text);
            modosito.Parameters.AddWithValue("@ar", int.Parse(textBox2.Text));
            modosito.Parameters.AddWithValue("@kaucio", int.Parse(textBox1.Text));
            modosito.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt árkategória adatainak módosítása megtörtént!");
        }
        private void Torles()
        {
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand torol = new MySqlCommand("DELETE FROM arkategoria WHERE kategoria=@kategoria", kapcsolat);
            torol.Parameters.AddWithValue("@kategoria", comboBox8.Text);
            torol.ExecuteNonQuery();

            kapcsolat.Close();
            MessageBox.Show("Kijelölt kategória törlése megtörtént!");
        }
        private void FelveszAdd()
        {
            felvesz.Add(DateTime.Now.ToString());
            felvesz.Add(comboBox8.Text);
            felvesz.Add(textBox1.Text);
            felvesz.Add(textBox2.Text);    
        }
        private void FileIr()
        {
            if (comboBox7.Text == "Új kategória felvétele") { ir = "arkategoriafelvett.txt"; }
            if (comboBox7.Text == "Kategória adatainak módosítása") { ir = "arkategoriamodosit.txt"; }
            if (comboBox7.Text == "Kategória törlése") { ir = "arkategoriatorol.txt"; }

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
            if (comboBox1.Text == "Felvitt kategóriák listája") { olvas = "arkategoriafelvett.txt"; }
            if (comboBox1.Text == "Módosított kategóriák listája") { olvas = "arkategoriamodosit.txt"; }
            if (comboBox1.Text == "Törölt kategóriák listája") { olvas = "arkategoriatorol.txt"; }

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

                arkattabla.Rows.Add(row);
                ertekek.DefaultIfEmpty();
            }
            sorok.DefaultIfEmpty();
        }
        private void VisszaModosit()
        {
            List<string> visszamod = new List<string>();
            for (int i = 1; i < arkattabla.Columns.Count; i++)
            {
                visszamod.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand modosit = new MySqlCommand("UPDATE arkategoria SET kaucio=@kaucio, ar=@ar WHERE kategoria=@kategoria", kapcsolat);
            modosit.Parameters.AddWithValue("@kategoria", visszamod[0]);
            modosit.Parameters.AddWithValue("@kaucio", int.Parse(visszamod[1]));
            modosit.Parameters.AddWithValue("@ar", int.Parse(visszamod[2]));        
            modosit.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Kijelölt kategória módosításának visszaállítása megtörtént!");
            visszamod.Clear();
        }
        private void VisszaTorol()
        {
            List<string> visszatorol = new List<string>();
            for (int i = 1; i < arkattabla.Columns.Count; i++)
            {
                visszatorol.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
            }
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlCommand felvitel = new MySqlCommand("INSERT INTO arkategoria(kaucio, ar, kategoria) VALUES(@kaucio, @ar, @kategoria)", kapcsolat);
            felvitel.Parameters.AddWithValue("@kategoria", visszatorol[0]);
            felvitel.Parameters.AddWithValue("@kaucio", int.Parse(visszatorol[1]));
            felvitel.Parameters.AddWithValue("@ar", int.Parse(visszatorol[2]));

            felvitel.ExecuteNonQuery();
            kapcsolat.Close();
            MessageBox.Show("Törölt kategória visszaállítása megtörtént!");
            visszatorol.Clear();
        }

        public Arkategoria()
        {
            InitializeComponent();
        }
        private void Arkategoria_Load(object sender, EventArgs e)
        {
            ElsoBetolt();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            Clear();
            if (comboBox7.Text == "Kategória adatainak módosítása" || comboBox7.Text == "Kategória törlése")
            {
                KatBetolt();
            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Kategória adatainak módosítása" || comboBox7.Text == "Kategória törlése")
            {
                MezoKitolt();
                FelveszAdd();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Új kategória felvétele")
            {
                DialogResult felv = MessageBox.Show("Valóban hozzá szeretné adni az új árkategóriát az adatbázishoz?", "Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (felv == DialogResult.Yes)
                {
                    FelveszAdd();
                    FileIr();
                    Felvetel();
                    Clear();
                }
            }
            if (comboBox7.Text == "Kategória adatainak módosítása" && comboBox8.Text.Length > 0)
            {
                DialogResult mod = MessageBox.Show("Valóban módosítani szeretné a kijelölt kategória adatait?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mod == DialogResult.Yes)
                {
                    FileIr();
                    Modosit();
                    Clear();
                }
            }
            if (comboBox7.Text == "Kategória törlése" && comboBox8.Text.Length > 0)
            {
                DialogResult torl = MessageBox.Show("Valóban törölni szeretné a kijelölt kategóriát?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                arkattabla.Rows.Clear();
                FileOlvas();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Módosított kategóriák listája")
            { 
                VisszaModosit();
                if (comboBox7.Text == "Kategória adatainak módosítása" || comboBox7.Text == "Kategória törlése")
                { KatBetolt(); }
            }
            if (comboBox1.Text == "Törölt kategóriák listája")
            {
                VisszaTorol();
                if (comboBox7.Text == "Kategória adatainak módosítása" || comboBox7.Text == "Kategória törlése")
                { KatBetolt(); }
            }




                
        }
    }
}
