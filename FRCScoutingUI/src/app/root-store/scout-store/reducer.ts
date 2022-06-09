import { createReducer, on } from "@ngrx/store";
import { getEventsRequest, getEventsSuccess, getMatchesRequest, getMatchesSuccess, getTeamsRequest, getTeamsSuccess } from "./actions";
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
  }),

  on(getTeamsRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),

  on(getTeamsSuccess, (state, { payload }) => {
    return ({
      ...state,
      teams: payload,
      loading: false,
      error: null
    })
  }),

  on(getMatchesRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),

  on(getMatchesSuccess, (state, { payload }) => {
    return ({
      ...state,
      matches: payload,
      loading: false,
      error: null
    })
  })
);

export function featureReducer(state: any, action: any) {
  return scoutReducer(state, action);
}
