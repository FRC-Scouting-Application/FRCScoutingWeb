import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { EffectsModule } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";
import { ReportStoreEffects } from "./effects";
import { featureReducer } from "./reducer";

@NgModule({
  imports: [
    CommonModule,
    StoreModule.forFeature('report', featureReducer),
    EffectsModule.forFeature([ReportStoreEffects])
  ]
})
export class ReportStoreModule { }
