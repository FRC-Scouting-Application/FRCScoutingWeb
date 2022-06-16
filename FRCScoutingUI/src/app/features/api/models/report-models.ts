
export interface DataReport {
  events?: FRCDataCounts
  matches?: FRCDataCounts
  teams?: FRCDataCounts

  templates?: CountPerType

  scouts?: ScoutDataCounts
  notes?: ScoutDataCounts
}

export interface FRCDataCounts extends TotalDataCounts {
  custom?: number
  test?: number
}

export interface ScoutDataCounts extends CountPerType {
  byTeam?: IDictonary<string>
  byEvent?: IDictonary<string>
}

export interface CountPerType extends TotalDataCounts {
  byType?: IDictonary<number>
}

export interface TotalDataCounts {
  total?: number
}

export interface IDictonary<T> {
  [index: string]: T
}
