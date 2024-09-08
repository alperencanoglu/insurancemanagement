using Domain;
using Domain.User;
using Infrastructure.Pagination;
using Models.PolicyViewModel;
using Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Service.Policy;

public class PolicyService :IPolicyService
{
    private IUnitOfWork _unitOfWork;

    public PolicyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public PaginatedResult<PolicyViewModel> GetPolicies(int pageIndex, int pageSize)
    {
        int ExcludeRecords = (pageSize * pageIndex) - pageSize;
        
        

        var unitOfWorkResult = _unitOfWork.Repository<Policies>().GetAll(x=>x.User).Result.Where(x=>x.IsDeleted==false ).ToList();
        var policies = unitOfWorkResult.Skip(ExcludeRecords).Take(pageSize).Select(x => new PolicyViewModel(x)).ToList();
        
        var result = new PaginatedResult<PolicyViewModel>
        {
            Page = pageIndex,
            PageSize = pageSize,
            TotalPages = unitOfWorkResult.Count() / pageSize,
            TotalCount = unitOfWorkResult.Count(),
            Items = policies
        };
            
        return result;
    }
    //get by id
    public PolicyViewModel GetPolicyById(int id)
    {
        var policy = _unitOfWork.Repository<Policies>().GetById(id).Result;
        return new PolicyViewModel(policy);
    }
    
    //add
    public void AddPolicy(PolicyViewModel policyViewModel)
    {
        var policy = policyViewModel.ToPolicies();
        _unitOfWork.Repository<Policies>().Add(policy);
        _unitOfWork.Save();
    }
    
    //update
    public void UpdatePolicy(PolicyViewModel policyViewModel)
    {
        var policy = policyViewModel.ToPolicies();
        _unitOfWork.Repository<Policies>().Update(policy);
        _unitOfWork.Save();
    }
    //delete but not hard delete
    public void DeletePolicy(int id)
    {
        var policy = _unitOfWork.Repository<Policies>().GetById(id).Result;
        policy.IsDeleted = true;
        _unitOfWork.Repository<Policies>().Update(policy);
        _unitOfWork.Save();
    }
    
    
}