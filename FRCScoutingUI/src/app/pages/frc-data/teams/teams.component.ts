import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { ColGroupDef } from 'ag-grid-community';
import { Team } from '@app/features/api/models/dbo-models';
import { teamsColDefs } from '@app/results/col-defs';
import { RootStoreState, ScoutStoreActions, ScoutStoreSelectors } from '@app/root-store';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  constructor(
    private store: Store<RootStoreState.State>
  ) { }

  public teams: Team[] = [];
  public columnDefs: ColGroupDef[] = teamsColDefs;

  ngOnInit() {
    this.getTeams();
  }

  getTeams() {
    this.store.dispatch(ScoutStoreActions.getTeamsRequest());

    this.store.pipe(select(ScoutStoreSelectors.selectTeams)).subscribe({
      next: (teams: Team[]) => {
        if (teams && teams.length > 0) {
          this.teams = teams;
        }
      },
      error: () => {
        console.error("Failed to get Teams!")
      }
    })
  }

}
