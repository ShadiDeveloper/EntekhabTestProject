using Application.Models.DTOs;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Salary, SalaryRequestDTO>().ReverseMap();
            CreateMap<Salary, SalaryResponseDTO>()
                .ForMember(d=>d.Date,opt=>opt.MapFrom(x=>x.DateSalary.DateTimeToShamsi()));
        }
    }
}
