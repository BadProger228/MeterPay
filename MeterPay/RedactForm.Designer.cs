namespace Projecting_Project_Ex2
{
    partial class RedactForm
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
            HouseName = new Label();
            Address = new Label();
            History = new ListBox();
            SumPay = new Label();
            kilovatForNewDay = new TextBox();
            NextKilovat = new Label();
            AddPayment = new Button();
            Pay = new Button();
            SuspendLayout();
            // 
            // HouseName
            // 
            HouseName.AutoSize = true;
            HouseName.Location = new Point(49, 36);
            HouseName.Name = "HouseName";
            HouseName.Size = new Size(88, 15);
            HouseName.TabIndex = 0;
            HouseName.Text = "House name is ";
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Location = new Point(49, 74);
            Address.Name = "Address";
            Address.Size = new Size(55, 15);
            Address.TabIndex = 1;
            Address.Text = "Address: ";
            // 
            // History
            // 
            History.FormattingEnabled = true;
            History.ItemHeight = 15;
            History.Location = new Point(58, 117);
            History.Name = "History";
            History.Size = new Size(231, 244);
            History.TabIndex = 2;
            History.SelectedIndexChanged += History_SelectedIndexChanged;
            // 
            // SumPay
            // 
            SumPay.AutoSize = true;
            SumPay.Location = new Point(49, 508);
            SumPay.Name = "SumPay";
            SumPay.Size = new Size(60, 15);
            SumPay.TabIndex = 3;
            SumPay.Text = "Payment: ";
            // 
            // kilovatForNewDay
            // 
            kilovatForNewDay.Location = new Point(193, 378);
            kilovatForNewDay.Name = "kilovatForNewDay";
            kilovatForNewDay.Size = new Size(108, 23);
            kilovatForNewDay.TabIndex = 5;
            kilovatForNewDay.TextChanged += kilovatForNewDay_TextChanged;
            // 
            // NextKilovat
            // 
            NextKilovat.AutoSize = true;
            NextKilovat.Location = new Point(70, 381);
            NextKilovat.Name = "NextKilovat";
            NextKilovat.Size = new Size(117, 15);
            NextKilovat.TabIndex = 6;
            NextKilovat.Text = "Kilovat for next time:";
            // 
            // AddPayment
            // 
            AddPayment.Location = new Point(136, 422);
            AddPayment.Name = "AddPayment";
            AddPayment.Size = new Size(84, 38);
            AddPayment.TabIndex = 7;
            AddPayment.Text = "Add";
            AddPayment.UseVisualStyleBackColor = true;
            AddPayment.Click += AddPayment_Click;
            // 
            // Pay
            // 
            Pay.Location = new Point(210, 509);
            Pay.Name = "Pay";
            Pay.Size = new Size(75, 23);
            Pay.TabIndex = 8;
            Pay.Text = "Pay";
            Pay.UseVisualStyleBackColor = true;
            Pay.Click += Pay_Click;
            // 
            // RedactForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 562);
            Controls.Add(Pay);
            Controls.Add(AddPayment);
            Controls.Add(NextKilovat);
            Controls.Add(kilovatForNewDay);
            Controls.Add(SumPay);
            Controls.Add(History);
            Controls.Add(Address);
            Controls.Add(HouseName);
            Name = "RedactForm";
            Text = "RedactForm";
            Load += RedactForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HouseName;
        private Label Address;
        private ListBox History;
        private Label SumPay;
        private TextBox kilovatForNewDay;
        private Label NextKilovat;
        private Button AddPayment;
        private Button Pay;
    }
}