import { Event, Team, Match, Template } from "../../features/api/models/dbo-models";

export interface State {
  events: Event[];
  teams: Team[];
  matches: Match[];
  templates: Template[];
  loading: boolean;
  success: boolean;
  error: any;
}

export const initialState: State = {
  events: [],
  teams: [],
  matches: [],
  templates: [],
  loading: false,
  success: true,
  error: null
}
