namespace InvoiceSystem.Forms
{
    partial class RegisterForm
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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPhone = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(65, 18);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 44);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(159, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 99);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(159, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 81);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Hasło";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 138);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 4;
            label3.Text = "Numer telefonu";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(12, 156);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(159, 23);
            txtPhone.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 185);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(159, 28);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Zarejestruj";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 255);
            Controls.Add(btnRegister);
            Controls.Add(txtPhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private TextBox txtPhone;
        private Button btnRegister;
    }
}