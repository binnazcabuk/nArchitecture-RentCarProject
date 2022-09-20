using Application.Features.Models.Dtos;
using Core.Persistence.Paging;
using System.Collections.Generic;

namespace Application.Features.Models.Models
{
    public class ListModel : BasePageableModel
    {
        public IList<ModelListDto> Items { get; set; }
    }
}
