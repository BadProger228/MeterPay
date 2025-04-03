namespace Projecting_Project_Ex2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HousesList = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // HousesList
            // 
            HousesList.FormattingEnabled = true;
            HousesList.ItemHeight = 15;
            HousesList.Location = new Point(12, 67);
            HousesList.Name = "HousesList";
            HousesList.Size = new Size(326, 319);
            HousesList.TabIndex = 0;
            HousesList.SelectedIndexChanged += HousesList_SelectedIndexChanged;
            HousesList.DoubleClick += HousesList_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Houses:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 409);
            Controls.Add(label1);
            Controls.Add(HousesList);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox HousesList;
        private Label label1;
    }
}
