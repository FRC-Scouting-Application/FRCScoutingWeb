import { createAction, props } from "@ngrx/store";
import { DataReport } from "@app/features/api/models/report-models";

/* Data Report */
export const getDataReportRequest = createAction(
  '[Report] Get Data Report Request'
);

export const getDataReportSuccess = createAction(
  '[Report] Get Data Report Success',
  props<{ payload: DataReport }>()
)


export const failure = createAction(
  '[Scout] Failure',
  props<{ error: any }>()
);
