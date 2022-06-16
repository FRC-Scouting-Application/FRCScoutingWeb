import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { DataReport } from '@app/features/api/models/report-models';
import { ReportStoreActions, ReportStoreSelectors, RootStoreState } from '@app/root-store';

@Component({
  selector: 'app-report-pane',
  templateUrl: './report-pane.component.html',
  styleUrls: ['./report-pane.component.css']
})
export class ReportPaneComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  public dataReport?: DataReport;

  ngOnInit() {
    this.getDataReport();
  }

  getDataReport() {
    this.store.dispatch(ReportStoreActions.getDataReportRequest());

    this.store.pipe(select(ReportStoreSelectors.selectDataReport)).subscribe({
      next: (dataReport: (DataReport | null)) => {
        if (dataReport && dataReport !== null) {
          this.dataReport = dataReport;
          console.log(dataReport);
        }
      },
      error: () => {
        console.error("Failed to get Data Report!")
      }
    })
  }

}
