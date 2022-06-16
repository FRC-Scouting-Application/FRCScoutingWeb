import { createFeatureSelector, createSelector, MemoizedSelector } from "@ngrx/store";
import { DataReport } from "@app/features/api/models/report-models";
import { State } from "./state";

const loading = (state: State) => state.loading;
const getDataReport = (state: State) => state.dataReport;

export const selectReportState: MemoizedSelector<object, State> = createFeatureSelector<State>('report');
export const isLoading: MemoizedSelector<object, any> = createSelector(selectReportState, loading);

export const selectDataReport: MemoizedSelector<object, (DataReport | null)> = createSelector(selectReportState, getDataReport);
