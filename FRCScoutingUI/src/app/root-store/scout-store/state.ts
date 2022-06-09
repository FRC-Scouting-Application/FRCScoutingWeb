import { Event, Team, Match } from "../../features/api/models/dbo-models";

export interface State {
  events: Event[];
  teams: Team[];
  matches: Match[];
  loading: boolean;
  success: boolean;
  error: any;
}

export const initialState: State = {
  events: [],
  teams: [],
  matches: [],
  loading: false,
  success: true,
  error: null
}
