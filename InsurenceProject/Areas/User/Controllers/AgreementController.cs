using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Domain.Agreement;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.AgreementViewModel;
using Models.PolicyViewModel;
using Service.Agreement;
using Service.Partner;
using Service.Policy;

namespace WebApplication5.Controllers
{
    [Area("User")]

    public class AgreementController : Controller
    {
        
        private IAgreementService _agreementService;
        private IPartnerService _partnerService;
        private UserManager<User> _userManager;
        public AgreementController(IAgreementService agreementService, UserManager<User> userManager, IPartnerService partnerService)
        {
            _agreementService = agreementService;
            _userManager = userManager;
            _partnerService = partnerService;
        }
        
        [Area("User")]
        // GET: Policy
        public ActionResult Index(AgreementFilterViewModel agreementFilterViewModel)
        {
            
            var agreements = _agreementService.GetAgreements(1, int.MaxValue, agreementFilterViewModel);

            var agreementFilterModel = new AgreementFilterViewModel();
            agreementFilterModel.PaginatedResult = agreements;
            agreementFilterModel.Partners = _partnerService.GetPartners(1, 100).Items.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.PartnerName
            }).ToList();
            agreementFilterModel.SelectedPartnerIds = agreementFilterViewModel.SelectedPartnerIds;
            agreementFilterModel.StartDate = agreementFilterViewModel.StartDate;
            agreementFilterModel.EndDate = agreementFilterViewModel.EndDate;
            
            
            return View(agreementFilterModel);
           
        }
        [HttpPost]
        public List<AgreementViewModel> GetAgreementsWithName(string name)
        {
            var agreements = _agreementService.GetAgreementsWithName(name);
            return agreements.Items.ToList();
        }

        // GET: Policy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Policy/Create
        public ActionResult Create()
        {
            ViewBag.Partners = _partnerService.GetPartners(0, int.MaxValue).Items.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.PartnerName
            }).ToList();;
            return View();
        }

        // POST: Policy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                AgreementViewModel agreementViewModel = new AgreementViewModel();
                //get user id from user
                var user = _userManager.GetUserId(User);
               
                agreementViewModel.AgreementName = collection["AgreementName"];
                agreementViewModel.StartDate = Convert.ToDateTime(collection["StartDate"]);
                agreementViewModel.EndDate = Convert.ToDateTime(collection["EndDate"]);
                agreementViewModel.RiskAmount = Convert.ToDecimal(collection["RiskAmount"]);
                agreementViewModel.PartnerId = Convert.ToInt32(collection["PartnerId"]);
                _agreementService.AddAgreement(agreementViewModel);
                
                
           
                
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