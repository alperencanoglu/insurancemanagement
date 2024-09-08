using Domain;
using Domain.Partner;
namespace Models.PartnerViewModel;

public class PartnerViewModel
{
    public int Id { get; set; }
    public string PartnerName { get; set; }
    public string Address { get; set; }

    public PartnerViewModel()
    {
        
    }
    public PartnerViewModel(Partner partner)
    {
        Id = partner.Id;
        PartnerName = partner.PartnerName;
        Address = partner.Address;
    }
    
    public Partner ToPartner()
    {
        return new Partner()
        {
            Id = Id,
            PartnerName = PartnerName,
            Address = Address
        };
    }
}