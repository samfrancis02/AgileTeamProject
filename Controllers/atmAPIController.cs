using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using atmapp.Models;
using atmapp.Data;
using System.Linq;

namespace atmapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class atmAPIController : ControllerBase
    {
        private readonly ILogger<atmAPIController> _logger;
        private readonly TransactionDbContext _dbContext;

        public atmAPIController(ILogger<atmAPIController> logger, TransactionDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // 1. Authenticate Card Endpoint
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] CardAuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid authentication request: {@Request}", request);
                return BadRequest(ModelState);
            }

            // Determine the card type from the card number
            string cardType = GetCardType(request.CardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            _logger.LogInformation("Authentication attempt for {CardType} CardNumber: {CardNumber}",
                                    cardType, MaskCardNumber(request.CardNumber));

            // Query the appropriate table based on card type
            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards
                    .FirstOrDefault(card => card.CardNumber == request.CardNumber && card.HashedPIN == request.PIN);

                if (visaCard != null)
                {
                    _logger.LogInformation("Visa card authentication successful for CardNumber: {CardNumber}",
                                           MaskCardNumber(request.CardNumber));
                    return Ok(new { status = "success", message = "Visa Card Authentication successful" });
                }
            }
            else if (cardType == "MasterCard")
            {
                var masterCard = _dbContext.MasterCards
                    .FirstOrDefault(card => card.CardNumber == request.CardNumber && card.HashedPIN == request.PIN);

                if (masterCard != null)
                {
                    _logger.LogInformation("MasterCard authentication successful for CardNumber: {CardNumber}",
                                           MaskCardNumber(request.CardNumber));
                    return Ok(new { status = "success", message = "MasterCard Authentication successful" });
                }
            }

            _logger.LogWarning("Authentication failed for {CardType} CardNumber: {CardNumber}",
                                cardType, MaskCardNumber(request.CardNumber));
            return Unauthorized(new { status = "failed", message = "Invalid credentials" });
        }

        // Helper method to determine card type
        private string GetCardType(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return "Unknown";

            if (cardNumber.StartsWith("4"))
                return "Visa";

            if ((cardNumber.StartsWith("51") || cardNumber.StartsWith("52") ||
                 cardNumber.StartsWith("53") || cardNumber.StartsWith("54") ||
                 cardNumber.StartsWith("55")) ||
                (int.TryParse(cardNumber.Substring(0, 4), out int prefix) && prefix >= 2221 && prefix <= 2720))
            {
                return "MasterCard";
            }

            return "Unknown";
        }


        // 2. Process Transaction Endpoint
        [HttpPost("process-transaction")]
        public IActionResult ProcessTransaction([FromBody] TransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid transaction request: {@Request}", request);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Processing withdrawal transaction {TransactionId} for CardNumber: {CardNumber}",
                                    request.TransactionId, MaskCardNumber(request.CardNumber));

            // Determine card type and query the appropriate table
            string cardType = GetCardType(request.CardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (visaCard == null)
                    return NotFound(new { status = "failed", message = "Card not found" });

                if (visaCard.Balance < request.Amount)
                {
                    _logger.LogWarning("Insufficient balance for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Insufficient balance" });
                }

                // Deduct amount and update balance
                visaCard.Balance -= request.Amount;
                _dbContext.SaveChanges();

                // Log the transaction
                _dbContext.Transactions.Add(new Transaction
                {
                    CardNumber = request.CardNumber,
                    TransactionType = "Withdrawal",
                    Amount = request.Amount,
                    Timestamp = DateTime.Now,
                    Status = "Success"
                });
                _dbContext.SaveChanges();

                _logger.LogInformation("Transaction {TransactionId} successful. Remaining balance: {Balance}",
                                        request.TransactionId, visaCard.Balance);

                return Ok(new
                {
                    status = "success",
                    message = "Transaction successful",
                    remainingBalance = visaCard.Balance,
                    transactionId = request.TransactionId
                });
            }
            else if (cardType == "MasterCard")
            {
                var masterCard = _dbContext.MasterCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (masterCard == null)
                    return NotFound(new { status = "failed", message = "Card not found" });

                if (masterCard.Balance < request.Amount)
                {
                    _logger.LogWarning("Insufficient balance for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Insufficient balance" });
                }

                // Deduct amount and update balance
                masterCard.Balance -= request.Amount;
                _dbContext.SaveChanges();

                // Log the transaction
                _dbContext.Transactions.Add(new Transaction
                {
                    CardNumber = request.CardNumber,
                    TransactionType = "Withdrawal",
                    Amount = request.Amount,
                    Timestamp = DateTime.Now,
                    Status = "Success"
                });
                _dbContext.SaveChanges();

                _logger.LogInformation("Transaction {TransactionId} successful. Remaining balance: {Balance}",
                                        request.TransactionId, masterCard.Balance);

                return Ok(new
                {
                    status = "success",
                    message = "Transaction successful",
                    remainingBalance = masterCard.Balance,
                    transactionId = request.TransactionId
                });
            }

            _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
            return BadRequest(new { status = "failed", message = "Unsupported card type" });
        }


        [HttpGet("balance/{cardNumber}")]
        public IActionResult GetBalance(string cardNumber)
        {
            _logger.LogInformation("Balance inquiry for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));

            // Determine card type
            string cardType = GetCardType(cardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            // Query the appropriate table
            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards.FirstOrDefault(card => card.CardNumber == cardNumber);
                if (visaCard == null)
                {
                    _logger.LogWarning("Card not found: {CardNumber}", MaskCardNumber(cardNumber));
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                _logger.LogInformation("Balance for Visa CardNumber {CardNumber}: {Balance}",
                                        MaskCardNumber(cardNumber), visaCard.Balance);
                return Ok(new { status = "success", balance = visaCard.Balance });
            }
            else if (cardType == "MasterCard")
            {
                var masterCard = _dbContext.MasterCards.FirstOrDefault(card => card.CardNumber == cardNumber);
                if (masterCard == null)
                {
                    _logger.LogWarning("Card not found: {CardNumber}", MaskCardNumber(cardNumber));
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                _logger.LogInformation("Balance for MasterCard CardNumber {CardNumber}: {Balance}",
                                        MaskCardNumber(cardNumber), masterCard.Balance);
                return Ok(new { status = "success", balance = masterCard.Balance });
            }

            _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
            return BadRequest(new { status = "failed", message = "Unsupported card type" });
        }

        [HttpGet("transaction-history/{cardNumber}")]
        public IActionResult GetTransactionHistory(string cardNumber)
        {
            _logger.LogInformation("Fetching transaction history for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));

            // Query transactions for the given card number
            var transactions = _dbContext.Transactions
                .Where(t => t.CardNumber == cardNumber)
                .OrderByDescending(t => t.Timestamp) // Most recent transactions first
                .ToList();

            if (transactions == null || !transactions.Any())
            {
                _logger.LogWarning("No transactions found for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
                return NotFound(new { status = "failed", message = "No transactions found" });
            }

            _logger.LogInformation("Transaction history fetched for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
            return Ok(new { status = "success", transactions });
        }


        [HttpGet("generate-receipt/{transactionId}")]
        public IActionResult GenerateReceipt(string transactionId)
        {
            _logger.LogInformation("Generating receipt for TransactionId: {TransactionId}", transactionId);

            // Retrieve the transaction by ID
            var transaction = _dbContext.Transactions.FirstOrDefault(t => t.Id.ToString() == transactionId);
            if (transaction == null)
            {
                _logger.LogWarning("Transaction not found for TransactionId: {TransactionId}", transactionId);
                return NotFound(new { status = "failed", message = "Transaction not found" });
            }

            // Generate the receipt data
            var receipt = new
            {
                TransactionId = transaction.Id,
                CardNumber = MaskCardNumber(transaction.CardNumber),
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                Timestamp = transaction.Timestamp,
                Status = transaction.Status
            };

            _logger.LogInformation("Receipt generated for TransactionId: {TransactionId}", transactionId);

            return Ok(new { status = "success", receipt });
        }





        // Simulated network routing logic
        private NetworkResponse RouteTransactionToNetwork(TransactionRequest request)
        {
            System.Threading.Thread.Sleep(1000);

            var random = new Random();
            bool isApproved = random.Next(2) == 0;

            return new NetworkResponse
            {
                Status = isApproved ? "approved" : "declined",
                Message = isApproved ? "Transaction approved by network" : "Transaction declined by network"
            };
        }

        // Utility: Mask card number for logs
        private string MaskCardNumber(string cardNumber)
        {
            return cardNumber.Substring(0, 4) + "********" + cardNumber.Substring(cardNumber.Length - 4);
        }
    }

    // Models
    public class CardAuthRequest
    {
        public string CardNumber { get; set; }
        public string PIN { get; set; }
    }


    public class TransactionRequest
    {
        public string TransactionType { get; set; } // withdrawal, balance-inquiry
        public double Amount { get; set; }
        public string CardNumber { get; set; }
        public string AtmId { get; set; }
        public string TransactionId { get; set; }
    }

    public class NetworkResponse
    {
        public string Status { get; set; } // approved or declined
        public string Message { get; set; }
    }
}
