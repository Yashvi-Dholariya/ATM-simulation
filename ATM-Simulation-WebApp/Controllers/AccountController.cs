using Microsoft.AspNetCore.Mvc;
using ATM_Simulation_WebApp.Services;
using ATM_Simulation_WebApp.Models;

namespace ATM_Simulation_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ATMService _atm;

        public AccountController(ATMService atm)
        {
            _atm = atm;
        }

        private Account? CurrentAccount()
        {
            var card = HttpContext.Session.GetString("CardNumber");
            if (string.IsNullOrEmpty(card)) return null;
            return _atm.GetByCard(card);
        }

        public IActionResult Dashboard()
        {
            var acc = CurrentAccount();
            if (acc == null) return RedirectToAction("Login", "Home");
            return View(acc);
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            if (CurrentAccount() == null) return RedirectToAction("Login", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(decimal amount)
        {
            var acc = CurrentAccount();
            if (acc == null) return RedirectToAction("Login", "Home");

            try
            {
                _atm.Deposit(acc, amount, "ATM deposit");
                TempData["Success"] = $"Deposit successful: ₹{amount:N2}";
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            if (CurrentAccount() == null) return RedirectToAction("Login", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(decimal amount)
        {
            var acc = CurrentAccount();
            if (acc == null) return RedirectToAction("Login", "Home");

            try
            {
                _atm.Withdraw(acc, amount, "ATM withdrawal");
                TempData["Success"] = $"Withdrawal successful: ₹{amount:N2}";
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Transactions()
        {
            var acc = CurrentAccount();
            if (acc == null) return RedirectToAction("Login", "Home");
            var list = _atm.GetTransactions(acc);
            return View(list);
        }
    }
}
