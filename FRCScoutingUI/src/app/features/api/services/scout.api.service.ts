import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { filter, map, Observable } from "rxjs";
import { Event, Match, Note, Scout, Team, Template } from "../models/dbo-models";
import { StrictHttpResponse } from "../strict-http-response";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root',
})
class ScoutAPIService extends BaseService {

  constructor(http: HttpClient) {
    super(http)
  }

  /* Events */
  GetEventsAsyncResponse(): Observable<StrictHttpResponse<Array<Event>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + 'Events',
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Event>>;
      })
    );
  }

  GetEventsAsync(): Observable<Array<Event>> {
    return this.GetEventsAsyncResponse().pipe(
      map(_r => _r.body)
    );
  }

  /* Teams */
  GetTeamsAsyncResponse(): Observable<StrictHttpResponse<Array<Team>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + 'Teams',
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Team>>;
      })
    );
  }

  GetTeamsAsync(): Observable<Array<Team>> {
    return this.GetTeamsAsyncResponse().pipe(
      map(_r => _r.body)
    );
  }

  /* Matches */
  GetMatchesAsyncResponse(eventKey: string): Observable<StrictHttpResponse<Array<Match>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `Matches/${eventKey}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Match>>;
      })
    );
  }

  GetMatchesAsync(eventKey: string): Observable<Array<Match>> {
    return this.GetMatchesAsyncResponse(eventKey).pipe(
      map(_r => _r.body)
    );
  }


  /* Templates */
  GetTemplatesAsyncResponse(): Observable<StrictHttpResponse<Array<Template>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + 'Template',
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Template>>;
      })
    );
  }

  GetTemplatesAsync(): Observable<Array<Template>> {
    return this.GetTemplatesAsyncResponse().pipe(
      map(_r => _r.body)
    );
  }

  /* Notes */
  GetNotesByEventAsyncResponse(eventKey: string): Observable<StrictHttpResponse<Array<Note>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `Notes/Event/${eventKey}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Note>>;
      })
    );
  }

  GetNotesByEventAsync(eventKey: string): Observable<Array<Note>> {
    return this.GetNotesByEventAsyncResponse(eventKey).pipe(
      map(_r => _r.body)
    );
  }

  GetNotesByTeamAsyncResponse(teamKey: string): Observable<StrictHttpResponse<Array<Note>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `Notes/Team/${teamKey}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Note>>;
      })
    );
  }

  GetNotesByTeamAsync(teamKey: string): Observable<Array<Note>> {
    return this.GetNotesByTeamAsyncResponse(teamKey).pipe(
      map(_r => _r.body)
    );
  }

  /* Scouts */
  GetScoutsByEventAsyncResponse(eventKey: string): Observable<StrictHttpResponse<Array<Scout>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `Scouts/Event/${eventKey}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Scout>>;
      })
    );
  }

  GetScoutsByEventAsync(eventKey: string): Observable<Array<Scout>> {
    return this.GetScoutsByEventAsyncResponse(eventKey).pipe(
      map(_r => _r.body)
    );
  }

  GetScoutsByTeamAsyncResponse(teamKey: string): Observable<StrictHttpResponse<Array<Scout>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `Scout/Team/${teamKey}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      }
    );

    return this.http.request<any>(req).pipe(
      // @ts-ignore
      filter(_r => _r instanceof HttpResponse),
      map((_r: HttpResponse<any>) => {
        return _r as StrictHttpResponse<Array<Scout>>;
      })
    );
  }

  GetScoutsByTeamAsync(teamKey: string): Observable<Array<Scout>> {
    return this.GetScoutsByTeamAsyncResponse(teamKey).pipe(
      map(_r => _r.body)
    );
  }

}

export { ScoutAPIService }
