using Infrastructure.Pagination;
using Repositories.UnitOfWork;
using Models.AgreementViewModel;
using Models.PartnerViewModel;
using Service.Agreement;
using Service.Partner;

namespace Service.Policy;

public class PartnerService : IPartnerService
{
    private IUnitOfWork _unitOfWork;

    public PartnerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public PaginatedResult<PartnerViewModel> GetPartners(int pageIndex, int pageSize)
    {
        int ExcludeRecords = (pageSize * pageIndex) - pageSize;
        
        

        var unitOfWorkResult = _unitOfWork.Repository<Domain.Partner.Partner>().GetAll().Result.ToList();
        var partners = unitOfWorkResult.Skip(ExcludeRecords).Take(pageSize).Select(x => new PartnerViewModel(x)).ToList();
        
        var result = new PaginatedResult<PartnerViewModel>
        {
            Page = pageIndex,
            PageSize = pageSize,
            TotalPages = unitOfWorkResult.Count() / pageSize,
            TotalCount = unitOfWorkResult.Count(),
            Items = partners
        };
            
        return result;
    }
    //add
    public void AddPartner(PartnerViewModel partnerViewModel)
    {
        var partner = partnerViewModel.ToPartner();
        _unitOfWork.Repository<Domain.Partner.Partner>().Add(partner);
        _unitOfWork.Save();
    }
}