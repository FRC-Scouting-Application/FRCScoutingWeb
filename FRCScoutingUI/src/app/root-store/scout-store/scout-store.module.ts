import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

import { ScoutStoreEffects } from './effects';
import { featureReducer } from './reducer';

@NgModule({
    imports: [
        CommonModule,
        StoreModule.forFeature('scout', featureReducer),
        EffectsModule.forFeature([ScoutStoreEffects])
    ]
})
export class ScoutStoreModule {}