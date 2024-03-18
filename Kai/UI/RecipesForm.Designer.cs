namespace Kai.UI
{
    partial class RecipesForm
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
            RecipesGrid = new DataGridView();
            FilterDrop = new ComboBox();
            TypeDrop = new ComboBox();
            AddTypeBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            DescriptionTxt = new RichTextBox();
            ImageBox = new PictureBox();
            NameTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            AddRecipeBtn = new Button();
            RecipeIngredientsBtn = new Button();
            ClearAllFieldsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).BeginInit();
            SuspendLayout();
            // 
            // RecipesGrid
            // 
            RecipesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecipesGrid.Location = new Point(12, 56);
            RecipesGrid.Name = "RecipesGrid";
            RecipesGrid.RowTemplate.Height = 25;
            RecipesGrid.Size = new Size(757, 567);
            RecipesGrid.TabIndex = 0;
            // 
            // FilterDrop
            // 
            FilterDrop.FormattingEnabled = true;
            FilterDrop.Location = new Point(12, 17);
            FilterDrop.Name = "FilterDrop";
            FilterDrop.Size = new Size(757, 33);
            FilterDrop.TabIndex = 1;
            // 
            // TypeDrop
            // 
            TypeDrop.FormattingEnabled = true;
            TypeDrop.Location = new Point(915, 56);
            TypeDrop.Name = "TypeDrop";
            TypeDrop.Size = new Size(230, 33);
            TypeDrop.TabIndex = 2;
            // 
            // AddTypeBtn
            // 
            AddTypeBtn.Location = new Point(1151, 56);
            AddTypeBtn.Name = "AddTypeBtn";
            AddTypeBtn.Size = new Size(81, 33);
            AddTypeBtn.TabIndex = 3;
            AddTypeBtn.Text = "Add";
            AddTypeBtn.UseVisualStyleBackColor = true;
            AddTypeBtn.Click += AddTypeBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(786, 60);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 4;
            label1.Text = "Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(786, 21);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 5;
            label2.Text = "Name:";
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Location = new Point(915, 95);
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.Size = new Size(317, 136);
            DescriptionTxt.TabIndex = 6;
            DescriptionTxt.Text = "";
            // 
            // ImageBox
            // 
            ImageBox.Location = new Point(915, 237);
            ImageBox.Name = "ImageBox";
            ImageBox.Size = new Size(317, 228);
            ImageBox.TabIndex = 7;
            ImageBox.TabStop = false;
            // 
            // NameTxt
            // 
            NameTxt.Location = new Point(915, 18);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(317, 32);
            NameTxt.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(786, 152);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 9;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(786, 337);
            label4.Name = "label4";
            label4.Size = new Size(68, 25);
            label4.TabIndex = 10;
            label4.Text = "Image:";
            // 
            // AddRecipeBtn
            // 
            AddRecipeBtn.Location = new Point(786, 471);
            AddRecipeBtn.Name = "AddRecipeBtn";
            AddRecipeBtn.Size = new Size(446, 46);
            AddRecipeBtn.TabIndex = 11;
            AddRecipeBtn.Text = "Add Recipe";
            AddRecipeBtn.UseVisualStyleBackColor = true;
            // 
            // RecipeIngredientsBtn
            // 
            RecipeIngredientsBtn.Location = new Point(786, 523);
            RecipeIngredientsBtn.Name = "RecipeIngredientsBtn";
            RecipeIngredientsBtn.Size = new Size(446, 46);
            RecipeIngredientsBtn.TabIndex = 12;
            RecipeIngredientsBtn.Text = "Recipe Ingredients";
            RecipeIngredientsBtn.UseVisualStyleBackColor = true;
            // 
            // ClearAllFieldsBtn
            // 
            ClearAllFieldsBtn.Location = new Point(786, 575);
            ClearAllFieldsBtn.Name = "ClearAllFieldsBtn";
            ClearAllFieldsBtn.Size = new Size(446, 46);
            ClearAllFieldsBtn.TabIndex = 13;
            ClearAllFieldsBtn.Text = "Clear All Flields";
            ClearAllFieldsBtn.UseVisualStyleBackColor = true;
            // 
            // RecipesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 638);
            Controls.Add(ClearAllFieldsBtn);
            Controls.Add(RecipeIngredientsBtn);
            Controls.Add(AddRecipeBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(NameTxt);
            Controls.Add(ImageBox);
            Controls.Add(DescriptionTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AddTypeBtn);
            Controls.Add(TypeDrop);
            Controls.Add(FilterDrop);
            Controls.Add(RecipesGrid);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "RecipesForm";
            Text = "Recipes";
            Activated += RecipesForm_Activated;
            Load += RecipesForm_Load;
            ((System.ComponentModel.ISupportInitialize)RecipesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RecipesGrid;
        private ComboBox FilterDrop;
        private ComboBox TypeDrop;
        private Button AddTypeBtn;
        private Label label1;
        private Label label2;
        private RichTextBox DescriptionTxt;
        private PictureBox ImageBox;
        private TextBox NameTxt;
        private Label label3;
        private Label label4;
        private Button AddRecipeBtn;
        private Button RecipeIngredientsBtn;
        private Button ClearAllFieldsBtn;
    }
}