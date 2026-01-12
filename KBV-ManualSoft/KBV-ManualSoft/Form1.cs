using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBV_ManualSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    listBox1.Items.Add(fileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy elemet amit törölni szeretnél.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string filePath = (listBox1.SelectedItem.ToString() + ".pdf");
                using (var chooseForm = new ChooseDocumentForm())
                {
                    DialogResult result = chooseForm.ShowDialog();
                    label1.Visible = true;
                    label2.Visible = true;
                    if (result == DialogResult.Yes)
                    {
                        switch (listBox1.SelectedIndex)
                        {
                            case 0:
                                label2.Text = "GoPro Hero – Garancia\nVásárlás dátuma: 2023.06.15\nVásárlás helye: MediaMarkt\nVételár: 149 990 Ft\nGarancia: 3 év\nSzerviz: GoPro hivatalos";
                            break;

                            case 1:
                                label2.Text = "HIKMICRO LYNX – Garancia\nVásárlás dátuma: 2022.11.02\nVásárlás helye: hivatalos forgalmazó\nVételár: 329 000 Ft\nGarancia: 2 év\nSzerviz: HIKMICRO";
                                break;
                            case 2:
                                label2.Text = "Beko hűtőszekrény – Garancia\nVásárlás dátuma: 2021.08.20\nVásárlás helye: Euronics\nVételár: 189 990 Ft\nGarancia: 2 év\nSzerviz: Beko márkaszerviz";
                                break;
                            case 3:
                                label2.Text = "iPhone – Garancia\nVásárlás dátuma: 2024.01.10\nVásárlás helye: Apple Store\nVételár: 399 990 Ft\nGarancia: 3 év\nSzerviz: Apple hivatalos";
                                break;
                            case 4:
                                label2.Text = "BenQ Monitor – Garancia\nVásárlás dátuma: 2020.05.05\nVásárlás helye: Alza\nVételár: 119 990 Ft\nGarancia: 3 év\nSzerviz: BenQ márkaszerviz";
                                break;
                            case 5:
                                label2.Text = "Tesla mosógép – Garancia\nVásárlás dátuma: 2022.03.18\nVásárlás helye: MediaMarkt\nVételár: 169 990 Ft\nGarancia: 2 év\nSzerviz: Tesla hivatalos";
                                break;
                            case 6:
                                label2.Text = "Gorenje szárítógép – Garancia\nVásárlás dátuma: 2021.12.01\nVásárlás helye: BestByte\nVételár: 219 990 Ft\nGarancia: 3 év\nSzerviz: Gorenje márkaszerviz";
                                break;
                            case 7:
                                label2.Text = "Samsung TV – Garancia\nVásárlás dátuma: 2023.02.14\nVásárlás helye: Euronics\nVételár: 279 990 Ft\nGarancia: 2 év\nSzerviz: Samsung hivatalos";
                                break;
                            case 8:
                                label2.Text = "AirFryer – Garancia\nVásárlás dátuma: 2024.04.22\nVásárlás helye: Lidl\nVételár: 49 990 Ft\nGarancia: 1 év\nSzerviz: Lidl szervizpartner";
                                break;
                            case 9:
                                label2.Text = "DeLonghi kávéfőző – Garancia\nVásárlás dátuma: 2022.09.09\nVásárlás helye: MediaMarkt\nVételár: 159 990 Ft\nGarancia: 2 év\nSzerviz: DeLonghi márkaszerviz";
                                break;
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        Process.Start(filePath);
                    }
                }

            }

        }
    }
}
