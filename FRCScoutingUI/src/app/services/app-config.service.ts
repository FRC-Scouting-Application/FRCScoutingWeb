import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class AppConfigService {

  public static settings: IAppConfig;

  constructor(
    private http: HttpClient
  ) { }

  public async load(): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      this.http.get<IAppConfig>(jsonFile).subscribe((data: IAppConfig) => {
        AppConfigService.settings = { ...data };
        resolve();
      }, (error: any) => {
        console.error(error);
        reject();
      });
    });
  }

}

const jsonFile = 'assets/appConfig.json';

export interface IAppConfig {
  api: {
    SCOUT_API_URL: string
  }
}
