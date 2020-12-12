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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.TextBoxOutput = new System.Windows.Forms.TextBox();
            this.listViewLexems = new System.Windows.Forms.ListView();
            this.columnHeaderLexNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAnalize = new System.Windows.Forms.Button();
            this.columnHeaderLexeme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.TextBoxInput.Location = new System.Drawing.Point(0, 0);
            this.TextBoxInput.Multiline = true;
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxInput.Size = new System.Drawing.Size(401, 450);
            this.TextBoxInput.TabIndex = 0;
            this.TextBoxInput.Text = "a a:= (x * y^2 - 1) * (x * y + 120) * 5;\r\nx = true;\r\ny = false;\r\nz = x xor y;";
            // 
            // TextBoxOutput
            // 
            this.TextBoxOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxOutput.Location = new System.Drawing.Point(401, 0);
            this.TextBoxOutput.Multiline = true;
            this.TextBoxOutput.Name = "TextBoxOutput";
            this.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxOutput.Size = new System.Drawing.Size(399, 215);
            this.TextBoxOutput.TabIndex = 1;
            // 
            // listViewLexems
            // 
            this.listViewLexems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLexNumber,
            this.columnHeaderLexeme,
            this.columnHeaderType});
            this.listViewLexems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLexems.GridLines = true;
            this.listViewLexems.HideSelection = false;
            this.listViewLexems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewLexems.Location = new System.Drawing.Point(401, 215);
            this.listViewLexems.Name = "listViewLexems";
            this.listViewLexems.Size = new System.Drawing.Size(399, 235);
            this.listViewLexems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewLexems.TabIndex = 2;
            this.listViewLexems.UseCompatibleStateImageBehavior = false;
            this.listViewLexems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLexNumber
            // 
            this.columnHeaderLexNumber.Text = "LexNumber";
            this.columnHeaderLexNumber.Width = 109;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 109;
            // 
            // buttonAnalize
            // 
            this.buttonAnalize.Location = new System.Drawing.Point(12, 415);
            this.buttonAnalize.Name = "buttonAnalize";
            this.buttonAnalize.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalize.TabIndex = 3;
            this.buttonAnalize.Text = "Analize";
            this.buttonAnalize.UseVisualStyleBackColor = true;
            this.buttonAnalize.Click += new System.EventHandler(this.button1_Click);
            // 
            // columnHeaderLexeme
            // 
            this.columnHeaderLexeme.Text = "Lexeme";
            this.columnHeaderLexeme.Width = 177;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAnalize);
            this.Controls.Add(this.listViewLexems);
            this.Controls.Add(this.TextBoxOutput);
            this.Controls.Add(this.TextBoxInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxInput;
        private System.Windows.Forms.TextBox TextBoxOutput;
        private System.Windows.Forms.ListView listViewLexems;
        private System.Windows.Forms.Button buttonAnalize;
        private System.Windows.Forms.ColumnHeader columnHeaderLexNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderLexeme;
    }
}

