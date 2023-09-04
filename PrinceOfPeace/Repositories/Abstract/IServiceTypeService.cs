﻿using System;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Repositories.Abstract
{
	public interface IServiceTypeService
	{
        Task<ServiceTypes> Add(ServiceTypes model);

        public bool Update(ServiceTypes model);

        public bool Delete(int id);

        ServiceTypes? FindById(int id);

        public IEnumerable<ServiceTypes> GetAll();
    }
}

