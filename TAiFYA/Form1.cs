using System;
using System.Windows.Forms;
using MathLang;

namespace TAiFYA
{
    public partial class Form1 : Form
    {
        private readonly Analizator _analizator = new Analizator();

        public Form1()
        {
            InitializeComponent();
        }

        public Analizator Analizator => _analizator;

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBoxTree.Clear();
            richTextBoxOutput.Clear();
            richTextBoxGenerator.Clear();
            listViewLexems.Items.Clear();
            try
            {
                AstNode program = MathLangParser.Parse(richTextBoxInput.Text);
                richTextBoxTree.Text = AstNodePrinter.Print(program);
                richTextBoxGenerator.Text = MathLangIntepreter.Execute(program);
                buttonOptimize.Enabled = true;
            }
            catch (Exception exc)
            {
                richTextBoxOutput.Text += "Error: " + exc;
                return;
            }
            var analizator = new Analizator();
            analizator.Analyze(richTextBoxInput.Text);
            richTextBoxOutput.Text = analizator.Output;
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

        }

        private void ButtonOptimize_Click(object sender, EventArgs e)
        {
            richTextBoxGenerator.Text = MathLangIntepreter.OptimizeGeneratedString(richTextBoxGenerator.Text);
        }
    }
}
