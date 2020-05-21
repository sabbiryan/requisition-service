import { DtoBase } from "src/app/shared/dto-base.model";

export class ReconciliationFormDto extends DtoBase<string> {
    year: number;
    month: number;
    incomeOrExpenseTypeId: string;
    amount: number;
}