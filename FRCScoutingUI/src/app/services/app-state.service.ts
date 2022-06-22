import { Injectable } from "@angular/core";
import { Event } from "@app/features/api/models/dbo-models";

export interface IAppState {
  selectedEvent?: Event;
}

export const defaultAppState: IAppState = {
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
