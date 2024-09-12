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
            richTextBox1 = new RichTextBox();
            TypeDrop = new ComboBox();
            AddTypeBtn = new Button();
            label5 = new Label();
            DateFrozenBox = new DateTimePicker();
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
            label2.Size = new Size(55, 25);
            label2.TabIndex = 3;
            label2.Text = "Type:";
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
            label4.Location = new Point(774, 205);
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
            ServingsNum.Size = new Size(67, 33);
            ServingsNum.TabIndex = 9;
            ServingsNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(891, 205);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(354, 414);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // TypeDrop
            // 
            TypeDrop.FormattingEnabled = true;
            TypeDrop.Location = new Point(891, 149);
            TypeDrop.Name = "TypeDrop";
            TypeDrop.Size = new Size(241, 33);
            TypeDrop.TabIndex = 12;
            // 
            // AddTypeBtn
            // 
            AddTypeBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            AddTypeBtn.Location = new Point(1138, 149);
            AddTypeBtn.Name = "AddTypeBtn";
            AddTypeBtn.Size = new Size(107, 33);
            AddTypeBtn.TabIndex = 13;
            AddTypeBtn.Text = "Add";
            AddTypeBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(966, 99);
            label5.Name = "label5";
            label5.Size = new Size(117, 25);
            label5.TabIndex = 14;
            label5.Text = "Date Frozen:";
            // 
            // DateFrozenBox
            // 
            DateFrozenBox.Format = DateTimePickerFormat.Short;
            DateFrozenBox.Location = new Point(1089, 93);
            DateFrozenBox.Name = "DateFrozenBox";
            DateFrozenBox.Size = new Size(156, 33);
            DateFrozenBox.TabIndex = 15;
            // 
            // FrozenMealsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 646);
            Controls.Add(DateFrozenBox);
            Controls.Add(label5);
            Controls.Add(AddTypeBtn);
            Controls.Add(TypeDrop);
            Controls.Add(richTextBox1);
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
            Load += FrozenMealsForm_Load;
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
        private RichTextBox richTextBox1;
        private ComboBox TypeDrop;
        private Button AddTypeBtn;
        private Label label5;
        private DateTimePicker DateFrozenBox;
    }
}