import { ColDef } from "../../../table/table-main/table-main.component";

// { name: '', display: '' },

export const DboBaseColDef: ColDef[] = [
  { name: 'createdBy', display: 'Created By' },
  { name: 'createdAt', display: 'Created At' },
  { name: 'modifedBy', display: 'Modifed By' },
  { name: 'modifedAt', display: 'Modifed At' }
];

export const LocationColDef: ColDef[] = [
  { name: 'city', display: 'City' },
  { name: 'stateProv', display: 'State/Province' },
  { name: 'country', display: 'Country' },
  { name: 'address', display: 'Address' },
  { name: 'postalCode', display: 'Postal Code' },
  { name: 'locationName', display: 'Location Name' },
  { name: 'website', display: 'Website' }
];

export const EventColDef: ColDef[] = [
  ...DboBaseColDef,
  ...LocationColDef,
  { name: 'id', display: 'Id' },
  { name: 'name', display: 'Name' },
  { name: 'shortName', display: 'Short Name' },
  { name: 'startDate', display: 'Start Date' },
  { name: 'endData', display: 'End Date' },
  { name: 'year', display: 'Year' },
  { name: 'eventType', display: 'Event Type' },
  { name: 'week', display: 'Week' }
];
