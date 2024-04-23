using Hotcakes.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1.Client;

namespace Raktar
{
    public partial class Form1 : Form
    {

        List<Termek> termeklista = new List<Termek>();
        string key = "1-99771c47-c036-4a99-aaf9-79ea0f752b3e";
        string url = "http://20.234.113.211:8108/";

        public Form1()
        {
            InitializeComponent();



            var proxy = new Api(url, key);
            var termekek = proxy.ProductsFindAll();
            for (int i = 0; i < termekek.Content.Count(); i++)
            {
                var inventory = proxy.ProductInventoryFindForProduct(termekek.Content[i].Bvin);
                Termek t = new Termek();
                t.id = i + 1;
                t.nev = termekek.Content[i].ProductName;
                t.keszlet = inventory.Content[0].QuantityOnHand;
                t.inventory_id = inventory.Content[0].Bvin;

                termeklista.Add(t);
            }
            Szures();
            Mennyiseg();

        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            int keszlet = int.Parse(textBoxmennyiseg.Text);
            keszlet = keszlet + 1;
            textBoxmennyiseg.Text = keszlet.ToString();

        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            int keszlet = int.Parse(textBoxmennyiseg.Text);
            keszlet = keszlet - 1;
            textBoxmennyiseg.Text = keszlet.ToString();
        }

        private void Szures()
        {
            List<string> adatok = new List<string>();
            for (int i = 0; i < termeklista.Count; i++)
            {
                if (termeklista[i].nev.Contains(textBox1.Text))
                {
                    adatok.Add(termeklista[i].nev);
                }
            }

            listBox1.DataSource = adatok;
            listBox1.DisplayMember= "nev";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Szures();
        }

        private void Mennyiseg()
        {
            int kivalasztott = listBox1.SelectedIndex;
            textBoxmennyiseg.Text = termeklista[kivalasztott].keszlet.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mennyiseg();
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            var proxy = new Api(url, key);
            int index = listBox1.SelectedIndex;
            var termek = termeklista[index];
            var inventory = proxy.ProductInventoryFind(termek.inventory_id).Content;
            inventory.QuantityOnHand = int.Parse(textBoxmennyiseg.Text);
            proxy.ProductInventoryUpdate(inventory);
            Mennyiseg();
        }
    }
}
