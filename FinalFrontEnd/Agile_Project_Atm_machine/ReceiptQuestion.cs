using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Agile_Project_Atm_machine
{
    public partial class ReceiptQuestion : Form
    {
        private HttpClient _httpClient;
        private int amount;
        private string _cardNumber = "4111222233334444";  // This should be dynamically set based on user session

        public ReceiptQuestion(int amount)
        {
            InitializeComponent();
            this.amount = amount;
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5037/api/atmAPI/") };
            ProcessTransaction(this.amount);
        }

        private async void ProcessTransaction(int amount)
        {
            var transactionRequest = new
            {
                transactionType = "withdrawal",
                amount = amount,
                cardNumber = _cardNumber,
                atmId = "1",
                transactionId = Guid.NewGuid().ToString()
            };

            var content = new StringContent(JsonSerializer.Serialize(transactionRequest), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("process-transaction", content);
                var responseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var responseData = JsonSerializer.Deserialize<TransactionResponse>(responseString, options);

                this.Invoke(new Action(() =>
                {
                    if (responseData.Status == "success")
                    {
                        label1.Text = $"Successfully {this.amount} pounds withdrawn. Would you like a receipt?";
                        YES.Visible = true;
                        NO.Visible = true;

                        // Display only the 'dispensed' field from the response
                        var dispensed = responseData.Dispensed;
                        rawResponseLabel.Text = $"Dispensed: 50s - {dispensed.Fifty}, 20s - {dispensed.Twenty}, 10s - {dispensed.Ten}";
                        rawResponseLabel.Visible = true;
                    }
                    else
                    {
                        label1.Text = $"Transaction failed: {responseData?.Message ?? "No message returned."}";
                        YES.Visible = false;
                        NO.Visible = false;
                        rawResponseLabel.Text = $"Transaction failed: {responseData?.Message ?? "No message returned."}";
                        rawResponseLabel.Visible = true;
                    }
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    rawResponseLabel.Text = $"Exception during transaction: {ex.Message}";
                    YES.Visible = false;
                    NO.Visible = false;
                }));
            }
        }



        private void YES_Click(object sender, EventArgs e)
        {
            takeMoneyAndReceipt confirm = new takeMoneyAndReceipt(amount);
            confirm.Show();
            this.Hide();
        }

        private void NO_Click(object sender, EventArgs e)
        {
            NoReceipt noReceipt = new NoReceipt(amount);
            noReceipt.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: add functionality or feedback when the label is clicked.
        }

        private class TransactionResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public Dispensed Dispensed { get; set; }
            public string TransactionId { get; set; }
        }

        private class Dispensed
        {
            public int Fifty { get; set; }
            public int Twenty { get; set; }
            public int Ten { get; set; }
        }
    }
}
