import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class CommonService {

  constructor() {}

  rewriteUrl(url: string) {
    window.history.replaceState({}, "", url);
  }
}
