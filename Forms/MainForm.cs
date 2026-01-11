using InvoiceSystem.Forms;

namespace InvoiceSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
        private void btnOpenLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            InvoiceForm form = new InvoiceForm();
            form.ShowDialog();
        }
    }
}
