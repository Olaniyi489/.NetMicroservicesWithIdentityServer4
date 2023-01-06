using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employee.Client.ApiService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Employee.Client.Controllers
{[Authorize]
    public class EmployeeClientModelsController : Controller
    {
        private readonly IEmployeeApiService _employeeApiService;

       public EmployeeClientModelsController(IEmployeeApiService employeeApiService)
       {
            _employeeApiService = employeeApiService;
       }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> OnlyAdmin()
        {
            var userInfo = await _employeeApiService.GetUserInfo();
            return View(userInfo);
        }

        // GET: EmployeeClientModels
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _employeeApiService.GetEmployees());
        }

        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity Token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value: {claim.Value}");
            }
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        // GET: EmployeeClientModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeClientModel = await _context.EmployeeClientModel
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (employeeClientModel == null)
            //{
            //    return NotFound();
            //}

            //return View(employeeClientModel);
        }

        // GET: EmployeeClientModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeClientModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,JobTitle,JoinedDate,Department")] Models.EmployeeClientModel employeeClientModel)
        {
            // return View();
            if (ModelState.IsValid)
            {
               await _employeeApiService.CreateEmployee(employeeClientModel);
                //await _employeeApiService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeClientModel);
        }

        // GET: EmployeeClientModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeClientModel = await _context.EmployeeClientModel.FindAsync(id);
            //if (employeeClientModel == null)
            //{
            //    return NotFound();
            //}
            //return View(employeeClientModel);
        }

        // POST: EmployeeClientModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,JobTitle,JoinedDate,Department")] Models.EmployeeClientModel employeeClientModel)
        {
            return View();
            //if (id != employeeClientModel.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(employeeClientModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!EmployeeClientModelExists(employeeClientModel.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(employeeClientModel);
        }

        // GET: EmployeeClientModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employeeClientModel = await _context.EmployeeClientModel
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (employeeClientModel == null)
            //{
            //    return NotFound();
            //}

            //return View(employeeClientModel);
        }

        // POST: EmployeeClientModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
            //var employeeClientModel = await _context.EmployeeClientModel.FindAsync(id);
            //_context.EmployeeClientModel.Remove(employeeClientModel);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool EmployeeClientModelExists(int id)
        {
            return true;
        }
    }
}
