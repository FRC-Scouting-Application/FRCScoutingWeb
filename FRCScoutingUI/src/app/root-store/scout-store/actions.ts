import { createAction, props } from "@ngrx/store";


export const getEventsRequest = createAction(
  '[Scout] Get Events Request'
);

export const getEventsSuccess = createAction(
  '[Scout] Get Events Success',
  props<{ payload: Event[] }>()
);


export const failure = createAction(
  '[Scout] Failure',
  props<{ error: any }>()
);
