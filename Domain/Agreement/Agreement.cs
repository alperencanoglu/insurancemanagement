namespace Domain.Agreement;
public class Agreement
{
    public int Id { get; set; }
    public string AgreementName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RiskAmount { get; set; }
    public int? PartnerId { get; set; }

    public  Partner.Partner? Partner { get; set; }
}