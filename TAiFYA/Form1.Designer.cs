namespace TAiFYA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAnalize = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.listViewLexems = new System.Windows.Forms.ListView();
            this.columnHeaderLexNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLexeme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxTree = new System.Windows.Forms.RichTextBox();
            this.buttonOptimize = new System.Windows.Forms.Button();
            this.richTextBoxGenerator = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAnalize
            // 
            this.buttonAnalize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAnalize.Location = new System.Drawing.Point(0, 438);
            this.buttonAnalize.Name = "buttonAnalize";
            this.buttonAnalize.Size = new System.Drawing.Size(176, 23);
            this.buttonAnalize.TabIndex = 3;
            this.buttonAnalize.Text = "Analize";
            this.buttonAnalize.UseVisualStyleBackColor = true;
            this.buttonAnalize.Click += new System.EventHandler(this.Button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 461);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.buttonAnalize);
            this.splitContainer4.Panel1.Controls.Add(this.richTextBoxInput);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer4.Size = new System.Drawing.Size(420, 461);
            this.splitContainer4.SplitterDistance = 176;
            this.splitContainer4.TabIndex = 4;
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.AutoWordSelection = true;
            this.richTextBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(176, 461);
            this.richTextBoxInput.TabIndex = 1;
            this.richTextBoxInput.Text = "rub := (d1 + d2) * 26.54";
            this.richTextBoxInput.WordWrap = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.richTextBoxOutput);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listViewLexems);
            this.splitContainer3.Size = new System.Drawing.Size(240, 461);
            this.splitContainer3.SplitterDistance = 228;
            this.splitContainer3.TabIndex = 1;
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(240, 228);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "a := (x * y - 1) * (x * y + 120) * 5\nx := true\ny := false\nz := x xor y and a";
            this.richTextBoxOutput.WordWrap = false;
            // 
            // listViewLexems
            // 
            this.listViewLexems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewLexems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLexNumber,
            this.columnHeaderLexeme,
            this.columnHeaderType});
            this.listViewLexems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLexems.GridLines = true;
            this.listViewLexems.HideSelection = false;
            this.listViewLexems.HotTracking = true;
            this.listViewLexems.HoverSelection = true;
            this.listViewLexems.Location = new System.Drawing.Point(0, 0);
            this.listViewLexems.MultiSelect = false;
            this.listViewLexems.Name = "listViewLexems";
            this.listViewLexems.Size = new System.Drawing.Size(240, 229);
            this.listViewLexems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewLexems.TabIndex = 2;
            this.listViewLexems.UseCompatibleStateImageBehavior = false;
            this.listViewLexems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLexNumber
            // 
            this.columnHeaderLexNumber.Text = "LexNumber";
            this.columnHeaderLexNumber.Width = 70;
            // 
            // columnHeaderLexeme
            // 
            this.columnHeaderLexeme.Text = "Lexeme";
            this.columnHeaderLexeme.Width = 84;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxTree);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonOptimize);
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxGenerator);
            this.splitContainer2.Size = new System.Drawing.Size(560, 461);
            this.splitContainer2.SplitterDistance = 109;
            this.splitContainer2.TabIndex = 3;
            // 
            // richTextBoxTree
            // 
            this.richTextBoxTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTree.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxTree.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxTree.Name = "richTextBoxTree";
            this.richTextBoxTree.ReadOnly = true;
            this.richTextBoxTree.Size = new System.Drawing.Size(109, 461);
            this.richTextBoxTree.TabIndex = 2;
            this.richTextBoxTree.Text = "rub := (d1 + d2) * 26.54\nx := (5+3)*8\ny := (5*3)/5\nz := (8/4)*(5+2)\n";
            // 
            // buttonOptimize
            // 
            this.buttonOptimize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonOptimize.Location = new System.Drawing.Point(0, 438);
            this.buttonOptimize.Name = "buttonOptimize";
            this.buttonOptimize.Size = new System.Drawing.Size(447, 23);
            this.buttonOptimize.TabIndex = 5;
            this.buttonOptimize.Text = "Optimize";
            this.buttonOptimize.UseVisualStyleBackColor = true;
            this.buttonOptimize.Click += new System.EventHandler(this.ButtonOptimize_Click);
            // 
            // richTextBoxGenerator
            // 
            this.richTextBoxGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxGenerator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxGenerator.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxGenerator.Name = "richTextBoxGenerator";
            this.richTextBoxGenerator.ReadOnly = true;
            this.richTextBoxGenerator.Size = new System.Drawing.Size(447, 461);
            this.richTextBoxGenerator.TabIndex = 3;
            this.richTextBoxGenerator.Text = "LOAD =26.54\nSTORE $1\nLOAD d2\nSTORE ~2\nLOAD ~2\nADD d1\nSTORE ~3\nLOAD ~3\nADD d1\nSTOR" +
    "E ~2\nSTORE rub\n";
            this.richTextBoxGenerator.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "ТА и ФЯ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAnalize;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.ListView listViewLexems;
        private System.Windows.Forms.ColumnHeader columnHeaderLexNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderLexeme;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.RichTextBox richTextBoxTree;
        private System.Windows.Forms.RichTextBox richTextBoxGenerator;
        private System.Windows.Forms.Button buttonOptimize;
    }
}

