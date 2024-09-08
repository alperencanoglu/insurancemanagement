namespace Domain.RiskAnalysis;
public class RiskAnalysis
{
    public int Id { get; set; }
    public string AnalysisName { get; set; }
    public decimal RiskScore { get; set; }
    public int AgreementId { get; set; }
        
    public virtual Agreement.Agreement Agreement { get; set; }
}