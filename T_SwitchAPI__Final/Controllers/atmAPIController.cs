using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using atmapp.Models;
using atmapp.Data;
using System.Linq;

namespace atmapp.Controllers


{
    /// <summary>
    /// API controller for handling ATM transactions including authentication and balance inquiries.
    /// </summary>

    [ApiController]
    [Route("api/[controller]")]
    public class atmAPIController : ControllerBase
    {
        private readonly ILogger<atmAPIController> _logger;
        private readonly TransactionDbContext _dbContext;

        /// <summary>
        /// Constructor for ATM API controller initializing logging and database context.
        /// </summary>
        public atmAPIController(ILogger<atmAPIController> logger, TransactionDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Constructor for ATM API controller initializing logging and database context.
        /// </summary>
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] CardAuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid authentication request: {@Request}", request);
                return BadRequest(ModelState);
            }

            // Determine the card type based on the card number provided.

            string cardType = GetCardType(request.CardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            // Log authentication attempt.

            _logger.LogInformation("Authentication attempt for {CardType} CardNumber: {CardNumber}", cardType, MaskCardNumber(request.CardNumber));

            // Process Visa and MasterCard differently based on card type.
            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (visaCard == null)
                {
                    _logger.LogWarning("Card not found for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                // Check lockout mechanism
                if (visaCard.LockoutUntil.HasValue && visaCard.LockoutUntil > DateTime.Now)
                {
                    return Unauthorized(new { status = "failed", message = "Card is temporarily locked. Try again later." });
                }

                // Verify PIN
                if (!BCrypt.Net.BCrypt.Verify(request.PIN, visaCard.HashedPIN))
                {
                    visaCard.FailedAttempts++;

                    // Lock the card if failed attempts exceed limit
                    if (visaCard.FailedAttempts >= 3)
                    {
                        visaCard.LockoutUntil = DateTime.Now.AddMinutes(15); // Lock for 15 minutes
                        _dbContext.SaveChanges();
                        _logger.LogWarning("Card locked due to multiple failed attempts: {CardNumber}", MaskCardNumber(request.CardNumber));
                        return Unauthorized(new { status = "failed", message = "Card locked due to multiple failed attempts." });
                    }

                    _dbContext.SaveChanges();
                    _logger.LogWarning("Invalid PIN for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return Unauthorized(new { status = "failed", message = "Invalid PIN." });
                }

                // Reset failed attempts on successful authentication
                visaCard.FailedAttempts = 0;
                visaCard.LockoutUntil = null;
                _dbContext.SaveChanges();

                _logger.LogInformation("Visa card authentication successful for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return Ok(new { status = "success", message = "Visa Card Authentication successful" });
            }
            else if (cardType == "MasterCard")
            {
                var masterCard = _dbContext.MasterCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (masterCard == null)
                {
                    _logger.LogWarning("Card not found for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                // Check lockout mechanism
                if (masterCard.LockoutUntil.HasValue && masterCard.LockoutUntil > DateTime.Now)
                {
                    return Unauthorized(new { status = "failed", message = "Card is temporarily locked. Try again later." });
                }

                // Verify PIN
                if (!BCrypt.Net.BCrypt.Verify(request.PIN, masterCard.HashedPIN))
                {
                    masterCard.FailedAttempts++;

                    // Lock the card if failed attempts exceed limit
                    if (masterCard.FailedAttempts >= 3)
                    {
                        masterCard.LockoutUntil = DateTime.Now.AddMinutes(15); // Lock for 15 minutes
                        _dbContext.SaveChanges();
                        _logger.LogWarning("Card locked due to multiple failed attempts: {CardNumber}", MaskCardNumber(request.CardNumber));
                        return Unauthorized(new { status = "failed", message = "Card locked due to multiple failed attempts." });
                    }

                    _dbContext.SaveChanges();
                    _logger.LogWarning("Invalid PIN for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return Unauthorized(new { status = "failed", message = "Invalid PIN." });
                }

                // Reset failed attempts on successful authentication
                masterCard.FailedAttempts = 0;
                masterCard.LockoutUntil = null;
                _dbContext.SaveChanges();

                _logger.LogInformation("MasterCard authentication successful for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return Ok(new { status = "success", message = "MasterCard Authentication successful" });
            }

            _logger.LogWarning("Authentication failed for {CardType} CardNumber: {CardNumber}", cardType, MaskCardNumber(request.CardNumber));
            return Unauthorized(new { status = "failed", message = "Invalid credentials." });
        }

        /// <summary>
        /// Endpoint to retrieve the balance for a specific card number.
        /// </summary>
        [HttpGet("balance/{cardNumber}")]
        public IActionResult GetBalance(string cardNumber)
        {
            _logger.LogInformation("Balance inquiry for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));

            string cardType = GetCardType(cardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards.FirstOrDefault(card => card.CardNumber == cardNumber);
                if (visaCard == null)
                {
                    _logger.LogWarning("Card not found: {CardNumber}", MaskCardNumber(cardNumber));
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                _logger.LogInformation("Balance for Visa CardNumber {CardNumber}: {Balance}", MaskCardNumber(cardNumber), visaCard.Balance);
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

                _logger.LogInformation("Balance for MasterCard CardNumber {CardNumber}: {Balance}", MaskCardNumber(cardNumber), masterCard.Balance);
                return Ok(new { status = "success", balance = masterCard.Balance });
            }

            _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(cardNumber));
            return BadRequest(new { status = "failed", message = "Unsupported card type" });
        }



        /// <summary>
        /// Endpoint to process a transaction request for withdrawal.
        /// </summary>
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

            string cardType = GetCardType(request.CardNumber);
            if (cardType == "Unknown")
            {
                _logger.LogWarning("Unsupported card type for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                return BadRequest(new { status = "failed", message = "Unsupported card type" });
            }

            // Validate and retrieve ATM inventory
            if (!int.TryParse(request.AtmId, out int atmId))
            {
                _logger.LogWarning("Invalid ATMId format: {AtmId}", request.AtmId);
                return BadRequest(new { status = "failed", message = "Invalid ATMId format" });
            }

            var atmInventory = _dbContext.ATMInventories.FirstOrDefault(atm => atm.ATMId == atmId);
            if (atmInventory == null)
            {
                _logger.LogWarning("ATM with ID {AtmId} not found", atmId);
                return NotFound(new { status = "failed", message = "ATM not found" });
            }

            // Calculate required denominations
            int amount = (int)request.Amount;
            int originalAmount = amount;

            int fiftyCount = Math.Min(amount / 50, atmInventory.FiftyDenomination);
            amount -= fiftyCount * 50;

            int twentyCount = Math.Min(amount / 20, atmInventory.TwentyDenomination);
            amount -= twentyCount * 20;

            int tenCount = Math.Min(amount / 10, atmInventory.TenDenomination);
            amount -= tenCount * 10;

            // Check if denominations can fulfill the withdrawal
            if (amount > 0)
            {
                _logger.LogWarning("Insufficient denominations in ATM {AtmId} for withdrawal amount: {Amount}", request.AtmId, request.Amount);
                return BadRequest(new { status = "failed", message = "Insufficient denominations in ATM" });
            }

            // Process card type logic
            if (cardType == "Visa")
            {
                var visaCard = _dbContext.VisaCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (visaCard == null)
                {
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                // Validate transaction limit
                if (request.Amount > visaCard.TransactionLimit)
                {
                    _logger.LogWarning("Transaction exceeds the per-transaction limit for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Transaction exceeds the per-transaction limit" });
                }

                // Validate daily limit
                if (visaCard.DailyWithdrawn + request.Amount > visaCard.DailyLimit)
                {
                    _logger.LogWarning("Transaction exceeds the daily limit for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Transaction exceeds the daily withdrawal limit" });
                }

                // Validate available balance
                if (visaCard.Balance < request.Amount)
                {
                    _logger.LogWarning("Insufficient balance for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Insufficient balance" });
                }

                // Update card and ATM fields
                visaCard.Balance -= request.Amount;
                visaCard.DailyWithdrawn += request.Amount;
            }
            else if (cardType == "MasterCard")
            {
                var masterCard = _dbContext.MasterCards.FirstOrDefault(card => card.CardNumber == request.CardNumber);
                if (masterCard == null)
                {
                    return NotFound(new { status = "failed", message = "Card not found" });
                }

                // Validate transaction limit
                if (request.Amount > masterCard.TransactionLimit)
                {
                    _logger.LogWarning("Transaction exceeds the per-transaction limit for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Transaction exceeds the per-transaction limit" });
                }

                // Validate daily limit
                if (masterCard.DailyWithdrawn + request.Amount > masterCard.DailyLimit)
                {
                    _logger.LogWarning("Transaction exceeds the daily limit for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Transaction exceeds the daily withdrawal limit" });
                }

                // Validate available balance
                if (masterCard.Balance < request.Amount)
                {
                    _logger.LogWarning("Insufficient balance for CardNumber: {CardNumber}", MaskCardNumber(request.CardNumber));
                    return BadRequest(new { status = "failed", message = "Insufficient balance" });
                }

                // Update card and ATM fields
                masterCard.Balance -= request.Amount;
                masterCard.DailyWithdrawn += request.Amount;
            }

            // Deduct denominations from ATM inventory
            atmInventory.FiftyDenomination -= fiftyCount;
            atmInventory.TwentyDenomination -= twentyCount;
            atmInventory.TenDenomination -= tenCount;

            // Log transaction
            _dbContext.Transactions.Add(new Transaction
            {
                CardNumber = request.CardNumber,
                TransactionType = "Withdrawal",
                Amount = originalAmount,
                Status = "Success",
                Timestamp = DateTime.Now
            });

            _dbContext.SaveChanges();

            _logger.LogInformation("Transaction {TransactionId} successful. Denominations dispensed: 50s={Fifty}, 20s={Twenty}, 10s={Ten}", request.TransactionId, fiftyCount, twentyCount, tenCount);

            return Ok(new
            {
                status = "success",
                message = "Transaction successful",
                dispensed = new { Fifty = fiftyCount, Twenty = twentyCount, Ten = tenCount },
                transactionId = request.TransactionId
            });
        }


        // Helper Methods
        /// <summary>
        /// Determines the card type based on the first few digits of the card number.
        /// </summary>
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

        private string MaskCardNumber(string cardNumber)
        {
            return cardNumber.Substring(0, 4) + "********" + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}
