import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { select, Store } from '@ngrx/store';
import { ColDef } from 'ag-grid-community';
import { TemplateEditorComponent } from '../../dialog/template-editor/template-editor.component';
import { Template } from '../../features/api/models/dbo-models';
import { templatesColDefs } from '../../results/col-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '../../root-store';
import { TemplateXmlService } from '../../services/template-xml.service';

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.css']
})
export class TemplatesComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>,
    public dialog: MatDialog,
    private templateXMLService: TemplateXmlService
  ) { }

  public templates: Template[] = [];
  public columnDefs: ColDef[] = templatesColDefs;

  ngOnInit() {
    this.getTemplates();

    this.templateXMLService.loadTemplate();
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
    const dialogRef = this.dialog.open(TemplateEditorComponent, {
      width: "90vw",
      height: "90vh"
    })
  }

}
