import { HttpClient, HttpParameterCodec, HttpParams } from "@angular/common/http";
import { AppConfigService } from "../../../services/app-config.service";

class ParameterCodec implements HttpParameterCodec {
  encodeKey(key: string): string {
    return encodeURIComponent(key);
  }

  encodeValue(value: string): string {
    return encodeURIComponent(value);
  }

  decodeKey(key: string): string {
    return decodeURIComponent(key);
  }

  decodeValue(value: string): string {
    return decodeURIComponent(value);
  }
}
const PARAMETER_CODEC = new ParameterCodec();

export class BaseService {

  constructor(
    protected http: HttpClient
  ) { }

  private _rootUrl: string = "";

  get rootUrl(): string {
    if (this._rootUrl !== "")
      return this._rootUrl;

    return AppConfigService.settings.api.SCOUT_API_URL;
  }

  set rootUrl(rootUrl: string) {
    this._rootUrl = rootUrl;
  }

  protected newParams(): HttpParams {
    return new HttpParams({
      encoder: PARAMETER_CODEC
    });
  }
}
