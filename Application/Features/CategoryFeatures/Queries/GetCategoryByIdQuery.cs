using Application.Dtos.Category;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery: IRequest<CategoryDto>
    {
        public int Id{ get; private set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }


        internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var categoryFromDb = await _categoryRepository.FindAsync(request.Id);

                var categoryDtoToReturn = _mapper.Map<CategoryDto>(categoryFromDb);

                return categoryDtoToReturn;
            }
        }
    }
}
