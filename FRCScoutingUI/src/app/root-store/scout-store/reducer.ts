import { createReducer, on } from "@ngrx/store";
import { getEventsRequest, getEventsSuccess, getMatchesRequest, getMatchesSuccess, getNotesByEventRequest, getNotesByTeamRequest, getNotesSuccess, getScoutsByEventRequest, getScoutsByTeamRequest, getScoutsSuccess, getTeamsRequest, getTeamsSuccess, getTemplatesRequest, getTemplatesSuccess } from "./actions";
import { initialState } from "./state";

const scoutReducer = createReducer(

  initialState,

  /* Events */
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


  /* Teams */
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


  /* Matches */
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
  }),


  /* Templates */
  on(getTemplatesRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),
  on(getTemplatesSuccess, (state, { payload }) => {
    return ({
      ...state,
      templates: payload,
      loading: false,
      error: null
    })
  }),


  /* Notes */
  on(getNotesByEventRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),
  on(getNotesByTeamRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),
  on(getNotesSuccess, (state, { payload }) => {
    return ({
      ...state,
      notes: payload,
      loading: false,
      error: null
    })
  }),


  /* Scouts */
  on(getScoutsByEventRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),
  on(getScoutsByTeamRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    })
  }),
  on(getScoutsSuccess, (state, { payload }) => {
    return ({
      ...state,
      scouts: payload,
      loading: false,
      error: null
    })
  })
);

export function featureReducer(state: any, action: any) {
  return scoutReducer(state, action);
}
