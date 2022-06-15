import { createFeatureSelector, createSelector, MemoizedSelector } from "@ngrx/store";
import { Event, Match, Note, Scout, Team, Template } from "../../features/api/models/dbo-models";
import { State } from "./state";

const loading = (state: State) => state.loading;
const getEvents = (state: State) => state.events;
const getTeams = (state: State) => state.teams;
const getMatches = (state: State) => state.matches;
const getTemplates = (state: State) => state.templates;
const getNotes = (state: State) => state.notes;
const getScouts = (state: State) => state.scouts;

export const selectScoutState: MemoizedSelector<object, State> = createFeatureSelector<State>('scout');
export const isLoading: MemoizedSelector<object, any> = createSelector(selectScoutState, loading);

export const selectEvents: MemoizedSelector<object, Event[]> = createSelector(selectScoutState, getEvents);
export const selectTeams: MemoizedSelector<object, Team[]> = createSelector(selectScoutState, getTeams);
export const selectMatches: MemoizedSelector<object, Match[]> = createSelector(selectScoutState, getMatches);
export const selectTemplates: MemoizedSelector<object, Template[]> = createSelector(selectScoutState, getTemplates);
export const selectNotes: MemoizedSelector<object, Note[]> = createSelector(selectScoutState, getNotes);
export const selectScouts: MemoizedSelector<object, Scout[]> = createSelector(selectScoutState, getScouts);
