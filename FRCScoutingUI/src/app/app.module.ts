import { HttpClientModule, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, Injectable, NgModule } from '@angular/core';
import { map, Observable } from 'rxjs';

import { AppComponent } from './app.component';
import { ApiModule } from './features/api/api.module';
import { RootStoreModule } from './root-store/root-store.module';
import { AppConfigService } from './services/app-config.service';
import { HeaderComponent } from './main/header/header.component';
import { FooterComponent } from './main/footer/footer.component';

import { AgGridModule } from 'ag-grid-angular';
import { ContentNavComponent } from './results/content-nav/content-nav.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { EventsComponent } from './pages/events/events.component';
import { AppRoutingModule } from './app.routing.module';
import { TeamsComponent } from './pages/teams/teams.component';
import { MatchesComponent } from './pages/matches/matches.component';
import { MaterialModule } from './material.module';

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
    MatchesComponent,
   ],
  imports: [
    HttpClientModule,
    RootStoreModule,
    ApiModule,
    AppRoutingModule,
    AgGridModule,
    MaterialModule,
  ],
  providers: [
    AppConfigService,
    { provide: APP_INITIALIZER, useFactory: initializeApp, deps: [AppConfigService], multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ApiPrefixInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
