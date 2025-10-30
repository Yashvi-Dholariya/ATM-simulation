using Microsoft.AspNetCore.Mvc;
using ATM_Simulation_WebApp.Services;
using ATM_Simulation_WebApp.Models;

namespace ATM_Simulation_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ATMService _atm;

        public HomeController(ATMService atm)
        {
            _atm = atm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cardNumber, string pin)
        {
            try 
            {
                // Clean up the card number (remove any non-digit characters)
                var cleanCardNumber = string.Concat(cardNumber?.Where(char.IsDigit) ?? string.Empty);
                var cleanPin = pin?.Trim() ?? string.Empty;

                // Log the received values (for debugging)
                Console.WriteLine($"Login attempt - Card: {cleanCardNumber}, PIN: {cleanPin}");
                
                // Get all accounts (for debugging)
                var allAccounts = _atm.GetAllAccounts();
                Console.WriteLine($"Available accounts: {allAccounts.Count}");
                foreach (var acc in allAccounts)
                {
                    Console.WriteLine($"Account: {acc.CardNumber}, PIN: {acc.Pin}, Name: {acc.Name}");
                }
                
                // Try to authenticate with the cleaned card number
                var user = _atm.Authenticate(cleanCardNumber, cleanPin);
                if (user == null)
                {
                    Console.WriteLine($"Authentication failed - No matching account found for card: {cleanCardNumber}");
                    ViewBag.Error = "Invalid card number or PIN. Please try again.";
                    return View();
                }

                Console.WriteLine($"Authentication successful for user: {user.Name}");
                HttpContext.Session.SetString("CardNumber", user.CardNumber);
                return RedirectToAction("Dashboard", "Account");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex}");
                ViewBag.Error = "An error occurred during login. Please try again.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CardNumber");
            return RedirectToAction("Index");
        }
    }
}
