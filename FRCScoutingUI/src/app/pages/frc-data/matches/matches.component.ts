import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { ColGroupDef } from 'ag-grid-community';
import { Match } from '@app/features/api/models/dbo-models';
import { matchesColDefs } from '@app/results/col-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '@app/root-store';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  public matches: Match[] = [];
  public columnDefs: ColGroupDef[] = matchesColDefs;

  ngOnInit() {
  }

  getMatches() {
    this.store.dispatch(ScoutStoreActions.getMatchesRequest({ payload: "frc2386" }));

    this.store.pipe(select(ScoutStoreSelectors.selectMatches)).subscribe({
      next: (matches: Match[]) => {
        if (matches && matches.length > 0) {
          this.matches = matches;
        }
      },
      error: () => {
        console.error("Failed to get Matches!")
      }
    })
  }
}
