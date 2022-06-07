import { ActionReducerMap } from "@ngrx/store";

import { featureReducer as scoutReducer } from './scout-store/reducer';

export const reducers: ActionReducerMap<any> = {
  scout: scoutReducer
}
