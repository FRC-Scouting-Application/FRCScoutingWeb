import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-template-editor',
  templateUrl: './template-editor.component.html',
  styleUrls: ['./template-editor.component.css']
})
export class TemplateEditorComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<TemplateEditorComponent>
  ) { }

  ngOnInit() {
  }

  onClose() {
    this.dialogRef.close();
  }
}
