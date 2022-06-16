import { Event, Team, Match, Template, Note, Scout } from "@app/features/api/models/dbo-models";

export interface State {
  events: Event[];
  teams: Team[];
  matches: Match[];
  templates: Template[];
  notes: Note[];
  scouts: Scout[];
  loading: boolean;
  success: boolean;
  error: any;
}

export const initialState: State = {
  events: [],
  teams: [],
  matches: [],
  templates: [],
  notes: [],
  scouts: [],
  loading: false,
  success: true,
  error: null
}
