import { HttpClient, HttpHeaders } from "@angular/common/http";
import { XmlParser } from "@angular/compiler";
import { Injectable } from "@angular/core";

@Injectable()
export class TemplateXmlService {

  constructor(
    private http: HttpClient
  ) { }

  loadTemplate() {
    this.http.get(template,
      {
        headers: new HttpHeaders()
          .set('Content-Type', 'text/xml')
          .append('Access-Control-Allow-Methods', 'GET')
          .append('Access-Control-Allow-Origin', '*')
          .append('Access-Control-Allow-Headers', "Access-Control-Allow-Headers, Access-Control-Allow-Origin, Access-Control-Request-Method"),
        responseType: 'text'
      }).subscribe((data) => {
        this.parseXML(data);
      });
  }

  parseXML(data: string) {
    console.log(data)
  }

}

const template = 'assets/templateExample.xml';

const options = {
  ignoreAttributes: false,
  attributeNamePrefix: "@_",
  allowBooleanAttributes: true
};

export interface TemplateXML {
  sections: Document[]
}

export interface TemplateSection {

}
