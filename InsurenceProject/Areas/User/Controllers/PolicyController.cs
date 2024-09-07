using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.PolicyViewModel;
using Service.Policy;

namespace WebApplication5.Controllers
{
    [Area("User")]

    public class PolicyController : Controller
    {
        
        private IPolicyService _policyService;
        private UserManager<User> _userManager;
        public PolicyController(IPolicyService policyService, UserManager<User> userManager)
        {
            _policyService = policyService;
            _userManager = userManager;    
        }
        
        [Area("User")]
        // GET: Policy
        public ActionResult Index()
        {
            
           
            return View( _policyService.GetPolicies(  1,10));
        }

        // GET: Policy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Policy/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Policy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                PolicyViewModel policyViewModel = new PolicyViewModel();
                //get user id from user
                var user = _userManager.GetUserId(User);

                policyViewModel.UserId = user;
                policyViewModel.Id = 0;
                policyViewModel.Code = collection["Code"];
                policyViewModel.Name = collection["Name"];
                policyViewModel.Description = collection["Description"];
                _policyService.AddPolicy(policyViewModel);
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Policy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Policy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Policy/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}