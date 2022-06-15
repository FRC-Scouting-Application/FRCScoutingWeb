import { Injectable, OnDestroy } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { AutoUnsubscribe } from "ngx-auto-unsubscribe";
import { catchError, map, of, switchMap } from "rxjs";
import { Event, Match, Note, Scout, Team, Template } from "../../features/api/models/dbo-models";
import { ScoutAPIService } from "../../features/api/services/scout.api.service";

import * as featureActions from './actions';

@Injectable()
@AutoUnsubscribe()
export class ScoutStoreEffects implements OnDestroy {

  constructor(
    private scoutAPIService: ScoutAPIService,
    private actions: Actions
  ) { }

  /* Events */
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

  /* Teams */
  @Effect()
  teams$ = this.actions.pipe(
    ofType(featureActions.getTeamsRequest),
    switchMap((action) =>
      this.scoutAPIService.GetTeamsAsync()
        .pipe(
          map((payload: Team[]) => featureActions.getTeamsSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  /* Matches */
  @Effect()
  matches$ = this.actions.pipe(
    ofType(featureActions.getMatchesRequest),
    switchMap((action) =>
      this.scoutAPIService.GetMatchesAsync(action.payload)
        .pipe(
          map((payload: Match[]) => featureActions.getMatchesSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  /* Templates */
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


  /* Notes */
  @Effect()
  notesByEvent$ = this.actions.pipe(
    ofType(featureActions.getNotesByEventRequest),
    switchMap((action) =>
      this.scoutAPIService.GetNotesByEventAsync(action.payload)
        .pipe(
          map((payload: Note[]) => featureActions.getNotesSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
      )
  );

  @Effect()
  notesByTeam$ = this.actions.pipe(
    ofType(featureActions.getNotesByTeamRequest),
    switchMap((action) =>
      this.scoutAPIService.GetNotesByTeamAsync(action.payload)
        .pipe(
          map((payload: Note[]) => featureActions.getNotesSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );


  /* Scouts */
  @Effect()
  scoutsByEvent$ = this.actions.pipe(
    ofType(featureActions.getScoutsByEventRequest),
    switchMap((action) =>
      this.scoutAPIService.GetScoutsByEventAsync(action.payload)
        .pipe(
          map((payload: Scout[]) => featureActions.getScoutsSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  @Effect()
  scoutsByTeam$ = this.actions.pipe(
    ofType(featureActions.getScoutsByTeamRequest),
    switchMap((action) =>
      this.scoutAPIService.GetScoutsByTeamAsync(action.payload)
        .pipe(
          map((payload: Scout[]) => featureActions.getScoutsSuccess({ payload })),
          catchError(error => of(featureActions.failure({ error })))
        )
    )
  );

  ngOnDestroy() { }

}
