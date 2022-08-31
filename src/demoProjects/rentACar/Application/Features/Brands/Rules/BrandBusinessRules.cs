﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }
        public async Task BrandShouldExistWhenRequested(Brand brand)
        {
            if (brand == null) throw new BusinessException("Requested brand does not exist.");
        }
    }
}
