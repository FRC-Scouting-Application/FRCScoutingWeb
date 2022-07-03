import { ColDef, ColGroupDef } from "ag-grid-community";
import { AppStateService } from "../services/app-state.service";
import { Event, Team } from "@app/features/api/models/dbo-models";

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
    headerName: 'Options',
    children: [
      {
        field: 'Select',
        cellRenderer: 'buttonCellRenderer',
        pinned: 'left',
        cellRendererParams: {
          button: {
            clicked: function (field: any) {
              let event = field.data as Event;
              AppStateService.state.selectedEvent = event;
            },
            name: 'Select Event',
            color: 'basic'
          }
        }
      }
    ]
  },
  {
    headerName: 'Event Info',
    children: [
      { field: 'shortName', pinned: 'left' },
      { field: 'name' },
      { field: 'eventType' },
      { field: 'id', hide: true }
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

export const teamsColDefs: ColDef[] = [
  { field: 'teamNumber', minWidth: 130, headerName: 'Team #', sort: 'asc' },
  { field: 'nickname', minWidth: 200, headerName: 'Name' },
  { field: 'name', minWidth: 200, headerName: 'aka' },
  { field: 'rookieYear', minWidth: 140 },
  {
    field: 'Select',
    cellRenderer: 'buttonCellRenderer',
    pinned: 'left',
    minWidth: 150,
    initialWidth: 150,
    cellRendererParams: {
      button: {
        clicked: function (field: any) {
          let team = field.data as Team;
          AppStateService.state.selectedTeam = team;
        },
        name: 'Select Team',
        color: 'basic'
      }
    }
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

export const templatesColDefs: ColDef[] = [
  { field: 'id' },
  { field: 'version' },
  { field: 'type' },
  { field: 'name' },
  { field: 'defaultTemplate' },
  { field: 'xml', hide: true }
]
