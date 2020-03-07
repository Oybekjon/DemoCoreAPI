﻿using AutoMapper;
using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.Data;
using DemoCoreAPI.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<UserDb> _repo;
        private readonly IMapper _mapper;

        public AdminService(IRepository<UserDb> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public UserAPIModel GetUserById(long id)
        {
            var user = _repo.FindById(id);
            return _mapper.Map<UserAPIModel>(user);
        }
        public ICollection<UserAPIModel> GetAllUsers()
        {
            var users = _repo.GeAll();
            return _mapper.Map<ICollection<UserAPIModel>>(users);
        }
        public NewUserAPIModel CreateNewUser(NewUserBindingModel model)
        {
            var newUser = _mapper.Map<UserDb>(model);
            _repo.Add(newUser);
            _repo.SaveChanges();
            return _mapper.Map<NewUserAPIModel>(newUser);
        }

        public UpdatedUserAPIModel UpdateUser(UpdateUserBindingModel model)
        {
            var updatedUser = _mapper.Map<UserDb>(model);
            _repo.Update(updatedUser);
            _repo.SaveChanges();
            return _mapper.Map<UpdatedUserAPIModel>(updatedUser);
        }
    }
}