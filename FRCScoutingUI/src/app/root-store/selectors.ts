import { createSelector, MemoizedSelector } from "@ngrx/store";
import { ScoutStoreSelectors } from "./scout-store";

export const isLoading: MemoizedSelector<object, any, any> = createSelector(
  ScoutStoreSelectors.isLoading,
  (a: boolean) => {
    return a;
  }
);
