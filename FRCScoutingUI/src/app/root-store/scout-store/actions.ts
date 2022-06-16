import { createAction, props } from "@ngrx/store";
import { Event, Match, Note, Scout, Team, Template } from "@app/features/api/models/dbo-models";

/* Events */
export const getEventsRequest = createAction(
  '[Scout] Get Events Request'
);

export const getEventsSuccess = createAction(
  '[Scout] Get Events Success',
  props<{ payload: Event[] }>()
);

/* Teams */
export const getTeamsRequest = createAction(
  '[Scout] Get Teams Request'
);

export const getTeamsSuccess = createAction(
  '[Scout] Get Teams Success',
  props<{ payload: Team[] }>()
);

/* Matches */
export const getMatchesRequest = createAction(
  '[Scout] Get Matches Request',
  props<{ payload: string }>()
);

export const getMatchesSuccess = createAction(
  '[Scout] Get Matches Success',
  props<{ payload: Match[] }>()
);

/* Templates */
export const getTemplatesRequest = createAction(
  '[Scout] Get Templates Request'
);

export const getTemplatesSuccess = createAction(
  '[Scout] Get Templates Success',
  props<{ payload: Template[] }>()
)

/* Notes */
export const getNotesByEventRequest = createAction(
  '[Scout] Get Notes By Event Request',
  props<{ payload: string }>()
);

export const getNotesByTeamRequest = createAction(
  '[Scout] Get Notes By Team Request',
  props<{ payload: string }>()
);

export const getNotesSuccess = createAction(
  '[Scout] Get Notes Success',
  props<{ payload: Note[] }>()
)

/* Scouts */
export const getScoutsByEventRequest = createAction(
  '[Scout] Get Scouts By Event Request',
  props<{ payload: string }>()
);

export const getScoutsByTeamRequest = createAction(
  '[Scout] Get Scouts By Team Request',
  props<{ payload: string }>()
);

export const getScoutsSuccess = createAction(
  '[Scout] Get Notes Success',
  props<{ payload: Scout[] }>()
)

export const failure = createAction(
  '[Scout] Failure',
  props<{ error: any }>()
);
