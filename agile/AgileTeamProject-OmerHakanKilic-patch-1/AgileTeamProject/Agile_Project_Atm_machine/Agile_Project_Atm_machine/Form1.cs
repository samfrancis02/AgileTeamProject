namespace Agile_Project_Atm_machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Insert_Button_Click(object sender, EventArgs e)
        {
            PinForm pinForm = new PinForm();
            pinForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
