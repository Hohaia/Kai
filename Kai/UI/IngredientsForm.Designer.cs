namespace Kai.UI
{
    partial class IngredientsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            NameTxt = new TextBox();
            QuantityNum = new NumericUpDown();
            KcalPer100gNum = new NumericUpDown();
            PricePer100gNum = new NumericUpDown();
            AddToKeteBtn = new Button();
            UnitOfMeasurementDrop = new ComboBox();
            label6 = new Label();
            IngredientsGrid = new DataGridView();
            TypeDrop = new ComboBox();
            SearchTxt = new TextBox();
            ClearAllFieldsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)QuantityNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IngredientsGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(658, 63);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(658, 120);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 1;
            label2.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(658, 181);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 2;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(658, 242);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 3;
            label4.Text = "Kcal (/100g)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(658, 304);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 4;
            label5.Text = "Price (/100g)";
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(785, 60);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(303, 32);
            NameTxt.TabIndex = 5;
            // 
            // QuantityNum
            // 
            QuantityNum.DecimalPlaces = 2;
            QuantityNum.Location = new Point(785, 178);
            QuantityNum.Margin = new Padding(5);
            QuantityNum.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            QuantityNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            QuantityNum.Name = "QuantityNum";
            QuantityNum.Size = new Size(193, 32);
            QuantityNum.TabIndex = 7;
            QuantityNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // KcalPer100gNum
            // 
            KcalPer100gNum.DecimalPlaces = 2;
            KcalPer100gNum.Location = new Point(784, 240);
            KcalPer100gNum.Margin = new Padding(8);
            KcalPer100gNum.Maximum = new decimal(new int[] { 900, 0, 0, 0 });
            KcalPer100gNum.Name = "KcalPer100gNum";
            KcalPer100gNum.Size = new Size(304, 32);
            KcalPer100gNum.TabIndex = 8;
            // 
            // PricePer100gNum
            // 
            PricePer100gNum.DecimalPlaces = 2;
            PricePer100gNum.Location = new Point(785, 302);
            PricePer100gNum.Margin = new Padding(13);
            PricePer100gNum.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            PricePer100gNum.Name = "PricePer100gNum";
            PricePer100gNum.Size = new Size(304, 32);
            PricePer100gNum.TabIndex = 9;
            // 
            // AddToKeteBtn
            // 
            AddToKeteBtn.Location = new Point(658, 350);
            AddToKeteBtn.Name = "AddToKeteBtn";
            AddToKeteBtn.Size = new Size(430, 38);
            AddToKeteBtn.TabIndex = 10;
            AddToKeteBtn.Text = "Add to my Kete";
            AddToKeteBtn.UseVisualStyleBackColor = true;
            AddToKeteBtn.Click += AddToKeteBtn_Click;
            // 
            // UnitOfMeasurementDrop
            // 
            UnitOfMeasurementDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            UnitOfMeasurementDrop.FormattingEnabled = true;
            UnitOfMeasurementDrop.Items.AddRange(new object[] { "g", "Kg", "L" });
            UnitOfMeasurementDrop.Location = new Point(1039, 178);
            UnitOfMeasurementDrop.Name = "UnitOfMeasurementDrop";
            UnitOfMeasurementDrop.Size = new Size(49, 33);
            UnitOfMeasurementDrop.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(986, 181);
            label6.Name = "label6";
            label6.Size = new Size(47, 25);
            label6.TabIndex = 12;
            label6.Text = "Unit";
            // 
            // IngredientsGrid
            // 
            IngredientsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsGrid.Location = new Point(12, 60);
            IngredientsGrid.Name = "IngredientsGrid";
            IngredientsGrid.RowTemplate.Height = 25;
            IngredientsGrid.Size = new Size(620, 412);
            IngredientsGrid.TabIndex = 13;
            // 
            // TypeDrop
            // 
            TypeDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            TypeDrop.FormattingEnabled = true;
            TypeDrop.Items.AddRange(new object[] { "Condiment", "Fruit", "Liquid", "Meat", "Spice", "Vegetable" });
            TypeDrop.Location = new Point(785, 117);
            TypeDrop.Name = "TypeDrop";
            TypeDrop.Size = new Size(303, 33);
            TypeDrop.Sorted = true;
            TypeDrop.TabIndex = 14;
            // 
            // SearchTxt
            // 
            SearchTxt.Location = new Point(12, 12);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search Ingredient...";
            SearchTxt.Size = new Size(620, 32);
            SearchTxt.TabIndex = 15;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.Location = new Point(658, 394);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(430, 38);
            ClearAllFieldsBtn.TabIndex = 17;
            ClearAllFieldsBtn.Text = "Clear All Fields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = true;
            ClearAllFieldsBtn.Click += ClearAllFieldsBtn_Click;
            // 
            // IngredientsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 493);
            Controls.Add(ClearAllFieldsBtn);
            Controls.Add(SearchTxt);
            Controls.Add(TypeDrop);
            Controls.Add(IngredientsGrid);
            Controls.Add(label6);
            Controls.Add(UnitOfMeasurementDrop);
            Controls.Add(AddToKeteBtn);
            Controls.Add(PricePer100gNum);
            Controls.Add(KcalPer100gNum);
            Controls.Add(QuantityNum);
            Controls.Add(NameTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "IngredientsForm";
            Text = "My Kete";
            Load += IngredientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)QuantityNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)KcalPer100gNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)PricePer100gNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)IngredientsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox NameTxt;
        private NumericUpDown QuantityNum;
        private NumericUpDown KcalPer100gNum;
        private NumericUpDown PricePer100gNum;
        private Button AddToKeteBtn;
        private ComboBox UnitOfMeasurementDrop;
        private Label label6;
        private DataGridView IngredientsGrid;
        private ComboBox TypeDrop;
        private TextBox SearchTxt;
        private Button ClearAllFieldsBtn;
    }
}