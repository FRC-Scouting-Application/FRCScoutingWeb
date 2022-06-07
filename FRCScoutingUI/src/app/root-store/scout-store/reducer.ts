import { createReducer, on } from "@ngrx/store";
import { getEventsRequest, getEventsSuccess } from "./actions";
import { initialState } from "./state";


const scoutReducer = createReducer(

  initialState,

  on(getEventsRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    });
  }),

  on(getEventsSuccess, (state, { payload }) => {
    return ({
      ...state,
      events: payload,
      loading: false,
      error: null
    });
  })
);

export function featureReducer(state: any, action: any) {
  return scoutReducer(state, action);
}
