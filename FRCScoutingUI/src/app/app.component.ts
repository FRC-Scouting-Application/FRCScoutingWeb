import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from './root-store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  ngOnInit() {
    this.getAllData();
  }

  getAllData() {
    this.store.dispatch(ScoutStoreActions.getEventsRequest());
    this.store.dispatch(ScoutStoreActions.getTeamsRequest());
    this.store.dispatch(ScoutStoreActions.getMatchesRequest());
    this.store.dispatch(ScoutStoreActions.getTemplatesRequest());
  }

}
