using AutoMapper;
using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile() {
            CreateMap<Customers, CustomersViewModel>().ForMember(viewModel => viewModel.Transactions, conf => conf.MapFrom(value => value.Transactions));
            CreateMap<Transactions, TransactionsViewModel>().ForMember(destination => destination.Status,
                 opt => opt.MapFrom(source => Enum.GetName(typeof(StatusCode), source.Status)))
                 .ForMember(destination => destination.TransactionDate,
                 opt => opt.MapFrom(source => source.TransactionDate.ToString("dd/MM/yyyy HH:MM")));
        }
    }
}
