import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { select, Store } from '@ngrx/store';
import { ColDef } from 'ag-grid-community';
import { TemplateEditorComponent } from '@app/dialog/template-editor/template-editor.component';
import { Template } from '@app/features/api/models/dbo-models';
import { Counter, List, TemplateHelper, TemplateJSON, TextField } from '@app/features/template/template';
import { templatesColDefs } from '@app/results/col-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '@app/root-store';

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.css']
})
export class TemplatesComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>,
    public dialog: MatDialog,
    private templateHelper: TemplateHelper
  ) { }

  public todo = ['Get to work', 'Pick up groceries', 'Go home', 'Fall asleep'];

  public templates: Template[] = [];
  public columnDefs: ColDef[] = templatesColDefs;

  public temp?: TemplateJSON;

  ngOnInit() {
    this.getTemplates();

    this.templateHelper.loadPitTemplateExample().then((data: TemplateJSON) => {
      console.log(data);
      this.temp = data;
    })
  }

  jsonToString(json: any): string {
    return JSON.stringify(json);
  }

  convertToList(list: (TextField | List | Counter)): List {
    let newList = list as List;
    return newList;
  }

  getTemplates() {
    this.store.dispatch(ScoutStoreActions.getTemplatesRequest());

    this.store.pipe(select(ScoutStoreSelectors.selectTemplates)).subscribe({
      next: (templates: Template[]) => {
        if (templates && templates.length > 0) {
          this.templates = templates;
        }
      },
      error: () => {
        console.error("Failed to get Templates!");
      }
    });
  }

  createNewTemplate() {
    this.dialog.open(TemplateEditorComponent, {
      width: "90vw",
      height: "90vh"
    })
  }

  openExamplePit() {
    this.templateHelper.loadPitTemplateExample().then((data: TemplateJSON) => {
      console.log(data);

      this.dialog.open(TemplateEditorComponent, {
        width: "90vw",
        height: "90vh",
        data: { template: data }
      })
    })  
  }

}
