import { ReportStoreState } from "./report-store";
import { ScoutStoreState } from "./scout-store";

export interface State {
  scout: ScoutStoreState.State;
  report: ReportStoreState.State;
}
