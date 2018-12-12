using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyak11_F1 {
    public partial class EredmenyForm : Form {
        public EredmenyForm() {
            InitializeComponent();
        }

        private List<Versenyzo> versenyzok = new List<Versenyzo>();

        internal void EredmenyHirdetes(string uszasNem, int tav, List<Versenyzo> versenyzok)
        {
            lblCim.Text = tav + " méteres " + uszasNem;
            this.versenyzok = versenyzok;
            foreach (var item in versenyzok)
            {
                lstVersenyzok.Items.Add(item);
            }
        }

        private void lstVersenyzok_SelectedIndexChanged(object sender, EventArgs e)
        {
            Versenyzo versenyzo = (Versenyzo)lstVersenyzok.SelectedItem;
            txtRajtszam.Text = versenyzo.RajtSzam;
            txtOrszag.Text = versenyzo.Orszag;
            txtIdoEredmeny.Text = new DateTime(versenyzo.IdoEredmeny.Ticks).ToString("mm:ss");
        }

        private void btnOrszagok_Click(object sender, EventArgs e)
        {
            ZaszloForm zaszloForm = new ZaszloForm();
            zaszloForm.Atvesz(versenyzok);
            zaszloForm.ShowDialog();
        }

        private void btnBezar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdBtnNevsor_CheckedChanged(object sender, EventArgs e)
        {
            lstVersenyzok.Sorted = true;
        }

        private void rdBtnEredmeny_CheckedChanged(object sender, EventArgs e)
        {
            lstVersenyzok.Sorted = false;
            lstVersenyzok.Items.Clear();
            Versenyzo temp;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                for (int j = 1+i; j < versenyzok.Count; j++)
                {
                    if (versenyzok[i].IdoEredmeny>versenyzok[j].IdoEredmeny)
                    {
                        temp = versenyzok[i];
                        versenyzok[i] = versenyzok[j];
                        versenyzok[j] = temp;
                    }
                }
            }
            foreach (Versenyzo versenyzo in versenyzok)
            {
                lstVersenyzok.Items.Add(versenyzo);
            }
        }
    }
}
