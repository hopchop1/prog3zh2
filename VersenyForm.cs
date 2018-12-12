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
    public partial class VersenyForm : Form {


        private DateTime alap = new DateTime(2000, 01, 01, 0, 0, 0);
        private int sorszam;

        public int Tav { get; private set; }
        public string UszasNem { get; private set; }
        private List<Versenyzo> versenyzok;

        public VersenyForm() {
            InitializeComponent();
        }

        private void btnVerseny_Click(object sender, EventArgs e) {
            Tav = (int)numericUpDown1.Value;
            UszasNem = cmbUszasNem.SelectedItem.ToString();
            VersenyzoBeallitas();
            btnVerseny.Enabled = false;
            cmbUszasNem.Enabled = false;
            numericUpDown1.Enabled = false;
            btnKovetkezo.Enabled = true;
            
        }

        private void VersenyzoBeallitas()
        {
            dateTimePicker1.Value = alap;
            if (sorszam<versenyzok.Count)
            {
                txtVersenyzo.Text = versenyzok[sorszam].Nev;
            }
            else
            {
                this.Close();
            }
            
        }

        private void btnKovetkezo_Click(object sender, EventArgs e) {
            TimeSpan idoEredmeny = dateTimePicker1.Value - alap;
            versenyzok[sorszam].Versenyez(idoEredmeny);
            sorszam++;
            VersenyzoBeallitas();
        }

        internal void Atvesz(List<Versenyzo> versenyzok)
        {
            this.versenyzok = versenyzok;
        }
    }
}
