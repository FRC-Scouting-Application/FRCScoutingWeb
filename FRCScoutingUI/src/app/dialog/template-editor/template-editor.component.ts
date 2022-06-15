import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Counter, List, TemplateJSON, TextField } from '../../features/template/template';

@Component({
  selector: 'app-template-editor',
  templateUrl: './template-editor.component.html',
  styleUrls: ['./template-editor.component.css']
})
export class TemplateEditorComponent implements OnInit {

  public temp?: TemplateJSON;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: TemplateDialogParams,
    public dialogRef: MatDialogRef<TemplateEditorComponent>
  ) { }

  ngOnInit() {
    this.temp = this.data.template;
  }

  onClose() {
    this.dialogRef.close();
  }

  jsonToString(json: any): string {
    return JSON.stringify(json);
  }

  convertToList(list: (TextField | List | Counter)): List {
    let newList = list as List;
    return newList;
  }

}

export interface TemplateDialogParams {
  template: TemplateJSON
}
