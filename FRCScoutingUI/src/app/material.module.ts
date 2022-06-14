import { NgModule } from "@angular/core";

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';

const materialModules = [
  MatButtonModule,
  MatDialogModule,
  MatIconModule,
  DragDropModule,
  MatFormFieldModule,
  MatInputModule,
  MatRadioModule,
  MatCheckboxModule
]

@NgModule({
  imports: [
    ...materialModules
  ],
  exports: [
    ...materialModules
  ]
})
export class MaterialModule { }
