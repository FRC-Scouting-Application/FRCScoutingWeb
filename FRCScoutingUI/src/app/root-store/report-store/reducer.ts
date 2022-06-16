import { createReducer, on } from "@ngrx/store";
import { getDataReportRequest, getDataReportSuccess } from "./actions";
import { initialState } from "./state";

const reportReducer = createReducer(

  initialState,

  /* Data Report */
  on(getDataReportRequest, (state) => {
    return ({
      ...state,
      loading: true,
      error: null
    });
  }),
  on(getDataReportSuccess, (state, { payload }) => {
    return ({
      ...state,
      dataReport: payload,
      loading: false,
      error: null
    });
  })

)

export function featureReducer(state: any, action: any) {
  return reportReducer(state, action);
}
