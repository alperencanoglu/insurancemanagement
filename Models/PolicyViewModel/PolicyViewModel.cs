using Domain;
using Domain.User;

namespace Models.PolicyViewModel;

public class PolicyViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string UserName { get; set; }
    public string UserId { get; set; }

    public PolicyViewModel()
    {
        
    }
    
    public PolicyViewModel(Policies policies)
    {
        Id = policies.Id;
        Name = policies.Name;
        Description = policies.Description;
        Code = policies.Code;
        UserName = policies.User.Name;
        UserId = policies.User.Id;
    }
    
    public Policies ToPolicies()
    {
        return new Policies
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Code = Code,
            UserId = UserId
        };
    }
}