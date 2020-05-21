import { Component, Inject, Injector, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AppComponentBase } from '../shared/app-component-base';
import { ReconciliationListDto } from './models/dtos/reconciliation-list-dto.model';
import { YearlyReconciliationGridColumnDto } from './models/dtos/yearly-reconsiliation-grid-dto.model';
import { ReconciliationFormDto } from './models/dtos/reconciliation-form-dto.model';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends AppComponentBase implements OnInit {

  @ViewChild("amountInput", { static: false }) amountInput: ElementRef;

  grid: ReconciliationListDto[];
  isEditing: boolean = false;
  editingRow: number;
  editingCol: number;

  constructor(injector: Injector) {
    super(injector);

  }

  ngOnInit(): void {
    this.getYearlyTable();
  }


  getYearlyTable() {
    this.httpClient.get<ReconciliationListDto[]>(this.baseUrl + 'reconciliation/yearly-table')
      .subscribe(result => {
        this.grid = result;
      }, error => console.error(error));
  }

  editCell(row: number, col: number) {
    if (this.isSaving) return;

    this.isEditing = true;
    this.editingRow = row;
    this.editingCol = col;

    setTimeout(() => {
      this.amountInput.nativeElement.focus();
    }, 100)
  }

  saveOrUpdate(column: YearlyReconciliationGridColumnDto) {

    let input = new ReconciliationFormDto();
    input.id = column.id;
    input.incomeOrExpenseTypeId = column.incomeOrExpenseTypeId;
    input.month = column.month;
    input.year = column.year;
    input.amount = column.amount;

    this.isSaving = true;
    this.httpClient.put(this.baseUrl + 'reconciliation', input)
      .pipe(finalize(() => { this.isSaving = false }))
      .subscribe(result => {
        this.getYearlyTable();

        this.resetCell();
      }, error => {
        console.error(error);
      });
  }

  resetCell() {
    this.isEditing = false;
    this.editingRow = undefined;
    this.editingCol = undefined;
  }

}
