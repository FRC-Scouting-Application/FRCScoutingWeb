import { Injectable, OnDestroy } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { AutoUnsubscribe } from "ngx-auto-unsubscribe";
import { catchError, map, of, switchMap } from "rxjs";
import { ScoutAPIService } from "../../features/api/services/scout.api.service";

import * as featureActions from './actions';

@Injectable()
@AutoUnsubscribe()
export class ScoutStoreEffects implements OnDestroy {

  constructor(
    private scoutAPIService: ScoutAPIService,
    private actions: Actions
  ) { }


  @Effect()
  events$ = this.actions.pipe(
    ofType(featureActions.getEventsRequest),
    switchMap((action) =>
      this.scoutAPIService.GetEventsAsync()
        .pipe(
          map((payload: Event[]) => featureActions.getEventsSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
      )
  );


  ngOnDestroy() { }

}
