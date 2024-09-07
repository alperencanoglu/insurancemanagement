using Infrastructure.Pagination;
using Models.PolicyViewModel;

namespace Service.Policy;

public interface IPolicyService  
{
    
    public PaginatedResult<PolicyViewModel> GetPolicies(int pageIndex, int pageSize);
    public void AddPolicy (PolicyViewModel policyViewModel);
    
}