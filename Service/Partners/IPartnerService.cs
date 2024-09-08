using Infrastructure.Pagination;
using Models.PartnerViewModel;

namespace Service.Partner;

public interface IPartnerService  
{
    
    public PaginatedResult<PartnerViewModel> GetPartners(int pageIndex, int pageSize);
    public void AddPartner (PartnerViewModel PartnerViewModel);
    
}