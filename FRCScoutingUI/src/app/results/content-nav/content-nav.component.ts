import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, ColGroupDef, StatusPanelDef } from 'ag-grid-community';

@Component({
  selector: 'app-content-nav',
  templateUrl: './content-nav.component.html',
  styleUrls: ['./content-nav.component.css']
})
export class ContentNavComponent implements OnInit {

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  @Input() public columnDefs!: (ColDef | ColGroupDef)[];
  @Input() public defaultColDef!: ColDef;
  @Input() public rowData!: any[];

  constructor() { }

  ngOnInit(): void {

    if (this.defaultColDef == null)
      this.defaultColDef = {
        flex: 1,
        minWidth: 100,
        sortable: true,
        filter: true,
        resizable: true
      }
  }

}
