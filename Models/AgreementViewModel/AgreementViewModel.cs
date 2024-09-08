using Domain;
using Domain.Agreement;
using Domain.User;

namespace Models.AgreementViewModel;

public class AgreementViewModel
{
   
    
    public int Id { get; set; }
    public string AgreementName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RiskAmount { get; set; }
    public int PartnerId { get; set; }

    public AgreementViewModel()
    {
        
    }
    public AgreementViewModel(Agreement agreement)
    {
        Id = agreement.Id;
        AgreementName = agreement.AgreementName;
        StartDate = agreement.StartDate;
        EndDate = agreement.EndDate;
        RiskAmount = agreement.RiskAmount;
        PartnerId = agreement.Partner.Id;
    }
    
    public Agreement ToAgreement()
    {
        return new Agreement()
        {
            Id = Id,
            AgreementName = AgreementName,
            StartDate = StartDate,
            EndDate = EndDate,
            RiskAmount = RiskAmount,
            PartnerId = PartnerId
        };
    }
}
