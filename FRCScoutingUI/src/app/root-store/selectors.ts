import { createSelector, MemoizedSelector } from "@ngrx/store";
import { ReportStoreSelectors } from "./report-store";
import { ScoutStoreSelectors } from "./scout-store";

export const isLoading: MemoizedSelector<object, any, any> = createSelector(

  ScoutStoreSelectors.isLoading,
  ReportStoreSelectors.isLoading,

  (a: boolean, b: boolean) => {
    return a || b;
  }

);

