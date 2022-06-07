
export interface State {
  events: Event[];
  loading: boolean;
  success: boolean;
  error: any;
}

export const initialState: State = {
  events: [],
  loading: false,
  success: true,
  error: null
}
