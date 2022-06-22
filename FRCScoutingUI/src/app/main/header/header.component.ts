import { Component, OnInit } from '@angular/core';
import { AppStateService } from '../../services/app-state.service';
import { Event } from "@app/features/api/models/dbo-models";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
  ) { }

  ngOnInit(): void {
  }

  getSelectedEvent(): string {
    let event = AppStateService.state.selectedEvent as Event;

    if (event && event.name)
      return event.name;

    return 'None';
  }

  resetSelectedEvent(): void {
    AppStateService.state.selectedEvent = undefined;
  }

}
