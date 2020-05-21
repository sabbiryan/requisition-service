using AutoMapper;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.IncomeOrExpenses.Dtos;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Mappers
{
    public class MapperProfiler : Profile
    {

        public static void Config(IMapperConfigurationExpression obj)
        {
            //Write your mapping profiles here
            //obj.CreateMap<Model, Dto>().ReverseMap();

            obj.CreateMap<IncomeOrExpenseType, IncomeOrExpenseTypeDto>().ReverseMap();
            obj.CreateMap<IncomeOrExpenseType, IncomeOrExpenseTypeListDto>().ReverseMap();

            obj.CreateMap<IncomeOrExpense, IncomeOrExpenseListDto>().ReverseMap();

            obj.CreateMap<Reconciliation, ReconciliationListDto>().ReverseMap();
            obj.CreateMap<Reconciliation, ReconciliationDto>().ReverseMap();
            obj.CreateMap<Reconciliation, ReconciliationFormDto>().ReverseMap();
            obj.CreateMap<ReconciliationDto, ReconciliationFormDto>().ReverseMap();
        }


    }
}