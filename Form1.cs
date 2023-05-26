using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileCsv_Masserini2
{
    public partial class Form1 : Form
    {
        #region Dichiarazioni
        public Random r = new Random();
        public string fileName = @"masserini1.csv";
        public string fileName1 = @"masserini.csv";
        public string n, anno, nazione, note,p;
        public char de = ';';
        public int LMn = 0, Ln = 0, tempo, VRandom, ad = 0, contatore = 0, i = 0, L,MKwh;
        public bool Vbooleano;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Pulsanti
        private void button1_Click(object sender, EventArgs e)
        {
            Istruzione1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di campi è: " + Istruzione2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di caratteri è: " + Istruzione3());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            int[] MaxC = new int[contatore];
            MaxC = Istruzione3A();
            for (int i = 0; i < contatore; i++)
            {
                listView1.Items.Add(MaxC[i].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Istruzione4();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            anno = textBox1.Text;
            nazione = textBox2.Text;
            MKwh = int.Parse(textBox3.Text);
            note = textBox4.Text;
            VRandom = int.Parse(textBox5.Text);
            Vbooleano = bool.Parse(textBox6.Text);
            Istruzione5();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Istruzione6();            
        }
        private void button12_Click(object sender, EventArgs e)
        {
            L = Istruzione7(textBox7.Text);
            if (L != -1)
            {
                MessageBox.Show("Il tuo valore è stato trovato alla riga: " + L);
            }
            else
            {
                MessageBox.Show("La ricerca non ha avuto successo");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int riga = Istruzione7(textBox8.Text);
            anno = textBox1.Text;
            nazione = textBox2.Text;
            MKwh = int.Parse(textBox3.Text);
            note = textBox4.Text;
            VRandom = int.Parse(textBox5.Text);
            Vbooleano = bool.Parse(textBox6.Text);
            Istruzione8();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Istruzione9();
        }

        #endregion

        #region funzioni di servizio
        private void Istruzione1()
        {
            StreamWriter writer = new StreamWriter(fileName, append: false);
            StreamReader reader = new StreamReader(fileName1);
            n = reader.ReadLine();
            while (n != null)
            {
                if (i == 0)
                {
                    writer.WriteLine(n + de + "Mio valore" + de + "Cancellazione Logica");
                }
                else
                {
                    int Nr = r.Next(10, 21);
                    writer.WriteLine(n + de + Nr + de + "false");
                }
                i++;
                n = reader.ReadLine();
            }
            writer.Close();
            reader.Close();
        }
        private int Istruzione2()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            reader.Close();
            contatore = n.Split(de).Length;
            return contatore;
        }

        private int Istruzione3()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            while (n != null)
            {
                Ln = n.Length;
                if (i != 0)
                {
                    if (LMn < Ln)
                    {
                        LMn = n.Length;
                    }
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
            return LMn;
        }

        private int[] Istruzione3A()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            int[] LMassima = new int[contatore];
            n = reader.ReadLine();
            while (n != null)
            {
                string[] split = n.Split(de);
                string[] array = new string[contatore];
                for (int i = 0; i < contatore; i++)
                {
                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    n = reader.ReadLine();
                    ad = 0;
                    while (n != null)
                    {
                        string[] stringaSplit = n.Split(de);
                        if (ad != 0)
                        {
                            if (LMassima[i] < stringaSplit[i].Length)
                            {
                                LMassima[i] = stringaSplit[i].Length;
                            }
                        }
                        ad++;
                        n = reader.ReadLine();
                    }
                }
            }
            reader.Close();
            return LMassima;
        }

        private void Istruzione4()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("Lori.csv");
            n = reader.ReadLine();
            while (n != null)
            {
                if (i != 0)
                {
                    writer.WriteLine(n.PadRight(70));
                }
                else
                {
                    writer.WriteLine(n);
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
            writer.Close();
            File.Replace("Lori.csv", fileName, "backup.csv");
        }

        private void Istruzione5()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("Lori.csv");
            n = reader.ReadLine();
            while (n != null)
            {
                writer.WriteLine(n);
                n = reader.ReadLine();
            }
            writer.WriteLine(anno + de + nazione + de + MKwh + de + note + de + VRandom + de + Vbooleano);
            writer.Close();
            reader.Close();
            File.Replace("Lori.csv", fileName, "backup.csv");
        }

        private void Istruzione6()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            while (n != null)
            {
                String[] split = n.Split(de);
                String[] split1 = split[5].Split(' ');
                if (split1[0] == "false")
                {
                    listView1.Items.Add(split[0] + de + split[1] + de + split[2]);
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
        }

        private int Istruzione7(string p)
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            i = 0;
            while (n != null)
            {
                String[] split1 = n.Split(de);
                if (split1[2] == p)
                {
                    reader.Close();
                    return i;
                }
                n = reader.ReadLine();
                i++;
            }
            return -1;

        }
        private int Caratteri()
        {
           int contatore = 0;
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            reader.Close();
            contatore = n.Split(de).Length;
            return contatore;
        }   
        private void Istruzione8()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("Lori.csv");
            i = 0;
            n = reader.ReadLine();
            while(n != null)
            {
                if (i != 0)
                {
                    string[] split1 = n.Split(de);
                    int CampoU = int.Parse(split1[2]);
                    if(CampoU.ToString() == textBox8.Text)
                    {
                        writer.WriteLine(anno + de + nazione + de + MKwh + de + note + de + VRandom + de + Vbooleano);
                    }
                    else
                    {
                        writer.WriteLine(n);
                    }
                }
                else
                {
                    writer.WriteLine(n);
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
            writer.Close();
            File.Replace("Lori.csv", fileName, "backup.csv");
        }
        
        private void Istruzione9()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("Lori.csv");
            i = 0;
            n = reader.ReadLine();
            while (n != null)
            {
                if(i != 0)
                {
                    string[] split = n.Split(de);
                    if (split[2] == textBox9.Text)
                    {
                        split[5] = "true";
                        for(int i = 0; i < split.Length; i++)
                        {
                            if (i == split.Length - 1) n = split[i];
                            else n = split[i] + de;
                            
                           
                        }   
                    }
                    writer.WriteLine(n);
                }
                i++;
            }
            reader.Close();
            writer.Close();
            File.Replace("Lori.csv", fileName, "backup.csv");
            File.Delete("Lori.csv");
        }
        #endregion
    }
}
