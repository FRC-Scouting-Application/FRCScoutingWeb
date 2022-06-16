import { Injectable, OnDestroy } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { AutoUnsubscribe } from "ngx-auto-unsubscribe";
import { catchError, map, of, switchMap } from "rxjs";
import { DataReport } from "@app/features/api/models/report-models";
import { ReportAPIService } from "@app/features/api/services/report.api.service";

import * as featureActions from './actions';

@Injectable()
@AutoUnsubscribe()
export class ReportStoreEffects implements OnDestroy {

  constructor(
    private reportAPIService: ReportAPIService,
    private actions: Actions
  ) { }

  /* Data Report */
  @Effect()
  dataReport$ = this.actions.pipe(
    ofType(featureActions.getDataReportRequest),
    switchMap((action) =>
      this.reportAPIService.GetDataReportAsync()
        .pipe(
          map((payload: DataReport) => featureActions.getDataReportSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  ngOnDestroy() { }

}
