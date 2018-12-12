using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gyak11_F1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            
            CenterToScreen();
            
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.FileName = "versenyzok.txt";
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = "eredmeny.txt";
        }

        private List<Versenyzo> versenyzok = new List<Versenyzo>();
        VersenyForm versenyForm = new VersenyForm();

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            try
            {
                AdatBevitel();
                versenyToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hiba");
                
            }
            
        }

        private void AdatBevitel() {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                using (StreamReader olvasoCsatorna = new StreamReader(openFileDialog1.FileName))
                {
                    string sor;
                    string[] adatok;
                    while (!olvasoCsatorna.EndOfStream)
                    {
                        sor = olvasoCsatorna.ReadLine();
                        if (sor != "")
                        {
                            adatok = sor.Split(';');
                            versenyzok.Add(new Versenyzo(adatok[0], adatok[1], adatok[2]));
                        }
                        
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {

                
            }
        }

        private void versenyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            versenyForm.Atvesz(versenyzok);
            this.Hide();
            versenyForm.ShowDialog();
            this.Show();
            eredmenyToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        private void eredmenyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EredmenyForm eredmenyForm = new EredmenyForm();
            string uszasNem = versenyForm.UszasNem;
            int tav = versenyForm.Tav;
            eredmenyForm.EredmenyHirdetes(uszasNem, tav, versenyzok);
            this.Hide();
            eredmenyForm.ShowDialog();
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
