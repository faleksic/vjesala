using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vjesala
{
    public partial class Igra : Form
    {
        private Rijec rijec;
        private List<char> upisanaSlova = new List<char>();

        public Igra()
        {
            InitializeComponent();
            NovaIgra();
        }

        private void Igra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (upisanaSlova.Contains(e.KeyChar))
            {
                return;
            }
            upisanaSlova.Add(e.KeyChar);

            lbPrikaz.Text = rijec.ProvjeriSlovo(e.KeyChar);
            lbPromasaj.Text = "Promašaji: "+rijec.BrojPromasaja;
            lbUpisanaSlova.Text += e.KeyChar + " ";

            switch (rijec.BrojPromasaja)
            {
                case 1: pbGlava.Visible = true; break;
                case 2: pbTijelo.Visible = true; break;
                case 3: pbLivaRuka.Visible = true; break;
                case 4: pbDesnaRuka.Visible = true; break;
                case 5: pbLivaNoga.Visible = true; break;
                case 6: pbDesnaNoga.Visible = true; break;
            }

            if (rijec.BrojPromasaja==6)
            {
                if (MessageBox.Show("Izgubio si! Riječ je bila " + rijec.Rjesenje + ". Želiš li opet?", "Gubitnik", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NovaIgra();
                }
                else
                {
                    this.Close();
                }
            }

            if (!lbPrikaz.Text.Contains("-"))
            {
                if (MessageBox.Show("Bravo! Pobjedio si! Želiš li opet?", "Pobjeda", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NovaIgra();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void NovaIgra()
        {
            rijec = new Rijec();
            upisanaSlova.Clear();

            pbGlava.Visible = false;
            pbLivaNoga.Visible = false;
            pbLivaRuka.Visible = false;
            pbTijelo.Visible = false;
            pbDesnaNoga.Visible = false;
            pbDesnaRuka.Visible = false;

            lbPrikaz.Text = new string(rijec.RjesenjePoSlovima);
            lbPromasaj.Text = "Promašaji: ";
            lbUpisanaSlova.Text = "";
        }
    }
}
