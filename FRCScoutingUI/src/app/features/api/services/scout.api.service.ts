import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { filter, map, Observable } from "rxjs";
import { StrictHttpResponse } from "../strict-http-response";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root',
})
class ScoutAPIService extends BaseService {

  constructor(http: HttpClient) {
    super(http)
  }

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

    return this.http.request<any>(req).lift(
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
}

export { ScoutAPIService }
