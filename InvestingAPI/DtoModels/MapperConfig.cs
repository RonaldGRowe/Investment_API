using AutoMapper;
using InvestmentsAPI.DtoModels.Account;
using InvestmentsAPI.DtoModels.Transaction;

namespace InvestmentsAPI.DtoModels
{
    public class MapperConfig : Profile
    {

            public MapperConfig()
        {
            CreateMap<AccountCreateDto, InvestingAPI.Data.Account>().ReverseMap();
            CreateMap<AccountsGetDto, InvestingAPI.Data.Account>().ReverseMap();
            CreateMap<AccountEditDto, InvestingAPI.Data.Account>().ReverseMap();
            CreateMap<AccountGetNetDto, InvestingAPI.Data.Account>().ReverseMap();

            CreateMap<TransactionCreateDto, InvestingAPI.Data.Transaction>().ReverseMap();

        }
        
    }
}
