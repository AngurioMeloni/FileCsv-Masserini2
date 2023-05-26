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
        private void button1_Click(object sender, EventArgs e) //pulsante di esecuzione della prima Istruzione
        {
            Istruzione1();//Richiamo alla Istruzione 1
            MessageBox.Show("Istruzione 1 eseguita con successo");
        }

        private void button2_Click(object sender, EventArgs e)// pulsante per l'esecuzione della Istruzione 2
        {
            MessageBox.Show("Il numero di campi è: " + Istruzione2());//messasggio di output che indica ill numero di campi che sono presenti nel file1
        }

        private void button3_Click(object sender, EventArgs e)// pulsante per l'esecuzione della Istruzione 3
        {
            MessageBox.Show("Il numero di caratteri è: " + Istruzione3());//messaggio di output che indica il numero di caratteri che sono presenti nel file1
        }

        private void button4_Click(object sender, EventArgs e)//pulsante per l'esecuzione della Istruzione 3A
        {
            listView1.Clear(); // pulizia della listview
            int[] MaxC = new int[contatore];//Dichiaro l'array massimoo numero di caratteri(MaxC)
            MaxC = Istruzione3A();//pongo l'array uguale alla funzione Istruzione3A
            for (int i = 0; i < contatore; i++)//ciclo for che mi permette di visualizzare i valori dell'array nella listview
            {
                listView1.Items.Add(MaxC[i].ToString());//visualizzazione dei valori dell'array nella listview
            }
        }

        private void button5_Click(object sender, EventArgs e)//pulsante per l'esecuzione della funzione 4 
        {
            Istruzione4();//richiamo alla funzione 4
            MessageBox.Show("Istruzione 4 eseguita con successo");//messaggio di output che indica che la funzione 4 è stata eseguita con successo
        }

        private void button6_Click(object sender, EventArgs e)//pulsante per mostrare la groupbox1
        {
            groupBox1.Show();//funzione che mostra la groupbox1
        }

        private void button11_Click(object sender, EventArgs e)//pulsante per l'esecuzione della funzione 5
        {
            anno = textBox1.Text;//pongo la variabile anno uguale al valore inserito nella textbox1
            nazione = textBox2.Text;//pongo la variabile nazione uguale al valore inserito nella textbox2
            MKwh = int.Parse(textBox3.Text);//pongo la variabile MKwh uguale al valore inserito nella textbox3
            note = textBox4.Text;//pongo la variabile note uguale al valore inserito nella textbox4
            VRandom = int.Parse(textBox5.Text);//pongo la variabile VRandom uguale al valore inserito nella textbox5
            Vbooleano = bool.Parse(textBox6.Text);//pongo la variabile Vbooleano uguale al valore inserito nella textbox6
            Istruzione5();//richiamo alla funzione 5
        }

        private void button7_Click(object sender, EventArgs e)//pulsante per l'esecuzione della funzione 6
        {
            listView1.Clear();//pulizia della listview
            Istruzione6();//richiamo alla funzione 6        
        }
        private void button8_Click(object sender, EventArgs e)//pulsante per mostrare la groupbox2
        {
            groupBox2.Show();//funzione che mostra la groupbox2
        }
        private void button12_Click(object sender, EventArgs e) //pulsante per l'esecuzione dell'istruzione 7 
        {
            L = Istruzione7(textBox7.Text);//pongo la variabile L uguale alla funzione 7
            if (L != -1)//se L è diverso da -1
            {
                MessageBox.Show("Il tuo valore è stato trovato alla riga: " + L);//messaggio di output che indica la riga in cui è stato trovato il valore
            }
            else//altrimenti
            {
                MessageBox.Show("La ricerca non ha avuto successo");//messaggio di output che indica che la ricerca non ha avuto successo
            }
        }

        private void button9_Click(object sender, EventArgs e)//pulsante per mostrare la groupbox1
        {
            groupBox1.Show();//funzione che mostra la groupbox1
        }

        private void button13_Click(object sender, EventArgs e)//pulsante per l'esecuzione della funzione 8
        {
            int riga = Istruzione7(textBox8.Text);//pongo la variabile riga uguale alla funzione 7
            anno = textBox1.Text;//pongo la variabile anno uguale al valore inserito nella textbox1
            nazione = textBox2.Text;//pongo la variabile nazione uguale al valore inserito nella textbox2
            MKwh = int.Parse(textBox3.Text);//pongo la variabile MKwh uguale al valore inserito nella textbox3
            note = textBox4.Text;//pongo la variabile note uguale al valore inserito nella textbox4
            VRandom = int.Parse(textBox5.Text);//pongo la variabile VRandom uguale al valore inserito nella textbox5
            Vbooleano = bool.Parse(textBox6.Text);//pongo la variabile Vbooleano uguale al valore inserito nella textbox6
            Istruzione8();//richiamo alla funzione 8
        }

        private void button10_Click(object sender, EventArgs e)//pulsante per la mostrare la groupbox3
        {
            groupBox3.Show();//funzione che mostra la groupbox3
        }
        private void button14_Click(object sender, EventArgs e)//pulsante per l'esecuzione della funzione 9
        {
            Istruzione9();//richiamo alla funzione 9
        }

        #endregion

        #region funzioni di servizio
        private void Istruzione1()//funzione di generazione della scritta Mio valore dei valori random + il valore booleano per la cancellazione logica
        {
            StreamWriter writer = new StreamWriter(fileName, append: false);//dichiaro lo streamwriter
            StreamReader reader = new StreamReader(fileName1);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                if (i == 0)//se i è uguale a 0
                {
                    writer.WriteLine(n + de + "Mio valore" + de + "Cancellazione Logica");//scrivo nel file la prima riga con i nomi delle colonne
                }
                else//altrimenti
                {
                    int Nr = r.Next(10, 21);//genero un valore random
                    writer.WriteLine(n + de + Nr + de + "false");//scrivo nel file la colonna con i valori random e il valore booleano
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            writer.Close();//chiudo lo streamwriter
            reader.Close();//chiudo lo streamreader
        }
        private int Istruzione2()//funzione che mi permette di contare il numero dei campi
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            reader.Close();//chiudo lo streamreader
            contatore = n.Split(de).Length;//pongo la variabile contatore uguale al numero di campi
            return contatore;//ritorno il valore di contatore   
        }

        private int Istruzione3()//funzione che mi permette di contare il numero delle righe
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                Ln = n.Length;//pongo la variabile Ln uguale alla lunghezza della riga
                if (i != 0)//se i è diverso da 0
                {
                    if (LMn < Ln)//se LMn è minore di Ln
                    {
                        LMn = n.Length;//pongo la variabile LMn uguale alla lunghezza della riga
                    }
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            reader.Close();//chiudo lo streamreader
            return LMn;//ritorno il valore di LMn
        }

        private int[] Istruzione3A()//funzione che mi stampa il numero di caratteri massimo presente in ogni colonna
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            int[] LMassima = new int[contatore];//dichiaro un array di interi
            n = reader.ReadLine();//leggo la riga successiva
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                string[] split = n.Split(de);//dichiaro un array di stringhe
                string[] array = new string[contatore];//dichiaro un array di stringhe
                for (int i = 0; i < contatore; i++)//ciclo for che mi permette di scorrere tutte le colonne
                {
                    reader.DiscardBufferedData();//pulisco il buffer
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);//mi posiziono all'inizio del file
                    n = reader.ReadLine();//leggo la riga successiva
                    ad = 0;//pongo la variabile ad uguale a 0
                    while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
                    {
                        string[] stringaSplit = n.Split(de);//dichiaro un array di stringhe
                        if (ad != 0)//se ad è diverso da 0
                        {
                            if (LMassima[i] < stringaSplit[i].Length)//se LMassima è minore della lunghezza della stringa
                            {
                                LMassima[i] = stringaSplit[i].Length;//pongo la variabile LMassima uguale alla lunghezza della stringa
                            }
                        }
                        ad++;//incremento ad
                        n = reader.ReadLine();//leggo la riga successiva
                    }
                }
            }
            reader.Close();//chiudo lo streamreader
            return LMassima;//ritorno il valore di LMassima
        }

        private void Istruzione4()//funzione di creazione degli spazi per avere i record di lunghezza identica
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            StreamWriter writer = new StreamWriter("Lori.csv");//dichiaro lo streamwriter
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                if (i != 0)//se i è diverso da 0
                {
                    writer.WriteLine(n.PadRight(70));//scrivo nel file la riga con la lunghezza di 70 caratteri
                }
                else//altrimenti
                {
                    writer.WriteLine(n);//scrivo nel file la riga
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            reader.Close();//chiudo lo streamreader
            writer.Close();//chiudo lo streamwriter
            File.Replace("Lori.csv", fileName, "backup.csv");//sostituisco il file originale con il file modificato
        }

        private void Istruzione5()//funzione 5 che mi permette la creazione di un record
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            StreamWriter writer = new StreamWriter("Lori.csv");//dichiaro lo streamwriter
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                writer.WriteLine(n);//scrivo nel file la riga
                n = reader.ReadLine();//leggo la riga successiva
            }   
            writer.WriteLine(anno + de + nazione + de + MKwh + de + note + de + VRandom + de + Vbooleano);//scrivo nel file il record
            writer.Close();//chiudo lo streamwriter
            reader.Close();//chiudo lo streamreader
            File.Replace("Lori.csv", fileName, "backup.csv");//sostituisco il file originale con il file modificato
        }

        private void Istruzione6()//Funzione che mi sta tre campi a scelta di ogni record
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                String[] split = n.Split(de);//dichiaro un array di stringhe
                String[] split1 = split[5].Split(' ');//dichiaro un array di stringhe
                if (split1[0] == "false")//se split1 è uguale a false
                {
                    listView1.Items.Add(split[0] + de + split[1] + de + split[2]);//aggiungo alla listview i 3 campi
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            reader.Close();//chiudo lo streamreader
        }

        private int Istruzione7(string p)//funzione che mi permette di cercare il record con il campo univoco scelto(Milioni di Kw/h)
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            i = 0;//pongo la variabile i uguale a 0
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                String[] split1 = n.Split(de);//dichiaro un array di stringhe
                if (split1[2] == p)//se split1 è uguale a p
                {
                    reader.Close();//chiudo lo streamreader
                    return i;//ritorno il valore di i
                }
                n = reader.ReadLine();//leggo la riga successiva
                i++;//incremento i
            }
            return -1;//ritorno -1

        }
        private void Istruzione8()//funzione che permette la modifica di un record già esistente
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            StreamWriter writer = new StreamWriter("Lori.csv");//dichiaro lo streamwriter
            i = 0;//pongo la variabile i uguale a 0
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while(n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                if (i != 0)//se i è diverso da 0
                {
                    string[] split1 = n.Split(de);//dichiaro un array di stringhe
                    int CampoU = int.Parse(split1[2]);//dichiaro la variabile CampoU e la converto in intero
                    if(CampoU.ToString() == textBox8.Text)//se CampoU è uguale a textBox8
                    {
                        writer.WriteLine(anno + de + nazione + de + MKwh + de + note + de + VRandom + de + Vbooleano);//scrivo nel file il record
                    }
                    else//altrimenti
                    {
                        writer.WriteLine(n);//scrivo nel file la riga
                    }   
                }
                else//altrimenti
                {
                    writer.WriteLine(n);//scrivo nel file la riga
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            reader.Close();//chiudo lo streamreader
            writer.Close();//chiudo lo streamwriter
            File.Replace("Lori.csv", fileName, "backup.csv");//sostituisco il file originale con il file modificato
            File.Delete("Lori.csv");//elimino il file backup  
        }
        
        private void Istruzione9()//funzione 9 che permette la cancellazione logica di un record
        {
            StreamReader reader = new StreamReader(fileName);//dichiaro lo streamreader
            StreamWriter writer = new StreamWriter("Lori.csv");//dichiaro lo streamwriter
            i = 0;//pongo la variabile i uguale a 0
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                if(i != 0)//se i è diverso da 0 
                {
                    string[] split = n.Split(de);//dichiaro un array di stringhe
                    if (split[2] == textBox9.Text)//se split[2] è uguale al valore di textBox9
                    {
                        split[5] = "true";//pongo split[5] uguale a true
                        for (int i = 0; i < split.Length; i++)//ciclo for che mi permette di leggere tutte le righe del file
                        {
                            if (i == split.Length - 1) n = split[i];//se i è uguale a split.Length - 1 pongo n uguale a split[i]
                            else n = split[i] + de;//altrimenti pongo n uguale a split[i] + de
                        }
                    }           
                    writer.WriteLine(n);//scrivo nel file la riga
                }
                i++;//incremento i
            }
            reader.Close();//chiudo lo streamreader
            writer.Close();//chiudo lo streamwriter
            File.Replace("Lori.csv", fileName, "backup.csv");//sostituisco il file originale con il file modificato
            File.Delete("Lori.csv");//elimino il file backup
        }
        #endregion
    }
}
