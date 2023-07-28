using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace calcolatrice_v0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variabili

        //dichiarato un array con 10 variabili all'interno

        string[] valori = new string[10];           //si prende il valore dal TexBox e lo salva
        double[] valorisalvati = new double[10];    //converte la stringa di valori in double e li salva
        string[] operatori = new string[10];        //per settare in memoria gli operatori premuti
        int a = 0;                                  //indice per l'array valori
        int b = 0;                                  //indice per l'array valorisalvati
                                                    //N.B: sia valori che valorisalvati contengono le stesse variabili, solo che la seconda me lo converte in double
        int contatore = 0;                          //conta quante volte è stato premuto un operatore matematico  
        bool infinity = false;                      //per gestire le eccezzioni nella divisione  

        //List <string> list = new List<string>();  // creata solo a scopo di studio del C#, non serve per il programma

        #endregion

        #region pulsanti calcolatrice

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //list.Add (textBox1.Text);     //creata sempre a scopo di studi
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteInTextBox("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteInTextBox("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteInTextBox("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WriteInTextBox("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WriteInTextBox("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WriteInTextBox("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WriteInTextBox("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WriteInTextBox("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WriteInTextBox("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
           WriteInTextBox("0");
        }

        private void uguale_Click(object sender, EventArgs e)
        {
            //non serve resettare queste variabili in quanto uscita dalla funzione vengono distrutte
            int c = 0;      //variabili per ciclare i vari valori degli array sul switch, sono uguali alle variabili int a, int b_
            int d = 1;      //solo che si chiamano differente
            int f = 0;

            double risultato = 0;

            if (contatore == 1) 
                d = contatore; 

            try
            {
                valori[a] = textBox1.Text;
                valorisalvati[b] = Convert.ToDouble(valori[a]);
            }
            catch (System.FormatException k)
            {
                textBox1.Text = k.Message;
                infinity = true;
                return;
            }

            foreach (string x in operatori)
            {
                switch (operatori[f])
                {
                    case "diviso":
                        {
                            risultato = valorisalvati[c] / valorisalvati[d];
                            c += 1;
                            d += 1;
                            
                            if (true == double.IsInfinity(risultato) || true == double.IsNaN(risultato))
                            {
                                textBox1.Text = "Non è possibile dividere per 0";
                                ResetVariabili();
                                infinity = true;
                                return;                 //esce dalla funzione
                            }

                            valorisalvati[c] = risultato;
                            f += 1;

                            break;
                        }

                    case "per":
                        {
                            risultato = valorisalvati[c] * valorisalvati[d];
                            c += 1;
                            d += 1;
                            f += 1;
                            
                            valorisalvati[c] = risultato;

                            break;
                        }

                    case "più":
                        {
                            risultato = valorisalvati[c] + valorisalvati[d];
                            c += 1;
                            d += 1;
                            f += 1;
                            
                            valorisalvati[c] = risultato;

                            break;
                        }

                    case "meno":
                        {
                            risultato = valorisalvati[c] - valorisalvati[d];
                            c += 1;
                            d += 1;
                            f += 1;
                            
                            valorisalvati[c] = risultato;

                            break;
                        }
                }


            }

            // stampo il risultato e resetto le variabili così da poter usare il risultato stesso come base_ 
            //per fare altre operazioni 
            textBox1.Text = risultato.ToString();
            ResetVariabili();
        }

        private void canc_Click(object sender, EventArgs e)
        {
            ResetVariabili();
            textBox1.Text = "";
        }

        #endregion

        #region operatori

        private void divisione_Click(object sender, EventArgs e)
        {
            Conversione();
            CiclOperatore("diviso");

        }

        private void moltiplicazione_Click(object sender, EventArgs e)
        {
            Conversione();
            CiclOperatore("per");
        }
        private void sottrazione_Click(object sender, EventArgs e)
        {
            Conversione();
            CiclOperatore("meno");
        }

        private void addizione_Click(object sender, EventArgs e)
        {
            Conversione();
            CiclOperatore("più");
        }
        #endregion

        #region Metodi
        private void CiclOperatore(string operazione)
        {
            operatori[b] = operazione;
            a += 1;
            b += 1;
            contatore += 1;
            textBox1.Text = "";
        }

        private void WriteInTextBox(string value)
        {
            if (infinity == true)
            {
                textBox1.Text = value;
                infinity = false;
            }
            else
                textBox1.Text = textBox1.Text + value;
        }

        private double Conversione()
        {
            try
            {
                valori[a] = textBox1.Text;
                valorisalvati[b] = Convert.ToDouble(valori[a]);
            }
            catch(Exception k)
            {
                textBox1.Text = k.Message;
                infinity = true;
                
            }

            return valorisalvati[b];
        }

        private void ResetVariabili()
        {
            Array.Clear(valori, 0, valori.Length);
            Array.Clear(valorisalvati, 0, valorisalvati.Length);
            Array.Clear(operatori, 0, operatori.Length);
            a = 0;
            b = 0;
            contatore = 0;
            infinity = false;
        }

        #endregion




        


       

        
    }
}
