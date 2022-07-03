import { Injectable } from "@angular/core";
import { Event, Team } from "@app/features/api/models/dbo-models";

export interface IAppState {
  selectedEvent?: Event;
  selectedTeam?: Team;
}

export const defaultAppState: IAppState = {
  selectedTeam: {
    city: "Burlington",
    country: "Canada",
    id: "frc2386",
    name: "Bentley Systems/Arcelor Mittal Dofasco/Halton District School Board/Pathways/Hatch/BMP Metals/FeedRite Automation/iCubed&Burlington Central High School",
    nickname: "Trojans",
    postalCode: "L7S 1K4",
    rookieYear: 2008,
    stateProv: "Ontario",
    teamNumber: 2386,
    website: "https://www.bchrobotics.com"
  }
}

@Injectable()
export class AppStateService {

  public static state: IAppState = defaultAppState;

  constructor() {
    this.setDefaultState();
  }

  public setDefaultState(): void {
    AppStateService.state = defaultAppState;
  }

}
