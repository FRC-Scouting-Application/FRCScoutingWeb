import { HttpClientModule, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, Injectable, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { map, Observable } from 'rxjs';

import { AppComponent } from './app.component';
import { ApiModule } from './features/api/api.module';
import { RootStoreModule } from './root-store/root-store.module';
import { AppConfigService } from './services/app-config.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './main/header/header.component';
import { FooterComponent } from './main/footer/footer.component';

import { MatTableModule } from '@angular/material/table';
import { AgGridModule } from 'ag-grid-angular';
import { ContentNavComponent } from './results/content-nav/content-nav.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { EventsComponent } from './pages/events/events.component';
import { AppRoutingModule } from './app.routing.module';
import { TeamsComponent } from './pages/teams/teams.component';
import { MatchesComponent } from './pages/matches/matches.component';

export function initializeApp(appConfigService: AppConfigService) {
  return (): Promise<any> => {
    return appConfigService.load();
  }
}

@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {
  constructor(private readonly appConfig: AppConfigService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(map((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        event = event.clone({ body: event.body });
      }
      return event;
    }));
  }
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ContentNavComponent,

    /* Pages */
    LandingPageComponent,
    EventsComponent,
    TeamsComponent,
    MatchesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RootStoreModule,
    ApiModule,
    BrowserAnimationsModule,
    MatTableModule,
    AppRoutingModule,
    AgGridModule
  ],
  providers: [
    AppConfigService,
    { provide: APP_INITIALIZER, useFactory: initializeApp, deps: [AppConfigService], multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ApiPrefixInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
