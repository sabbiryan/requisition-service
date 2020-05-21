import { DtoBase } from "src/app/shared/dto-base.model";
import { Month } from "../enums/month.enum";
import { IncomeOrExpenseTypeDto } from "./income-or-expense-type-dto.model";

export class ReconciliationListDto extends DtoBase<string> {
    incomeOrExpenseTypeId: string;
    incomeOrExpenseType: IncomeOrExpenseTypeDto;
    month: Month;
    monthDisplayText: string;
    amount: number;
}