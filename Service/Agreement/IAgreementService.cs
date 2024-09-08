using Infrastructure.Pagination;
using Models.AgreementViewModel;
using Models.PolicyViewModel;

namespace Service.Agreement;

public interface IAgreementService  
{
    
    public PaginatedResult<AgreementViewModel> GetAgreements(int pageIndex, int pageSize,AgreementFilterViewModel agreementFilterViewModel);
    public void AddAgreement (AgreementViewModel agreementViewModel);
    
}