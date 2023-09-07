using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Mukebu_SQL
{
    public partial class Kezdo : Form
    {

        private string[] autooszlopok = { "Azonosító", "Márka", "Típus", "Évjárat", "Ülésszaám", "Váltó", "Üzemanyag", "Rendszám", "Árkategória", "Csomagtartó", "GPS", "Ajtószám" };
        private string[] ugyfeloszlopok = { "Ügyfélazonosító", "Név", "Irányítószám", "Ország", "Település", "Cím", "E-mail", "Telefon" };
        private string[] nyilvantartasoszlopok = { "Autóazonosító", "Ügyfélazonosító", "Bérlésazonosító", "Bérlés kezdőnapja", "Bérlés zárónapja", "Egységár", "Bérlés összege" };
        private string[] arkategoriaoszlopok = { "Egységár", "Kategória", "Kaució" };
        private string[] kapcsolat = { "ÉS", "VAGY" };
        private string feltoszl1;
        private string feltoszl2;
        private string muvel1;
        private string muvel2;
        private string leker1;
        private string leker2;
        private string kapcs;
        private int kritfelt1;
        private int kritfelt2;
        private string kriterium1;
        private string kriterium2;




        private void Clear()
        {           
            comboBox3.Items.Clear();
            comboBox3.Text = string.Empty;
            comboBox4.Items.Clear();
            comboBox4.Text = string.Empty;
            comboBox5.Items.Clear();
            comboBox5.Text = string.Empty;
            comboBox6.Items.Clear();
            comboBox6.Text = string.Empty;
            comboBox7.Items.Clear();
            comboBox7.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();         
        }
        private void Feltetel1()
        {
           
            if (tablaValaszt.Text == "Autók")
            {
                for (int i = 0; i < autooszlopok.Length; i++)
                {
                    comboBox3.Items.Add(autooszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Ügyfelek")
            {
                for (int i = 0; i < ugyfeloszlopok.Length; i++)
                {
                    comboBox3.Items.Add(ugyfeloszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Nyilvántartás")
            {
                for (int i = 0; i < nyilvantartasoszlopok.Length; i++)
                {
                    comboBox3.Items.Add(nyilvantartasoszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Árkategóriák")
            {
                for (int i = 0; i < arkategoriaoszlopok.Length; i++)
                {
                    comboBox3.Items.Add(arkategoriaoszlopok[i]);
                }
            }

        }
        private void Feltetel2()
        {
            
         
            for (int i = 0; i < kapcsolat.Length; i++)
            {
                comboBox7.Items.Add(kapcsolat[i]);
            }
            if (tablaValaszt.Text == "Autók")
            {
                for (int i = 0; i < autooszlopok.Length; i++)
                {
                    comboBox5.Items.Add(autooszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Ügyfelek")
            {
                for (int i = 0; i < ugyfeloszlopok.Length; i++)
                {
                    comboBox5.Items.Add(ugyfeloszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Nyilvántartás")
            {
                for (int i = 0; i < nyilvantartasoszlopok.Length; i++)
                {
                    comboBox5.Items.Add(nyilvantartasoszlopok[i]);
                }
            }
            if (tablaValaszt.Text == "Árkategóriák")
            {
                for (int i = 0; i < arkategoriaoszlopok.Length; i++)
                {
                    comboBox5.Items.Add(arkategoriaoszlopok[i]);
                }
            }


        }
        private void FeltOszl1()
        {
            if (comboBox3.Text == "Azonosító") { feltoszl1 = "azo"; }
            if (comboBox3.Text == "Márka") { feltoszl1 = "marka"; }
            if (comboBox3.Text == "Típus") { feltoszl1 = "tipus"; }
            if (comboBox3.Text == "Évjárat") { feltoszl1 = "evjarat"; }
            if (comboBox3.Text == "Ülésszám") { feltoszl1 = "ulesszam"; }
            if (comboBox3.Text == "Váltó") { feltoszl1 = "valto"; }
            if (comboBox3.Text == "Üzemanyag") { feltoszl1 = "uzemanyag"; }
            if (comboBox3.Text == "Rendszám") { feltoszl1 = "rendszam"; }
            if (comboBox3.Text == "Árkategória") { feltoszl1 = "arkategoria"; }
            if (comboBox3.Text == "Csomagtartó") { feltoszl1 = "csomagtarto"; }
            if (comboBox3.Text == "GPS") { feltoszl1 = "gps"; }
            if (comboBox3.Text == "Ajtószám") { feltoszl1 = "ajtoszam"; }
            if (comboBox3.Text == "Ügyfélazonosító") { feltoszl1 = "ugyfelazo"; }
            if (comboBox3.Text == "Név") { feltoszl1 = "nev"; }
            if (comboBox3.Text == "Nem") { feltoszl1 = "nem"; }
            if (comboBox3.Text == "Irányítószám") { feltoszl1 = "iranyitoszam"; }
            if (comboBox3.Text == "Ország") { feltoszl1 = "orszag"; }
            if (comboBox3.Text == "Település") { feltoszl1 = "telepules"; }
            if (comboBox3.Text == "Cím") { feltoszl1 = "cim"; }
            if (comboBox3.Text == "E-mail") { feltoszl1 = "email"; }
            if (comboBox3.Text == "Telefon") { feltoszl1 = "telefon"; }
            if (comboBox3.Text == "Autóazonosító") { feltoszl1 = "autoazo"; }
            if (comboBox3.Text == "Ügyfélazonosító") { feltoszl1 = "ugyfelazo"; }
            if (comboBox3.Text == "Bérlésazonosító") { feltoszl1 = "berlesazo"; }
            if (comboBox3.Text == "Bérlés kezdőnapja") { feltoszl1 = "kezdonap"; }
            if (comboBox3.Text == "Bérlés zárónapja") { feltoszl1 = "zaronap"; }
            if (comboBox3.Text == "Egységár") { feltoszl1 = "berletidij"; }
            if (comboBox3.Text == "Bérlés összege") { feltoszl1 = "osszeg"; }
            if (comboBox3.Text == "Kategória") { feltoszl1 = "kategoria"; }
            if (comboBox3.Text == "Egységár") { feltoszl1 = "ar"; }
            if (comboBox3.Text == "Kaució") { feltoszl1 = "kaucio"; }
        }
        private void FeltOszl2()
        {
            if (comboBox5.Text == "Azonosító") { feltoszl2 = "azo"; }
            if (comboBox5.Text == "Márka") { feltoszl2 = "marka"; }
            if (comboBox5.Text == "Típus") { feltoszl2 = "tipus"; }
            if (comboBox5.Text == "Évjárat") { feltoszl2 = "evjarat"; }
            if (comboBox5.Text == "Ülésszám") { feltoszl2 = "ulesszam"; }
            if (comboBox5.Text == "Váltó") { feltoszl2 = "valto"; }
            if (comboBox5.Text == "Üzemanyag") { feltoszl2 = "uzemanyag"; }
            if (comboBox5.Text == "Rendszám") { feltoszl2 = "rendszam"; }
            if (comboBox5.Text == "Árkategória") { feltoszl2 = "arkategoria"; }
            if (comboBox5.Text == "Csomagtartó") { feltoszl2 = "csomagtarto"; }
            if (comboBox5.Text == "GPS") { feltoszl2 = "gps"; }
            if (comboBox5.Text == "Ajtószám") { feltoszl2 = "ajtoszam"; }
            if (comboBox5.Text == "Ügyfélazonosító") { feltoszl2 = "ugyfelazo"; }
            if (comboBox5.Text == "Név") { feltoszl2 = "nev"; }
            if (comboBox5.Text == "Nem") { feltoszl2 = "nem"; }
            if (comboBox5.Text == "Irányítószám") { feltoszl2 = "iranyitoszam"; }
            if (comboBox5.Text == "Ország") { feltoszl2 = "orszag"; }
            if (comboBox5.Text == "Település") { feltoszl2 = "telepules"; }
            if (comboBox5.Text == "Cím") { feltoszl2 = "cim"; }
            if (comboBox5.Text == "E-mail") { feltoszl2 = "email"; }
            if (comboBox5.Text == "Telefon") { feltoszl2 = "telefon"; }
            if (comboBox5.Text == "Autóazonosító") { feltoszl2 = "autoazo"; }
            if (comboBox5.Text == "Ügyfélazonosító") { feltoszl2 = "ugyfelazo"; }
            if (comboBox5.Text == "Bérlésazonosító") { feltoszl2 = "berlesazo"; }
            if (comboBox5.Text == "Bérlés kezdőnapja") { feltoszl2 = "kezdonap"; }
            if (comboBox5.Text == "Bérlés zárónapja") { feltoszl2 = "zaronap"; }
            if (comboBox5.Text == "Egységár") { feltoszl2 = "berletidij"; }
            if (comboBox5.Text == "Bérlés összege") { feltoszl2 = "osszeg"; }
            if (comboBox5.Text == "Kategória") { feltoszl2 = "kategoria"; }
            if (comboBox5.Text == "Egységár") { feltoszl2 = "ar"; }
            if (comboBox5.Text == "Kaució") { feltoszl2 = "kaucio"; }
        }
      
        private void Lekeres1()
        {
            
            if(kritfelt1==1 && muvel1 != "LIKE")
            { kriterium1 = "\"" + textBox1.Text + "\""; }
            if(kritfelt1==1 && muvel1 == "LIKE")
            { kriterium1 = "\"%" + textBox1.Text + "%\""; }
            if(kritfelt1==2)
            { kriterium1 = textBox1.Text; }

                if (tablaValaszt.Text == "Autók")
                { leker1 = "Select azo AS Azonosító, marka AS Márka, tipus AS Típus, evjarat AS Évjárat, ulesszam AS Ülésszám, valto AS Váltó, uzemanyag AS Üzemanyag, rendszam AS Rendszám, arkategoria AS Árkategória, csomagtarto AS Csomagtartó, gps AS GPS, ajtoszam AS Ajtószám FROM auto WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1; }
                if (tablaValaszt.Text == "Ügyfelek")
                { leker1 = "Select ugyfelazo AS Ügyfélazonosító, nev AS Név, iranyitoszam AS Irányítószám, orszag AS Ország, telepules AS Település, cim AS Cím, email AS Email, telefon AS Telefon FROM ugyfel WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1; }
                if (tablaValaszt.Text == "Nyilvántartás")
                { leker1 = "Select autoazo AS Autóazonosító, ugyfelazo AS Ügyfélazonosító, berlesazo AS Bérlésazonosító, kezdonap AS Bérléskezdőnapja, zaronap AS Bérlészárónapja, berletidij AS Egységár, osszeg AS Bérlésösszege FROM nyilvantartas WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1; }
                if (tablaValaszt.Text == "Árkategóriák")
                { leker1 = "Select kategoria AS Kategória, ar AS Egységár, kaucio AS Kaució FROM arkategoria WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1; }

            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(leker1, kapcsolat) ;
            mda.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close();
        }
        private void Lekeres2()
        {
            if (kritfelt1 == 1 && muvel1 != "LIKE")
            { kriterium1 = "\"" + textBox1.Text + "\""; }
            if (kritfelt1 == 1 && muvel1 == "LIKE")
            { kriterium1 = "\"%" + textBox1.Text + "%\""; }
            if (kritfelt1 == 2)
            { kriterium1 = textBox1.Text; }

            if (kritfelt2 == 1 && muvel2 != "LIKE")
            { kriterium2 = "\"" + textBox2.Text + "\""; }
            if (kritfelt2 == 1 && muvel2 == "LIKE")
            { kriterium2 = "\"%" + textBox2.Text + "%\""; }
            if (kritfelt2 == 2)
            { kriterium2 = textBox2.Text; }

            if (tablaValaszt.Text == "Autók")
            { leker2 = "Select azo AS Azonosító, marka AS Márka, tipus AS Típus, evjarat AS Évjárat, ulesszam AS Ülésszám, valto AS Váltó, uzemanyag AS Üzemanyag, rendszam AS Rendszám, arkategoria AS Árkategória, csomagtarto AS Csomagtartó, gps AS GPS, ajtoszam AS Ajtószám FROM auto WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1 + " " + kapcs + " " + feltoszl2 + " " + muvel2 + " " + kriterium2; }
            if (tablaValaszt.Text == "Ügyfelek")
            { leker2 = "Select ugyfelazo AS Ügyfélazonosító, nev AS Név, iranyitoszam AS Irányítószám, orszag AS Ország, telepules AS Település, cim AS Cím, email AS Email, telefon AS Telefon FROM ugyfel WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1 + " " + kapcs + " " + feltoszl2 + " " + muvel2 + " " +kriterium2; }
            if (tablaValaszt.Text == "Nyilvántartás")
            { leker2 = "Select autoazo AS Autóazonosító, ugyfelazo AS Ügyfélazonosító, berlesazo AS Bérlésazonosító, kezdonap AS Bérléskezdőnapja, zaronap AS Bérlészárónapja, berletidij AS Egységár, osszeg AS Bérlésösszege FROM nyilvantartas WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1 + " " + kapcs + " " + feltoszl2 + " " + muvel2 + " " + kriterium2; }
            if (tablaValaszt.Text == "Árkategóriák")
            { leker2 = "Select kategoria AS Kategória, ar AS Egységár, kaucio AS Kaució FROM arkategoria WHERE " + feltoszl1 + " " + muvel1 + " " + kriterium1 + " " + kapcs + " " + feltoszl2 + " " + muvel2 + " " + kriterium2; }

            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(leker2, kapcsolat);
            mda.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close();
        }
    
        private void ListAuto()
        {
            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter auto = new MySqlDataAdapter("Select azo AS Azonosító, marka AS Márka, tipus AS Típus, evjarat AS Évjárat, ulesszam AS Ülésszám, valto AS Váltó, uzemanyag AS Üzemanyag, rendszam AS Rendszám, arkategoria AS Árkategória, csomagtarto AS Csomagtartó, gps AS GPS, ajtoszam AS Ajtószám FROM auto", kapcsolat);
            auto.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close(); 
        }
        private void ListUgyfel()
        {
            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter ugyfel = new MySqlDataAdapter("Select ugyfelazo AS Ügyfélazonosító, nev AS Név, iranyitoszam AS Irányítószám, orszag AS Ország, telepules AS Település, cim AS Cím, email AS Email, telefon AS Telefon FROM ugyfel", kapcsolat);
            ugyfel.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close();
        }
        private void ListNyilvantartas()
        {
            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter nyilv = new MySqlDataAdapter("Select autoazo AS Autóazonosító, ugyfelazo AS Ügyfélazonosító, berlesazo AS Bérlésazonosító, kezdonap AS Bérléskezdőnapja, zaronap AS Bérlészárónapja, berletidij AS Egységár, osszeg AS Bérlésösszege FROM nyilvantartas", kapcsolat);
            nyilv.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close();
        }
        private void ListArkategoria()
        {
            DataTable table = new DataTable();
            MySqlConnection kapcsolat = new MySqlConnection("Server=localhost;User ID=root;Database=vizsga");
            kapcsolat.Open();
            MySqlDataAdapter arkat = new MySqlDataAdapter("Select kategoria AS Kategória, ar AS Egységár, kaucio AS Kaució FROM arkategoria", kapcsolat);
            arkat.Fill(table);
            dataGridView1.DataSource = table;
            kapcsolat.Close();
        }

        public Kezdo()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;

            Clear();

            if (tablaValaszt.Text == "Autók") { ListAuto(); }
            if (tablaValaszt.Text == "Ügyfelek") { ListUgyfel(); }
            if (tablaValaszt.Text == "Nyilvántartás") { ListNyilvantartas(); }
            if (tablaValaszt.Text == "Árkategóriák") { ListArkategoria(); }           
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Clear();
            if (comboBox2.Text == "1") { Feltetel1(); }         
            if (comboBox2.Text == "2")
            {
                Feltetel1();
                Feltetel2();
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Text = string.Empty;
            textBox1.Clear();           
            FeltOszl1();
            if (comboBox3.Text == "Márka" || comboBox3.Text == "Típus" || comboBox3.Text == "Váltó" || comboBox3.Text == "Üzemanyag" || comboBox3.Text == "Rendszám" || comboBox3.Text == "Árkategória" || comboBox3.Text == "GPS" || comboBox3.Text == "Név" || comboBox3.Text == "Ország" || comboBox3.Text == "Település" || comboBox3.Text == "Cím" || comboBox3.Text == "E-mail" || comboBox3.Text == "telefon" || comboBox3.Text == "Kategória")
            {             
                comboBox4.Items.Add("=");
                comboBox4.Items.Add("!=");
                comboBox4.Items.Add("LIKE");
                kritfelt1 = 1;
            }
            else
            {
                comboBox4.Items.Add("=");
                comboBox4.Items.Add(">");
                comboBox4.Items.Add("<");
                comboBox4.Items.Add(">=");
                comboBox4.Items.Add("<=");
                comboBox4.Items.Add("!=");
                kritfelt1 = 2;
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox6.Text = string.Empty;
            textBox2.Clear();

            FeltOszl2();

            if (comboBox5.Text == "Márka" || comboBox5.Text == "Típus" || comboBox5.Text == "Váltó" || comboBox5.Text == "Üzemanyag" || comboBox5.Text == "Rendszám" || comboBox5.Text == "Árkategória" || comboBox5.Text == "GPS" || comboBox5.Text == "Név" || comboBox5.Text == "Nem" || comboBox5.Text == "Ország" || comboBox5.Text == "Település" || comboBox5.Text == "Cím" || comboBox5.Text == "E-mail" || comboBox5.Text == "telefon" || comboBox5.Text == "Kategória")
            {
                comboBox6.Items.Add("=");
                comboBox6.Items.Add("!=");
                comboBox6.Items.Add("LIKE");
                kritfelt2 = 1;
            }
            else
            {
                comboBox6.Items.Add("=");
                comboBox6.Items.Add(">");
                comboBox6.Items.Add("<");
                comboBox6.Items.Add(">=");
                comboBox6.Items.Add("<=");
                comboBox6.Items.Add("!=");
                kritfelt2 = 2;
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            muvel1 = comboBox4.Text;
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            muvel2 = comboBox6.Text;
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "ÉS")
            { kapcs = "AND"; }
            if (comboBox7.Text == "VAGY")
            { kapcs = "OR"; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          if(comboBox2.Text=="1")
            {
                Lekeres1();
            }
          if(comboBox2.Text=="2")
            {
                Lekeres2();
            }
        }

        private void autóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autok autoform = new Autok();
            autoform.ShowDialog();
        }
        private void bezárásToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ügyfelekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ugyfelek ugyfelek = new Ugyfelek();
            ugyfelek.ShowDialog();
        }
        private void nyilvántartásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nyilvantartas nyilvan = new Nyilvantartas();
            nyilvan.ShowDialog();
        }
        private void árkategóriákToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Arkategoria arkat = new Arkategoria();
            arkat.ShowDialog();
        }







        private void műveletekToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Kezdo_Load(object sender, EventArgs e)
        {

        }

      
    }
}
