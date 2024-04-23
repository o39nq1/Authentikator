using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.Web;

namespace Raktarkeszlet
{
    public partial class Form1 : Form
    {
        List<Termek> termeklista = new List<Termek>();
        string key = "1-99771c47-c036-4a99-aaf9-79ea0f752b3e";
        string url = "http://20.234.113.211:8108/";

        int valtozott = 0;

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

        private void Mennyiseg()
        {
            var termek = (Termek)listBox1.SelectedItem;
            textBoxmennyiseg.Text = termek.keszlet.ToString();
            textBoxmennyiseg.ReadOnly = true;
        }

        private void Szures()
        {
            //List<Termek> adatok = new List<Termek>();
            //for (int i = 0; i < termeklista.Count; i++)
            //{
            //    if (termeklista[i].nev.Contains(textBox1.Text))
            //    {
            //        adatok.Add(termeklista[i]);
            //    }
            //}
            var termekek = from x in termeklista
                         where x.nev.Contains(textBox1.Text)
                         select x;
            listBox1.DataSource = termekek.ToList();
            listBox1.DisplayMember = "nev";
            listBox1.ValueMember = "id";
            Mennyiseg();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Szures();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mennyiseg();
            valtozott = 0;
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            int keszlet = int.Parse(textBoxmennyiseg.Text);
            keszlet = keszlet + 1;
            textBoxmennyiseg.Text = keszlet.ToString();
            valtozott = valtozott + 1;
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            int keszlet = int.Parse(textBoxmennyiseg.Text);
            keszlet = keszlet - 1;
            textBoxmennyiseg.Text = keszlet.ToString();
            valtozott = valtozott - 1;
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            var proxy = new Api(url, key);
            var termek = (Termek)listBox1.SelectedItem;
            var inventory = proxy.ProductInventoryFind(termek.inventory_id).Content;
            inventory.QuantityOnHand = int.Parse(textBoxmennyiseg.Text);
            proxy.ProductInventoryUpdate(inventory);
            Mennyiseg();
            string uzenet1 = "A "+termek.nev+" termék rakárkészlete változott: "+valtozott.ToString();
            MessageBox.Show(uzenet1);
            Close();
        }

        private void buttonmegse_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
