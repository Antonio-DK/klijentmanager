using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace klijentmanager
{
    public partial class Form1 : Form
    {
        private List<Klijenti> klijentiList = new List<Klijenti>();
        private const string filePath = "klijenti.txt";
        private int nextID = 1;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(filePath))
            {
                btnUcitaj_Click(null, null);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            klijentiList.Add(new Klijenti(nextID, txtIme.Text, txtPrezime.Text, txtKontakt.Text, txtAdresa.Text));
            nextID++;
            dataGridView.DataSource = null;
            dataGridView.DataSource = klijentiList;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(filePath, false))
            {
                foreach (var k in klijentiList)
                    sw.WriteLine($"{k.ID};{k.Ime};{k.Prezime};{k.Kontakt};{k.Adresa}");
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                klijentiList.Clear();
                int maxID = 0;
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(';');
                    if (parts.Length == 5 && int.TryParse(parts[0], out int id))
                    {
                        klijentiList.Add(new Klijenti(id, parts[1], parts[2], parts[3], parts[4]));
                        if(id > maxID) maxID = id;
                    }
                }
                nextID = maxID + 1;
                dataGridView.DataSource = null;
                dataGridView.DataSource = klijentiList;
            }
            else
            {
                MessageBox.Show("Datoteka nije pronađena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
