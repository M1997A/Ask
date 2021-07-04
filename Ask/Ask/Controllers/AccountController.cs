using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ask.Models;
using Ask.Models.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MimeKit;
using SendGrid.Helpers.Mail;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IEmailSender emailSender;
        public AccountController(UserManager<AppUser> usrMgr,IEmailSender sender,SignInManager<AppUser> signInMngr)
        {
            signInManager = signInMngr;
            emailSender = sender;
            userManager = usrMgr;
        }
        public IActionResult Register()
        {
            userManager.GetUserId(User);
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(SignUpVM signUpVM)
        {
            
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = signUpVM.UserName,
                    Email = signUpVM.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, signUpVM.Password);
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    
                    var callbackUrl = Url.Action("ConfirmEmail","Account",
                         new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                     //var htmlMessage = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Ask", "made319006@gmail.com"));
                    message.To.Add(new MailboxAddress(user.Email));
                    message.Subject = "Confirm Your Eamil";
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                    message.Body = bodyBuilder.ToMessageBody();
                    using(var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("made319006@gmail.com", "01066384510");
                        client.Send(message);
                        
                        client.Disconnect(true);
                    }








                    //var htmlMessage = "Ok";
                    //await emailSender.SendEmailAsync(user.Email,"Confirm Email",htmlMessage );
                    //TempData["htmlMessage"] = htmlMessage;
                    return RedirectToAction("ConfirmEmail");
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(signUpVM);
        }
        public IActionResult Login(string ReturnUrl)
        {
            if(ReturnUrl != null)
            {
                ViewBag.Message = "You must be logged in to ask a question";
                ViewBag.ReturnUrl = ReturnUrl;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string ReturnUrl)
        {
            
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginVM.UserName);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        if(ReturnUrl != null)
                        {
                            return Redirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                ModelState.AddModelError("", "Invalid username and/or password");
            }
            return View(loginVM);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);
            if(user != null)
            {
                IdentityResult result = await userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                {
                    TempData["ConfirmationMessage"] = "Your Eamil confirmed successfully";
                }
            }
            
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
