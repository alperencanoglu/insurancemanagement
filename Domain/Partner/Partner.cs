namespace Domain.Partner;

public class Partner
{
    public int Id { get; set; }
    public string PartnerName { get; set; }
    public string Address { get; set; }
    public ICollection<Agreement.Agreement> Agreements { get; set; }
}