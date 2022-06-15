
export interface DboBase {
  createdBy?: number,
  createdAt?: string,
  modifedBy?: number,
  modifedAt?: string
}

export interface ScoutBase extends DboBase {
  id: number,
  teamKey: string,
  eventKey: string,
  scoutName: string
}

export interface Location {
  city?: string,
  stateProv?: string,
  country?: string,
  address?: string,
  postalCode?: string,
  locationName?: string,
  website?: string
}

export interface Event extends DboBase, Location {
  id: string,
  name: string,
  shortName?: string,
  startDate: string,
  endDate: string,
  year: number,
  eventType: string,
  week?: number
}

export interface Match extends DboBase {
  id: string,
  matchNumber: string,
  red1: string,
  red2: string,
  red3: string,
  blue1: string,
  blue2: string,
  blue3: string,
  eventKey: string,
  redScore?: number,
  blueScore?: number,
  winningAlliance?: string,
  time?: string,
  actualTime?: string,
  predictedTime?: string
}

export interface Team extends DboBase, Location {
  id: string,
  teamNumber: number,
  nickname?: string,
  name: string,
  rookieYear?: number
}

export interface Note extends ScoutBase {
  text: string
};

export interface Scout extends ScoutBase {
  templateId: number,
  templateVersion: number,
  matchKey: string,
  xml: string
}

export interface Template extends DboBase {
  id: number,
  version: number,
  type: string,
  name: string,
  defaultTemplate?: boolean,
  xml: string
}
