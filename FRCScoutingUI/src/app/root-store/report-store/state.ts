import { DataReport } from "@app/features/api/models/report-models";

export interface State {
  dataReport: (DataReport | null);
  loading: boolean;
  error: any;
}

export const initialState: State = {
  dataReport: null,
  loading: false,
  error: null
}
