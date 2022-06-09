import { ColDef, ColGroupDef } from "ag-grid-community";

export const idColDef: ColDef = {
  field: 'id'
}

export const baseColDefs: ColDef[] = [
  { field: 'createdBy' },
  { field: 'createdAt' },
  { field: 'modifiedBy' },
  { field: 'modifedAt' }
]

export const scoutBaseColDefs: ColDef[] = [
  { field: 'teamKey' },
  { field: 'eventKey' }
]

export const locationColDefs: ColDef[] = [
  { field: 'stateProv' },
  { field: 'country' },
  { field: 'city' }, 
  { field: 'address' },
  { field: 'postalCode' },
  { field: 'locationName' },
  { field: 'website' }
]

export const eventColDefs: ColGroupDef[] = [
  {
    headerName: 'Event Info',
    children: [
      { field: 'shortName' },
      { field: 'name' },
      { field: 'eventType' },
    ]
  },
  {
    headerName: 'Event Time',
    children: [
      { field: 'year' },
      { field: 'week' },
      { field: 'startDate' },
      { field: 'endDate' }
    ]
  },
  {
    headerName: 'Location',
    children: [
      ...locationColDefs
    ]
  }
]

export const teamsColDefs: ColGroupDef[] = [
  {
    headerName: 'Team Info',
    children: [
      { field: 'teamNumber' },
      { field: 'nickname', headerName: 'Team Name' },
      { field: 'name', headerName: 'aka' },
      { field: 'rookieYear' },
    ]
  },
  {
    headerName: 'Location',
    children: [
      ...locationColDefs
    ]
  }
]

export const matchesColDefs: ColGroupDef[] = [
  {
    headerName: '',
    children: [
      { field: 'matchNumber' },
      { field: 'eventKey' }
    ]
  },
  {
    headerName: 'Score',
    children: [
      { field: 'blueScore' },
      { field: 'redScore' },
      { field: 'winningAlliance' }
    ]
  },
  {
    headerName: 'Time',
    children: [
      { field: 'time' },
      { field: 'actualTime' },
      { field: 'predictedTime' }
    ]
  },
  {
    headerName: 'Teams',
    children: [
      { field: 'red1' },
      { field: 'red2' },
      { field: 'red3' },
      { field: 'blue1' },
      { field: 'blue2' },
      { field: 'blue3' },
    ]
  }
]
