using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agile_Project_Atm_machine
{
    public partial class PinForm : Form
    {
        public static string CardNumber = "4111222233334444"; // Example card number, replace as necessary
        Color color1 = ColorTranslator.FromHtml("#f5f6df");
        Color color2 = ColorTranslator.FromHtml("#f5f6df");
        public PinForm()
        {
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml("#3a5068");
        }

        private void text_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Continue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                MessageBox.Show("Please enter your PIN.");
                return;
            }

            // Assume card number is being managed globally or fetched from another form
            string cardNumber = "4111222233334444"; // Example card number, replace as necessary

            try
            {
                bool isAuthenticated = await AuthenticatePin(cardNumber, text.Text);
                if (isAuthenticated)
                {
                    MessageBox.Show("PIN ACCEPTED");
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.Show();
                    this.Hide();
                }
                else
                {
                    text.Text = "";
                    MessageBox.Show("Invalid PIN. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Authentication failed: " + ex.Message);
            }
        }

        private async Task<bool> AuthenticatePin(string cardNumber, string pin)
        {
            var payload = new
            {
                cardNumber = cardNumber,
                pin = pin
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                using (HttpResponseMessage response = await Program.HttpClient.PostAsync("authenticate", content))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response content
                        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        if (result != null && result.status != null)
                        {
                            // Check if the status is "success"
                            return result.status.ToString().ToLower() == "success";
                        }
                        else
                        {
                            MessageBox.Show("Authentication failed: Unexpected JSON structure.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Authentication failed: HTTP {response.StatusCode} - {response.ReasonPhrase}\n{responseContent}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Authentication failed: " + ex.Message);
                return false;
            }
        }




        // Define the AuthenticationResponse class
        private class AuthenticationResponse
        {
            public bool IsAuthenticated { get; set; }
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (text.Text.Length > 0)
            {
                // Remove the last character
                text.Text = text.Text.Substring(0, text.Text.Length - 1);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            transactionCancelled transactionCancelled = new transactionCancelled();
            transactionCancelled.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "9";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "8";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PinForm_Load(object sender, EventArgs e)
        {

        }

        private void PinForm_Shown(object sender, EventArgs e)
        {
            pictureBox1.BackColor = ColorTranslator.FromHtml("#f5f6df");
            button0.BackColor = ColorTranslator.FromHtml("#372a51");
            button0.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button1.BackColor = ColorTranslator.FromHtml("#372a51");
            button1.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button2.BackColor = ColorTranslator.FromHtml("#372a51");
            button2.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button3.BackColor = ColorTranslator.FromHtml("#372a51");
            button3.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button4.BackColor = ColorTranslator.FromHtml("#372a51");
            button4.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button5.BackColor = ColorTranslator.FromHtml("#372a51");
            button5.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button6.BackColor = ColorTranslator.FromHtml("#372a51");
            button6.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button7.BackColor = ColorTranslator.FromHtml("#372a51");
            button7.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button8.BackColor = ColorTranslator.FromHtml("#372a51");
            button8.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            button9.BackColor = ColorTranslator.FromHtml("#372a51");
            button9.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            Continue.BackColor = ColorTranslator.FromHtml("#372a51");
            Continue.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            Backspace.BackColor = ColorTranslator.FromHtml("#372a51");
            Backspace.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            Exit.BackColor = ColorTranslator.FromHtml("#372a51");
            Exit.ForeColor = ColorTranslator.FromHtml("#f5f6df");
            text.BackColor = ColorTranslator.FromHtml("#372a51");
            text.ForeColor = ColorTranslator.FromHtml("#f5f6df");


        }
    }
}
