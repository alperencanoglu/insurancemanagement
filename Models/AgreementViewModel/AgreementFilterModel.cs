using Domain.Agreement;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.AgreementViewModel;


public class AgreementFilterViewModel
{
    public List<int> SelectedPartnerIds { get; set; }
    public IEnumerable<SelectListItem> Partners { get; set; }

    // Ek filtre kriterleri ekleyebilirsiniz
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public PaginatedResult<AgreementViewModel> PaginatedResult { get; set; }
    
}