namespace InvoiceSystem
{
    partial class MainForm
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
            btnOpenRegister = new Button();
            btnOpenLogin = new Button();
            btnInvoice = new Button();
            SuspendLayout();
            // 
            // btnOpenRegister
            // 
            btnOpenRegister.Location = new Point(12, 12);
            btnOpenRegister.Name = "btnOpenRegister";
            btnOpenRegister.Size = new Size(137, 38);
            btnOpenRegister.TabIndex = 0;
            btnOpenRegister.Text = "Rejestracja";
            btnOpenRegister.UseVisualStyleBackColor = true;
            btnOpenRegister.Click += btnOpenRegister_Click;
            // 
            // btnOpenLogin
            // 
            btnOpenLogin.Location = new Point(155, 12);
            btnOpenLogin.Name = "btnOpenLogin";
            btnOpenLogin.Size = new Size(137, 38);
            btnOpenLogin.TabIndex = 1;
            btnOpenLogin.Text = "Logowanie";
            btnOpenLogin.UseVisualStyleBackColor = true;
            btnOpenLogin.Click += btnOpenLogin_Click;
            // 
            // btnInvoice
            // 
            btnInvoice.Location = new Point(80, 89);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(137, 38);
            btnInvoice.TabIndex = 2;
            btnInvoice.Text = "Nowa faktura";
            btnInvoice.UseVisualStyleBackColor = true;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 193);
            Controls.Add(btnInvoice);
            Controls.Add(btnOpenLogin);
            Controls.Add(btnOpenRegister);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenRegister;
        private Button btnOpenLogin;
        private Button btnInvoice;
    }
}
