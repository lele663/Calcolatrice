using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        //dichiarato un array con 10 variabili all'interno
        string[] valori = new string[10];//si prende il valore dal TexBox e lo salva
        double[] valorisalvati = new double[10];//converte la stringa di valori in double e li salva
        string[] operatori = new string[10]; //per settare in memoria gli operatori premuti
        int a = 0;//indice per l'array valori
        int b = 0;//indice per l'array valorisalvati
        int contatore = 0;//conta quante volte è stato premuto un operatore matematico 
        string operatore;//setta lo switch, memorizzandosi quando è premuto un operatore 
        bool infinity = false;
        //List <string> list = new List<string>();
        


        #region pulsanti calcolatrice

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //list.Add (textBox1.Text);
            //chidere come prelevare il valore
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "1";
                infinity = false;   
            }
            else
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "2";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "3";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "4";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "5";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "6";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "7";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "8";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "9";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (infinity == true)
            {
                textBox1.Text = "0";
                infinity = false;
            }
            else
            textBox1.Text = textBox1.Text + "0";
        }
        #endregion

        #region operatori
        private void divisione_Click(object sender, EventArgs e)
        {
            
            valori[a] = textBox1.Text;
            valorisalvati[b] = Convert.ToDouble(valori[a]);
            operatori[b] = "diviso";
            a += 1;
            b += 1;
            contatore += 1;
            textBox1.Text = "";
            operatore = "divisione";
            
      
        }

        private void moltiplicazione_Click(object sender, EventArgs e)
        {
            valori[a] = textBox1.Text;
            valorisalvati[b] = Convert.ToDouble(valori[a]);
            operatori[b] = "per";
            a += 1;
            b += 1;
            contatore += 1;
            textBox1.Text = "";
            operatore = "moltiplicazione";
        }
        private void sottrazione_Click(object sender, EventArgs e)
        {
            valori[a] = textBox1.Text;
            valorisalvati[b] = Convert.ToDouble(valori[a]);
            operatori[b] = "meno";
            a += 1;
            b += 1;
            contatore += 1;
            textBox1.Text = "";
            operatore = "sottrazione";
        }

        private void addizione_Click(object sender, EventArgs e)
        {
            valori[a] = textBox1.Text;
            valorisalvati[b] = Convert.ToDouble(valori[a]);
            operatori[b] = "più";
            a += 1;
            b += 1;
            contatore += 1;
            textBox1.Text = "";
            operatore = "addizione";
        }
        #endregion

        private void uguale_Click(object sender, EventArgs e)
        {
            int c = 0; //non serve resettarle in quanto uscita dalla funzione vengono distrutte
            int d = 1;//variabili per ciclare sul switch
            int f = 0;

            double risultato = 0;
            if (contatore == 1)
            {
                d = contatore;
            } 

            valori[a] = textBox1.Text;
            valorisalvati[b] = Convert.ToDouble(valori[a]);

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
                                return;//esce dalla funzione
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
                            valorisalvati[c] = risultato;
                            f += 1;
                        break;
                    }
                    case "più":
                    {                                                       
                            risultato = valorisalvati[c] + valorisalvati[d];
                            c += 1;
                            d += 1;
                            valorisalvati[c] = risultato;
                            f += 1;                            
                        break;
                    }
                    case "meno":
                    {                                                      
                            risultato = valorisalvati[c] - valorisalvati[d];
                            c += 1;
                            d += 1;
                            valorisalvati[c] = risultato;
                            f += 1;                            
                        break;
                    }

                }

            
            }            
            // stampo il risultato e resetto le variabili così da poter usare il risultato stesso come base 
            //per fare altre operazioni 
             textBox1 .Text = risultato.ToString();
             ResetVariabili();
        }

        #region reset variabili
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

        private void canc_Click(object sender, EventArgs e)
        {
            ResetVariabili();
            textBox1.Text = "";
        }
    }
}
//manca try catch per lo zero e l'ordine delle operazioni