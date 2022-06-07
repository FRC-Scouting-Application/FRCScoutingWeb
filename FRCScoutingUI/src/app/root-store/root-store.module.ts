import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { ScoutStoreModule } from './scout-store';

import { reducers } from './reducers';

@NgModule({

    imports: [
        CommonModule,
        ScoutStoreModule,
        StoreModule.forRoot(reducers, {
            runtimeChecks: {
                strictStateImmutability: false,
                strictActionImmutability: false,
            }
        }),

        EffectsModule.forRoot([]),
        StoreDevtoolsModule.instrument({ maxAge: 25 })
    ],

    declarations: [],

    providers: []
})
export class RootStoreModule { }
