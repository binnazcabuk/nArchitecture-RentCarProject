using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries
{
    public class GetListModelDynamicQuery : IRequest<ListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelDynamicQueryHandler : IRequestHandler<GetListModelDynamicQuery, ListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ListModel> Handle(GetListModelDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, include: r => r.Include(i => i.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var listModel = _mapper.Map<ListModel>(models);
                return listModel;
            }
        }
    }
}
