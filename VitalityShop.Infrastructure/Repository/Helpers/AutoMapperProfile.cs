using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;

/* 
 The role of AutoMapper is to automatically map different types of classes together. In our case we'd like to map UserModel to RegisterModel and UpdateModel.
 */
namespace VitalityShop.Infrastructure.Repository.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, User>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
