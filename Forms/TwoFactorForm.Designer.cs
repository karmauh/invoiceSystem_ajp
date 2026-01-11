namespace InvoiceSystem.Forms
{
    partial class TwoFactorForm
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
            txtCode = new TextBox();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 0;
            label1.Text = "Kod weryfikacyjny";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(12, 27);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(103, 23);
            txtCode.TabIndex = 1;
            // 
            // btnVerify
            // 
            btnVerify.Location = new Point(12, 65);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(103, 23);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "Zweryfikuj";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // TwoFactorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(139, 114);
            Controls.Add(btnVerify);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Name = "TwoFactorForm";
            Text = "TwoFactorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCode;
        private Button btnVerify;
    }
}