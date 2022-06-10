import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { ColGroupDef} from 'ag-grid-community';
import { eventColDefs } from '../../results/col-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '../../root-store';
import { Event } from "../../features/api/models/dbo-models";

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  public events: Event[] = [];
  public columnDefs: ColGroupDef[] = eventColDefs;

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.store.dispatch(ScoutStoreActions.getEventsRequest());

    this.store.pipe(select(ScoutStoreSelectors.selectEvents)).subscribe({
      next: (events: Event[]) => {
        if (events && events.length > 0) {
          this.events = events;
        }
      },
      error: () => {
        console.error("Failed to get Events!");
      }
    });
  }

}
