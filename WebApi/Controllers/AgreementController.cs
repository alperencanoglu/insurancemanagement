using Microsoft.AspNetCore.Mvc;
using Models.AgreementViewModel;
using Service.Agreement;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AgreementController : ControllerBase
{
   private IAgreementService _agreementService;
      
   public AgreementController(IAgreementService agreementService)
   {
       _agreementService = agreementService;
   }
   [HttpPost("CreateAgreement")]
   public IActionResult CreateAgreement(AgreementViewModel agreementViewModel)
   {
         _agreementService.AddAgreement(agreementViewModel);
       return Ok();
   }

}