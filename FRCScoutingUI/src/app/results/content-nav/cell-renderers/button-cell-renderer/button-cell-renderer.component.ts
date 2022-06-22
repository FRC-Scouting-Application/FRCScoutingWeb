import { Component, OnDestroy, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-button-cell-renderer',
  templateUrl: './button-cell-renderer.component.html',
  styleUrls: ['./button-cell-renderer.component.css']
})
export class ButtonCellRendererComponent implements ICellRendererAngularComp, OnDestroy {

  constructor() { }
    
  private params: any;
  public button?: IButtonParams;

  agInit(params: any): void {
    this.params = params;
    this.button = this.params.button;
  }

  refresh(params: any): boolean {
    this.agInit(params);
    return true;
  }

  btnClickedHandler() {
    if (this.button)
      this.button.clicked(this.params);
  }

  getColor(): string {
    if (this.button && this.button.color)
      return this.button.color;
    return 'basic';
  }

  ngOnDestroy() {

  }

}

export interface IButtonParams {
  clicked: (field: any) => void;
  name: string;
  color: string;
}
