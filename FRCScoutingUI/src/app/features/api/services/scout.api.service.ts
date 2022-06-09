import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { filter, map, Observable } from "rxjs";
import { Event, Match, Team } from "../models/dbo-models";
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
  GetMatchesAsyncResponse(): Observable<StrictHttpResponse<Array<Match>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + 'Matches',
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

  GetMatchesAsync(): Observable<Array<Match>> {
    return this.GetMatchesAsyncResponse().pipe(
      map(_r => _r.body)
    );
  }
}

export { ScoutAPIService }
