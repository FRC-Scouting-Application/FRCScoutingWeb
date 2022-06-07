import { createFeatureSelector, createSelector, MemoizedSelector } from "@ngrx/store";
import { State } from "./state";

const loading = (state: State) => state.loading;
const getEvents = (state: State) => state.events;

export const selectScoutState: MemoizedSelector<object, State> = createFeatureSelector<State>('scout');
export const isLoading: MemoizedSelector<object, any> = createSelector(selectScoutState, loading);

export const selectEvents: MemoizedSelector<object, Event[]> = createSelector(selectScoutState, getEvents);
