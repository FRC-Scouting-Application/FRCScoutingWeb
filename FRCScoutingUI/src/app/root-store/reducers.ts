import { ActionReducerMap } from "@ngrx/store";

import { featureReducer as scoutReducer } from './scout-store/reducer';
import { featureReducer as reportReducer } from './report-store/reducer';

export const reducers: ActionReducerMap<any> = {
  scout: scoutReducer,
  report: reportReducer
}
