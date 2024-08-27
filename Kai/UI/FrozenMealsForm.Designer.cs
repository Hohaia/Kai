namespace Kai.UI
{
    partial class FrozenMealsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SearchTxt = new TextBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            NameTxt = new TextBox();
            ServingsNum = new NumericUpDown();
            TypesListBox = new CheckedListBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServingsNum).BeginInit();
            SuspendLayout();
            // 
            // SearchTxt
            // 
            SearchTxt.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            SearchTxt.Location = new Point(12, 12);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search Meals...";
            SearchTxt.Size = new Size(756, 32);
            SearchTxt.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(756, 568);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(774, 51);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(774, 152);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 3;
            label2.Text = "Type(s):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(774, 99);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 4;
            label3.Text = "Servings:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(774, 281);
            label4.Name = "label4";
            label4.Size = new Size(107, 25);
            label4.TabIndex = 5;
            label4.Text = "Serve With:";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(891, 48);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(354, 33);
            NameTxt.TabIndex = 6;
            // 
            // ServingsNum
            // 
            ServingsNum.DecimalPlaces = 2;
            ServingsNum.Location = new Point(891, 97);
            ServingsNum.Margin = new Padding(5);
            ServingsNum.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            ServingsNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ServingsNum.Name = "ServingsNum";
            ServingsNum.Size = new Size(193, 33);
            ServingsNum.TabIndex = 9;
            ServingsNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TypesListBox
            // 
            TypesListBox.FormattingEnabled = true;
            TypesListBox.Location = new Point(891, 152);
            TypesListBox.Name = "TypesListBox";
            TypesListBox.Size = new Size(354, 116);
            TypesListBox.TabIndex = 10;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(891, 281);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(354, 338);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // FrozenMealsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 646);
            Controls.Add(richTextBox1);
            Controls.Add(TypesListBox);
            Controls.Add(ServingsNum);
            Controls.Add(NameTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(SearchTxt);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "FrozenMealsForm";
            Text = "FrozenMealsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServingsNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTxt;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox NameTxt;
        private NumericUpDown ServingsNum;
        private CheckedListBox TypesListBox;
        private RichTextBox richTextBox1;
    }
}