import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EventsComponent } from "./pages/events/events.component";
import { LandingPageComponent } from "./pages/landing-page/landing-page.component";
import { MatchesComponent } from "./pages/matches/matches.component";
import { TeamsComponent } from "./pages/teams/teams.component";
import { TemplatesComponent } from "./pages/templates/templates.component";

const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'events', component: EventsComponent },
  { path: 'teams', component: TeamsComponent },
  { path: 'matches', component: MatchesComponent },
  { path: 'templates', component: TemplatesComponent }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }