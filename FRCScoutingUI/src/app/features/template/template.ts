import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class TemplateHelper {

  constructor(
    private http: HttpClient
  ) { }

  loadFromUrl(url: string): Promise<TemplateJSON> {
    return new Promise<TemplateJSON>((resolve, reject) => {
      this.http.get<TemplateJSON>(url).subscribe((data: TemplateJSON) => {
        resolve(data);
      }, (error: any) => {
        console.error(error);
        reject();
      })
    });
  }

  loadPitTemplateExample(): Promise<TemplateJSON> {
    return this.loadFromUrl('assets/pitScoutExample.json');
  }

}

export interface TemplateJSON {
  templateName?: string
  templateType?: string
  forYear?: number
  sections?: TemplateSection[]
}

export interface TemplateSection {
  header?: string
  fields?: (TextField | List | Counter)[]
}

export interface Field {
  type: string
  label: string
}

export interface TextField extends Field {
  value?: string
}

export interface List extends Field {
  items: ListItem[];
}

export interface ListItem {
  label: string
  other?: boolean
  selected?: boolean
}

export interface Counter extends Field {
  min?: number
  max?: number
  value?: number
}
