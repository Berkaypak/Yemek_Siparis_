using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yemek_Siparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] yiyecekler = new string[] { "0.4-140-ET DÜRÜM", "0.3-70-TAVUK DÜRÜM", "0.5-200-PİZZA", "0.1-50-TOST", "0.2-60-MAKARNA", "0.6-400-İSKENDER" };
        string[] çorbalar = new string[] { "1.2-40-MERCİMEK", "1.3-40-DOMATES", "1.6-120-KELLE PAÇA", "1.5-120-İŞKEMBE", "1.4-45-EZOGELİN", "1.1-40-YAYLA" };
        string[] tatlılar = new string[] { "2.3-50-SÜTLAÇ", "2.1-20-EKLER", "2.6-400-PASTA", "2.5-200-PASTA", "2.2-40-ŞEKERPARE", "2.4-100-KÜNEFE" };
        string[] içecekler = new string[] { "3.5-40-KOLA", "3.2-10-AYRAN", "3.3-20-SODA", "3.1-10-SU", "3.6-60-KOLA(BÜYÜK)", "3.4-20-ŞALGAM" };

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "YEMEK SİPARİŞ EKRANI"; this.BackColor = Color.LemonChiffon;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; label1.Text = "KATEGORİLER";
            label5.Text = "SEPETİM"; button1.Text = ">>";
            button2.Text = "<<"; button3.Text = "SEPETİ TEMİZLE"; label2.Text = ""; label3.Text = "SIRALAMA";
            button4.Text = "SEPET TUTARINI GÖR"; label4.Visible = false; checkBox1.Text = "ÇATAL BIÇAK İSTİYORUM";
            button5.Text = "ÇIKIŞ"; button6.Text = "ONAYLA"; button6.Enabled = false; radioButton1.Text = "KAPIDA ÖDEME";
            radioButton2.Text = "KREDİ KARTI"; label6.Text = "ÖDEME YÖNTEMİ";
        }
        private void ComboBox_Changed(object sender, EventArgs e)
        {
            comboBox2.Text = "VARSAYILAN";
            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text = "YİYECEKLER";
                foreach (string s in yiyecekler)
                {
                    listBox1.Items.Add(s);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label2.Text = "ÇORBALAR";
                foreach (string s in çorbalar)
                {
                    listBox1.Items.Add(s);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label2.Text = "TATLILAR";
                foreach (string s in tatlılar)
                {
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                label2.Text = "İÇECEKLER";
                foreach (string s in içecekler)
                {
                    listBox1.Items.Add(s);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            button6.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList al1 = new ArrayList();
            al1.AddRange(listBox1.SelectedItems);
            foreach (var v in al1)
            {
                listBox2.Items.Add(v);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList al2 = new ArrayList();
            al2.AddRange(listBox2.SelectedItems);
            foreach (var v in al2)
            {
                listBox2.Items.Remove(v);
            }
            if (listBox2.Items.Count == 0) { button6.Enabled = false; }
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();
            al.AddRange(listBox1.Items);
            al.Sort();
            if (comboBox2.SelectedIndex == 0)
            {
                listBox1.Items.Clear();
                foreach (var v in al)
                {
                    listBox1.Items.Add(v);
                }
            }
            else
            {
                al.Reverse();
                listBox1.Items.Clear();
                foreach (var v in al)
                {
                    listBox1.Items.Add(v);
                }
            }
        }
        int es;
        private void button4_Click(object sender, EventArgs e)
        {
            es = 0;
            label4.Visible = true;
            ArrayList a = new ArrayList();
            a.AddRange(listBox2.Items);
            foreach (string s in a)
            {

                string i = s.Substring(4, 3);
                if (i.EndsWith("-")) { i = i.Remove(2); }
                int ii = Convert.ToInt32(i);
                es += ii;
            }
            label4.Text = es.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("SEPETİNİZ SİLİNİP UYGULAMADAN ÇIKILACAK. ONAYLIYOR MUSUNUZ ?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (d == DialogResult.Yes) this.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button4_Click(1, e);
            string str = label4.Text.ToString();
            DialogResult d = MessageBox.Show(" SİPARİŞİNİZ ONAYLANACAK. ONAYLIYOR MUSUNUZ ?", ("SİPARİŞ TUTARI : " + str), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
            if (d == DialogResult.Yes)
            {
                MessageBox.Show("SİPARİŞİNİZ ALINDI");
                this.Close();
            }
        }
        private void label4_TextChanged(object sender, EventArgs e)
        {
            if (label4.Text == "0") button6.Enabled = false;
            else button6.Enabled = true;
        }

        private void button6_EnabledChanged(object sender, EventArgs e)
        {
            if (button6.Enabled)
                label7.Visible = false;
            else
            {
                label7.Visible = true;
                label7.Text = " ! ONAYLAMAK İÇİN SEPET TUTARINI GÜNCELLEYİNİZ VE SEPETİNİZE EKLEME YAPINIZ";
            }
        }
    }
}

