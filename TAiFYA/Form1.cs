using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiFYA
{
    public partial class Form1 : Form
    {
        private Analizator _analizator = new Analizator();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxOutput.Clear();
            listViewLexems.Items.Clear();

            var analizator = new Analizator();
            analizator.Analyze(TextBoxInput.Text);
            TextBoxOutput.Text = analizator.Output;
            foreach (var item in analizator.tablesRows)
            {
                ListViewItem lvi = new ListViewItem();
                ListViewItem.ListViewSubItem lvsi1 = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem lvsi2 = new ListViewItem.ListViewSubItem();
                lvi.Text = $"lex{ item.number}";
                lvsi1.Text = $"{item.lexeme}";
                lvsi2.Text = $"{item.type}";
                lvi.SubItems.Add(lvsi1);
                lvi.SubItems.Add(lvsi2);
                listViewLexems.Items.Add(lvi);
            }
            int i = 0;
            
        }
    }
}
