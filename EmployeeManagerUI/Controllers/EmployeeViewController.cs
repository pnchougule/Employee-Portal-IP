using Microsoft.AspNetCore.Mvc;
using EmployeeManagerMVC.Models; // Assuming the ViewModel is in this namespace
using Newtonsoft.Json;

namespace EmployeeManagerMVC.Controllers
{
    public class EmployeeViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeViewController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Login()
        {
            var viewModel = new EmployeeViewModel();

            try
            {
                var totalEmployees = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/total");
                viewModel.TotalEmployees = JsonConvert.DeserializeObject<int>(totalEmployees);

                var allEmployees = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/GetAllEmployees");
                viewModel.AllEmployees = JsonConvert.DeserializeObject<List<Emp>>(allEmployees);

                var engagedForClientTotal = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/engagedforclient/total");
                viewModel.EmployeesEngagedForClientTotal = JsonConvert.DeserializeObject<int>(engagedForClientTotal);

                var engagedForClient = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/engagedforclient");
                viewModel.EmployeesEngagedForClient = JsonConvert.DeserializeObject<List<Emp>>(engagedForClient);

                var onBenchTotal = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/onbench/total");
                viewModel.EmployeesOnBenchTotal = JsonConvert.DeserializeObject<int>(onBenchTotal);

                var onBench = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/onbench");
                viewModel.EmployeesOnBench = JsonConvert.DeserializeObject<List<Emp>>(onBench);

                var onPipTotal = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/onpip/total");
                viewModel.EmployeesOnPipTotal = JsonConvert.DeserializeObject<int>(onPipTotal);

                var onPip = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/onpip");
                viewModel.EmployeesOnPip = JsonConvert.DeserializeObject<List<Emp>>(onPip);


            }
            catch (Exception ex)
            {
                // Handle exceptions
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving data.");
            }

            return View(viewModel);
        }

        // Action to display the search form
        public IActionResult MatchingSkillset()
        {
            return View(new EmployeeViewModel());
        }

        // Action to handle form submission and display results
        [HttpPost]
        public async Task<IActionResult> MatchingSkillset(EmployeeViewModel model)
        {
                try
                {
                    var matchingSkillset = await _httpClient.GetStringAsync($"https://localhost:7034/api/Employees/matchingskillset/{model.SkillSet}");
                    model.MatchingSkillset = JsonConvert.DeserializeObject<List<Emp>>(matchingSkillset);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while retrieving data.");
                }

            return View("MatchingSkillset", model);
        }

        public IActionResult UpgradeSkillset()
        {
            return View(new EmployeeViewModel());
        }

        // Action to handle form submission and display results
        [HttpPost]
        public async Task<IActionResult> UpgradeSkillset(EmployeeViewModel model)
        {
                try
                {
                    var upgradeSkillset = await _httpClient.GetStringAsync($"https://localhost:7034/api/Employees/upgradeskillset/{model.SkillSet}");
                    model.UpgradeSkillset = JsonConvert.DeserializeObject<List<Emp>>(upgradeSkillset);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while retrieving data.");
                }

            return View("UpgradeSkillset", model);
        }

        public async Task<IActionResult> CertifiedEmployee()
        {
            var viewModel = new EmployeeViewModel();
            try
            {
                var certified = await _httpClient.GetStringAsync("https://localhost:7034/api/Employees/certified");
                viewModel.CertifiedEmployees = JsonConvert.DeserializeObject<List<Emp>>(certified);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving data.");
            }

            return View(viewModel);
        }
    }
}
