using Infrastructure.Pagination;
using LinqKit;
using Repositories.UnitOfWork;
using Models.AgreementViewModel;
using Service.Agreement;

namespace Service.Policy;

public class AgreementService :IAgreementService
{
    private IUnitOfWork _unitOfWork;

    public AgreementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public PaginatedResult<AgreementViewModel> GetAgreements(int pageIndex, int pageSize,AgreementFilterViewModel agreementFilterViewModel)
    {
        int ExcludeRecords = (pageSize * pageIndex) - pageSize;
        
       var predicate =  PredicateBuilder.New<Domain.Agreement.Agreement>(true);
    
       
        var unitOfWorkResult = _unitOfWork.Repository<Domain.Agreement.Agreement>().GetAll(x=>x.Partner).Result;


        if (agreementFilterViewModel.StartDate != null)
        {
            predicate.And(x=> x.StartDate >= agreementFilterViewModel.StartDate);
        }

        if (agreementFilterViewModel.EndDate != null)
        {
            predicate.And( x=> x.EndDate <= agreementFilterViewModel.EndDate);
        }

        if (agreementFilterViewModel.SelectedPartnerIds != null)
        {
            predicate.And( x=> agreementFilterViewModel.SelectedPartnerIds.Contains((int)x.PartnerId));
        }

        var agreements = unitOfWorkResult.Where(predicate).Skip(ExcludeRecords).Take(pageSize).Select(x => new AgreementViewModel(x)).ToList();
        
        var result = new PaginatedResult<AgreementViewModel>
        {
            Page = pageIndex,
            PageSize = pageSize,
            TotalPages = unitOfWorkResult.Count() / pageSize,
            TotalCount = unitOfWorkResult.Count(),
            Items = agreements
        };
            
        return result;
    }
    
    public PaginatedResult<AgreementViewModel> GetAgreementsWithName(string name)
    {
        var unitOfWorkResult = _unitOfWork.Repository<Domain.Agreement.Agreement>().GetAll(x=>x.Partner).Result;
        var agreements = unitOfWorkResult.Where(x => x.AgreementName.ToLower().Contains( name.ToLower())).Take(10).Select(x => new AgreementViewModel(x)).ToList();
        var result = new PaginatedResult<AgreementViewModel>
        {
            Page = 1,
            PageSize = 10,
            TotalPages = unitOfWorkResult.Count() / 100,
            TotalCount = unitOfWorkResult.Count(),
            Items = agreements
        };
        return result;
    }
    //add 
    public void AddAgreement(AgreementViewModel agreementViewModel)
    {
        var agreement = agreementViewModel.ToAgreement();
        _unitOfWork.Repository<Domain.Agreement.Agreement>().Add(agreement);
        _unitOfWork.Save();
    }
}