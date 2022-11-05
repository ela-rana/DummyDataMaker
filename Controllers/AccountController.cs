using DummyDataMaker.ViewModels;
using DummyDataMaker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DummyDataMaker.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password,loginViewModel.RememberMe,false); //false: don't lock me
                                                                 //out if wrong password initially
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Login failed");
            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid) //meaning all form fields are filled correctly
            {
                User newUser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber
                };
                var result = await userManager.CreateAsync(newUser, registerViewModel.Password); //userManager will be used to create
                //the actual user in the users table, it will also hash the password and store in a separate table
                if (result.Succeeded) //if account creation is successful
                {
                    if(newUser.UserName == "Admin" || newUser.UserName == "admin")
                    {
                        await userManager.AddToRoleAsync(newUser, "Admin");
                        await userManager.AddToRoleAsync(newUser, "Customer"); //admin is also an employee so they are assigned both
                                                                               //roles here
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newUser, "Customer"); 
                    }
                    return RedirectToAction("Login", "Account"); //then redirect to the login page, so user can login with created
                                                                 //account
                }
                foreach(var error in result.Errors) //if there are errors, add it to the modelstate to return back
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(); //if wasn't valid, stay on this view
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }   

        public IActionResult Index()
        {
            return View();
        }
    }
}
