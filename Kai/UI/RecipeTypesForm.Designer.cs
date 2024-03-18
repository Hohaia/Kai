namespace Kai.UI
{
    partial class RecipeTypesForm
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
            NewTypeTxt = new TextBox();
            TypesLbx = new ListBox();
            AddTypeBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 36);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 0;
            label1.Text = "Type:";
            // 
            // NewTypeTxt
            // 
            NewTypeTxt.Location = new Point(125, 33);
            NewTypeTxt.Name = "NewTypeTxt";
            NewTypeTxt.Size = new Size(171, 32);
            NewTypeTxt.TabIndex = 1;
            // 
            // TypesLbx
            // 
            TypesLbx.FormattingEnabled = true;
            TypesLbx.ItemHeight = 25;
            TypesLbx.Location = new Point(43, 86);
            TypesLbx.Name = "TypesLbx";
            TypesLbx.Size = new Size(253, 329);
            TypesLbx.TabIndex = 2;
            // 
            // AddTypeBtn
            // 
            AddTypeBtn.Location = new Point(43, 434);
            AddTypeBtn.Name = "AddTypeBtn";
            AddTypeBtn.Size = new Size(253, 60);
            AddTypeBtn.TabIndex = 3;
            AddTypeBtn.Text = "Add";
            AddTypeBtn.UseVisualStyleBackColor = true;
            AddTypeBtn.Click += AddTypeBtn_Click;
            // 
            // RecipeTypesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 527);
            Controls.Add(AddTypeBtn);
            Controls.Add(TypesLbx);
            Controls.Add(NewTypeTxt);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "RecipeTypesForm";
            Text = "Recipe Types";
            Load += RecipeTypesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NewTypeTxt;
        private ListBox TypesLbx;
        private Button AddTypeBtn;
    }
}