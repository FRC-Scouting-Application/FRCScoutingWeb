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
    /*this.store.pipe(select(ScoutStoreSelectors.selectEvents)).subscribe({
      next: (res: any) => {
        console.log(res);
      },
      error: (() => {
        console.error("Failed to get Events!");
      })
    })*/
  }

  onClick() {
    this.store.dispatch(ScoutStoreActions.getEventsRequest());
  }

}
