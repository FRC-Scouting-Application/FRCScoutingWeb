import { createAction, props } from "@ngrx/store";
import { Event, Match, Team, Template } from "../../features/api/models/dbo-models";


export const getEventsRequest = createAction(
  '[Scout] Get Events Request'
);

export const getEventsSuccess = createAction(
  '[Scout] Get Events Success',
  props<{ payload: Event[] }>()
);


export const getTeamsRequest = createAction(
  '[Scout] Get Teams Request'
);

export const getTeamsSuccess = createAction(
  '[Scout] Get Teams Success',
  props<{ payload: Team[] }>()
);


export const getMatchesRequest = createAction(
  '[Scout] Get Matches Request'
);

export const getMatchesSuccess = createAction(
  '[Scout] Get Matches Success',
  props<{ payload: Match[] }>()
);


export const getTemplatesRequest = createAction(
  '[Scout] Get Templates Request'
);

export const getTemplatesSuccess = createAction(
  '[Scout] Get Templates Success',
  props<{ payload: Template[] }>()
)


export const failure = createAction(
  '[Scout] Failure',
  props<{ error: any }>()
);
