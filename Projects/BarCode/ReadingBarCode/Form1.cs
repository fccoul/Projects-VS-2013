using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingBarCode
{
    public partial class Form1 : Form
    {
        #region variables
                DateTime _lastKeyStroke = new DateTime(0);
                List<char> _barcode = new List<char>(10);
                int _quantite = -1;
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = txtCodeBar;

            this.KeyPress += Form1_KeyPress;

           

            //---get values enumm...
            /*
            String val = CouleurScelles.Rouge.ToString();
            Char color = (char)CouleurScelles.Rouge;
            */
             
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check timing (keystrokes within 100 ms)
            TimeSpan elapsed = (DateTime.Now - _lastKeyStroke);
            if (elapsed.TotalMilliseconds > 100)
                _barcode.Clear();

            // record keystroke & timestamp
            _barcode.Add(e.KeyChar);
            _lastKeyStroke = DateTime.Now;

            // process barcode
            if (e.KeyChar == 13 && _barcode.Count > 0)
            {
                string msg = new String(_barcode.ToArray());
                MessageBox.Show(msg);
                _barcode.Clear();
            }
        }

        private void txtCodeBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCodeBar.Clear();
            // check timing (keystrokes within 100 ms)
            TimeSpan elapsed = (DateTime.Now - _lastKeyStroke);
            if (elapsed.TotalMilliseconds > 100)
                _barcode.Clear();

            // record keystroke & timestamp
            _barcode.Add(e.KeyChar);
            _lastKeyStroke = DateTime.Now;

            // process barcode
            if (e.KeyChar == 13 && _barcode.Count > 0)
            {
                string infos = new String(_barcode.ToArray());
                MessageBox.Show(infos);

                //-----------traitement
                try
                {
                    InfosScelle inf = new InfosScelle();
                    getInfos_BarCode(infos, out inf);

                    txtProvenance.Text = "Magasin Général";
                    txtExploitationOrigine.Text = "Treichville";
                    txtDateReception.Text = DateTime.Now.ToUniversalTime().ToString();
                    txtModificateur.Text = "FCO Admin";
                    txtTypeReception.Text = "Lot Complet";

                    txtOrigineScelle.Text = inf.OrigineScelle;
                    txtLotScelles.Text = inf.NumeroScelleDeb + " - " + inf.NumeroScelleFin;

                    dgvRangeScelles.Rows[0].Cells[0].Value = inf.NumeroScelleDeb;
                    dgvRangeScelles.Rows[0].Cells[1].Value = inf.NumeroScelleFin;
                    dgvRangeScelles.Rows[0].Cells[2].Value = inf.CouleurScelle;

                    _quantite = inf.Quantite;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



              
                //------------------------
                _barcode.Clear();
            }
        }

        private void getInfos_BarCode(string infos,out InfosScelle _InfosScelle)
        {
            //------si code (128 avec numdebut-numFin renseigne : V2200001-2200250I)
           int pos= infos.IndexOf('\r');
           infos = infos.Substring(0,pos);//--supperssion du retour chariot -fin de lign '\r'
            string[] tabInfos= infos.Split('-');
            char colorScelle =(char) tabInfos[0].First();
            char OrigineScelle = (char)tabInfos[1].Last();

            string numeroScelleDeb = tabInfos[0].Substring(1);
            string numroScelleFin = tabInfos[1].Substring(0,tabInfos[1].Length - 1);

            _InfosScelle = new InfosScelle { NumeroScelleDeb=numeroScelleDeb,
            NumeroScelleFin=numroScelleFin,
            CouleurScelle=Enum.GetName(typeof(CouleurScelles),colorScelle),
            OrigineScelle=Enum.GetName(typeof(OrigineScelles),OrigineScelle)

            ,Quantite=int.Parse(numroScelleFin)-int.Parse(numeroScelleDeb)
            };
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            if(dgvRangeScelles.Rows[0].Cells[0].Value!=null)
            { 
                    int numeroDepart = int.Parse(dgvRangeScelles.Rows[0].Cells[0].Value.ToString());
                   
                  var xx=Enumerable.Range(numeroDepart,_quantite);
                  MessageBox.Show("nombre de seclles du lot : " + xx.Count());
            }

            this.ActiveControl = txtCodeBar;
        }

        //void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // check timing (keystrokes within 100 ms)
        //    TimeSpan elapsed = (DateTime.Now - _lastKeyStroke);
        //    if (elapsed.TotalMilliseconds > 100)
        //        _barcode.Clear();

        //    // record keystroke & timestamp
        //    _barcode.Add(e.KeyChar);
        //    _lastKeyStroke = DateTime.Now;

        //    // process barcode
        //    if (e.KeyChar == 13 && _barcode.Count > 0)
        //    {
        //        string msg = new String(_barcode.ToArray());
        //        MessageBox.Show(msg);
        //        _barcode.Clear();
        //    }
        //}

   

        //----checker sur la touche ENTER est saisi
       // if (e.KeyChar == (char)13)
       //{
       //  // Enter key pressed
       //}
    }
}
