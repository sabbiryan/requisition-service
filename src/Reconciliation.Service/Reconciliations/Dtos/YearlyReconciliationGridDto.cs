using System;
using System.Collections.Generic;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;
using ReconciliationApp.Shared.Extensions;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class YearlyReconciliationGridDto
    {
        public int Year { get; set; }
        public List<YearlyReconciliationGridTitleDto> Titles { get; set; } = new List<YearlyReconciliationGridTitleDto>();
        public List<YearlyReconciliationGridResultDto> Statements { get; set; } = new List<YearlyReconciliationGridResultDto>();
        public List<YearlyReconciliationGridRowDto> Rows { get; set; } = new List<YearlyReconciliationGridRowDto>();
        public List<YearlyReconciliationGridResultDto> Results { get; set; } = new List<YearlyReconciliationGridResultDto>();
    }

    public class YearlyReconciliationGridTitleDto
    {
        public YearlyReconciliationGridTitleDto()
        {
        }

        public YearlyReconciliationGridTitleDto(Month month)
        {
            Month = month;
        }

        public Month Month { get; set; }
        public string MonthDisplayName => Month.GetDescription();
    }


    public class YearlyReconciliationGridRowDto
    {
        public YearlyReconciliationGridRowDto(string incomeOrExpenseTypeName, IncomeOrExpenseFlag flag)
        {
            IncomeOrExpenseTypeName = incomeOrExpenseTypeName;
            Flag = flag;
        }
        public string IncomeOrExpenseTypeName { get; set; }
        public List<YearlyReconciliationGridColumnDto> Columns { get; set; } = new List<YearlyReconciliationGridColumnDto>();
        public IncomeOrExpenseFlag Flag { get; set; }
    }


    public class YearlyReconciliationGridColumnDto
    {
        public string Id { get; set; }
        public string IncomeOrExpenseTypeId { get; set; }
        public int Year { get; set; }
        public Month Month { get; set; }
        public decimal? Amount { get; set; }
        public IncomeOrExpenseFlag Flag { get; set; }
    }


    public class YearlyReconciliationGridResultDto
    {
        public YearlyReconciliationGridResultDto(string title, int order)
        {
            Title = title;
            Order = order;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public List<YearlyReconciliationGridResultValueDto> Values { get; set; } = new List<YearlyReconciliationGridResultValueDto>();
    }


    public class YearlyReconciliationGridResultValueDto
    {
        public YearlyReconciliationGridResultValueDto(Month month)
        {
            Month = month;
        }

        public Month Month { get; set; }
        public decimal? Amount { get; set; }
    }
}