import { Injectable, OnDestroy } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { AutoUnsubscribe } from "ngx-auto-unsubscribe";
import { catchError, map, of, switchMap } from "rxjs";
import { Event, Match, Team, Template } from "../../features/api/models/dbo-models";
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

  @Effect()
  teams$ = this.actions.pipe(
    ofType(featureActions.getEventsRequest),
    switchMap((action) =>
      this.scoutAPIService.GetTeamsAsync()
        .pipe(
          map((payload: Team[]) => featureActions.getTeamsSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  @Effect()
  matches$ = this.actions.pipe(
    ofType(featureActions.getEventsRequest),
    switchMap((action) =>
      this.scoutAPIService.GetMatchesAsync()
        .pipe(
          map((payload: Match[]) => featureActions.getMatchesSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  @Effect()
  templates$ = this.actions.pipe(
    ofType(featureActions.getTemplatesRequest),
    switchMap((action) =>
      this.scoutAPIService.GetTemplatesAsync()
        .pipe(
          map((payload: Template[]) => featureActions.getTemplatesSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  ngOnDestroy() { }

}
