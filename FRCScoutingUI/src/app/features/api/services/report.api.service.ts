import { HttpClient, HttpHeaders, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { filter, map, Observable } from "rxjs";
import { DataReport } from "../models/report-models";
import { StrictHttpResponse } from "../strict-http-response";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
class ReportAPIService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  GetDataReportAsyncResponse(): Observable<StrictHttpResponse<DataReport>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + 'Reports/Data',
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
        return _r as StrictHttpResponse<DataReport>;
      })
    );
  }

  GetDataReportAsync(): Observable<DataReport> {
    return this.GetDataReportAsyncResponse().pipe(
      map(_r => _r.body)
    );
  }

}

export { ReportAPIService }
