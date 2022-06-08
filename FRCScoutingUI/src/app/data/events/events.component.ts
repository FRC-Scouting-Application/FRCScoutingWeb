import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { EventColDef } from '../../features/api/models/dbo-table-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '../../root-store';
import { TableDef } from '../../table/table-main/table-main.component';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  private events?: Event[];
  public tableDef?: TableDef;

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.store.dispatch(ScoutStoreActions.getEventsRequest());

    this.store.pipe(select(ScoutStoreSelectors.selectEvents)).subscribe({
      next: (events: Event[]) => {
        if (events && events.length > 0) {
          this.events = events;
          this.createTableDef();
        }
      },
      error: (() => {
        console.error("Failed to get Events!");
      })
    });
  }

  createTableDef() {
    let def: TableDef = {
      data: this.events,
      colDef: EventColDef,
      displayCols: ['name', 'year', 'city']
    };

    this.tableDef = def;
  }

}
