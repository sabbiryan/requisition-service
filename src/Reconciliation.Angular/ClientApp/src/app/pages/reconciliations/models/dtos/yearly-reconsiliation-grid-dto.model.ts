import { Month } from "../enums/month.enum";
import { IncomeOrExpenseFlag } from "../enums/income-or-expense-flag.enum";

export class YearlyReconciliationGridDto {
    year: number;
    titles: YearlyReconciliationGridTitleDto[];
    statements: YearlyReconciliationGridResultDto[];
    rows: YearlyReconciliationGridRowDto[];
    results: YearlyReconciliationGridResultDto[];
}

export class YearlyReconciliationGridTitleDto {
    month: Month;
    monthDisplayName: string;
}

export class YearlyReconciliationGridRowDto {
    incomeOrExpenseTypeName: string;
    columns: YearlyReconciliationGridColumnDto[];
    flag: IncomeOrExpenseFlag;
}

export class YearlyReconciliationGridColumnDto {
    id: string;
    incomeOrExpenseTypeId: string;
    year: number;
    month: Month;
    amount: number | null;
    flag: IncomeOrExpenseFlag;
}

export class YearlyReconciliationGridResultDto {
    order: number;
    title: string;
    values: YearlyReconciliationGridResultValueDto[];
}

export class YearlyReconciliationGridResultValueDto {
    month: Month;
    amount: number | null;
}