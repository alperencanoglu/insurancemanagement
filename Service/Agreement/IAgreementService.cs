using Infrastructure.Pagination;
using Models.AgreementViewModel;
using Models.PolicyViewModel;

namespace Service.Agreement;

public interface IAgreementService  
{
    
    public PaginatedResult<AgreementViewModel> GetAgreements(int pageIndex, int pageSize,AgreementFilterViewModel agreementFilterViewModel);
    public PaginatedResult<AgreementViewModel> GetAgreementsWithName(string name);
    public void AddAgreement (AgreementViewModel agreementViewModel);
    
}