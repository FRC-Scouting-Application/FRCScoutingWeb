import { HttpResponse } from "@angular/common/http";

export type StrictHttpResponse<T> = HttpResponse<T> & {
  readonly body: T;
}
