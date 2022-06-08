import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-table-main',
  templateUrl: './table-main.component.html',
  styleUrls: ['./table-main.component.css']
})
export class TableMainComponent implements OnInit {

  constructor() { }

  @ViewChild(MatTable, { read: ElementRef }) private matTableRef?: ElementRef;

  @Input() def?: TableDef;

  displayedColumns?: string[];

  ngOnInit() {
    if (this.def == null) return;

    this.setDisplayedColumns();
  }

  setDisplayedColumns() {
    this.orderDisplayCols();
    this.createDisplayColumns();
  }

  orderDisplayCols() {
    if (this.def && this.def.displayCols && this.def.displayCols.length > 0) {
      let orderedCols: ColDef[] = [];

      for (let i = 0; i < this.def.displayCols.length; i++) {
        for (let j = 0; j < this.def.colDef.length; j++) {
          if (this.def.displayCols[i] === this.def.colDef[j].name) {
            orderedCols.push(this.def.colDef[j]);
          }
        }
      }

      this.def.colDef = orderedCols;
    }
  }

  createDisplayColumns() {
    if (this.def == null) return;

    let displayCol = [];
    for (let i = 0; i < this.def.colDef.length; i++)
      displayCol.push(this.def.colDef[i].name)

    this.displayedColumns = displayCol;
  }
}

export interface TableDef {
  data?: any[];
  colDef: ColDef[];
  displayCols?: string[]
}

export interface ColDef {
  name: string;
  display: string;
}
