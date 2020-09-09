using Application.Dtos.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        private readonly CategoryForCreationDto _categoryForCreationDto;

        public CreateCategoryCommand(CategoryForCreationDto categoryForCreationDto)
        {
            _categoryForCreationDto = categoryForCreationDto;
        }


        internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var categoryEntity = _mapper.Map<Category>(request._categoryForCreationDto);

                await _categoryRepository.AddAsync(categoryEntity);

                var cagoryDtoToReturn = _mapper.Map<CategoryDto>(categoryEntity);

                return cagoryDtoToReturn;
            }
        }
    }
}
