namespace ClientApp
{
    public partial class frmJoin : Form
    {
        public frmJoin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppSession.Username = txtUsername.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
