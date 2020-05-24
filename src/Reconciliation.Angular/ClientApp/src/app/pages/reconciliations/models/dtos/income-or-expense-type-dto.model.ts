import { DtoBase } from "src/app/shared/dto-base.model";
import { IncomeOrExpenseFlag } from "../enums/income-or-expense-flag.enum";

export class IncomeOrExpenseTypeDto extends DtoBase<string> {
    displayName: string;
    flag: IncomeOrExpenseFlag;
    flagDisplayText: string;
}