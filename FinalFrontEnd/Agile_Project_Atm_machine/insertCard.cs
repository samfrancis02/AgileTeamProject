namespace Agile_Project_Atm_machine
{
    public partial class insertCard : Form
    {
        public insertCard()
        {
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml("#3a5068");
        }

        private void Insert_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Card successfully inserted.");
            PinForm pinForm = new PinForm();
            pinForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void insertCard_Shown(object sender, EventArgs e)
        {
            Insert_Button.BackColor= ColorTranslator.FromHtml("#f5f6df");
            Insert_Button.ForeColor = ColorTranslator.FromHtml("#372a51");
        }
    }
}
