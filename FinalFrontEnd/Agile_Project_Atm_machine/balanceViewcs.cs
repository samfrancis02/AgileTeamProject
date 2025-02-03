using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace Agile_Project_Atm_machine
{
    public partial class balanceViewcs : Form
    {
        private HttpClient _httpClient;
        private string _cardNumber; // Ideally, this should be set dynamically

        public balanceViewcs()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5037/api/atmAPI/") };
            if (!string.IsNullOrEmpty(PinForm.CardNumber))
            {
                _cardNumber = PinForm.CardNumber;  // Retrieve card number from PinForm
                FetchAndDisplayBalance();
            }
            else
            {
                MessageBox.Show("Card number not set. Please try logging in again.");
            }
        }

        private async void FetchAndDisplayBalance()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.GetAsync($"balance/{_cardNumber}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var balanceData = JsonSerializer.Deserialize<BalanceResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (balanceData != null && balanceData.Status == "success")
                    {
                        balanceLabel.Text = $"Account balance: {balanceData.Balance:C2}";
                        accountNameLabel.Text = $"Account Number: {_cardNumber}";

                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve balance.", "Balance Inquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Error retrieving balance: {response.ReasonPhrase}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (JsonException jex)
            {
                MessageBox.Show($"Error processing balance data: {jex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                response?.Dispose();
            }
        }

        private void balanceViewcs_Click(object sender, EventArgs e)
        {
            this.Close(); // Ensure it performs the desired navigation or closure action
        }
        private void balanceViewcs_Load(object sender, EventArgs e)
        {
            // Any initialization code or call FetchAndDisplayBalance here if needed
            FetchAndDisplayBalance();
        }


        private class BalanceResponse
        {
            public string Status { get; set; }
            public double Balance { get; set; }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void accountNameLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
