import { Injector, Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

import * as $ from 'jquery';

@Injectable()
export abstract class AppComponentBase {

    isSaving = false;
    date: Date = new Date();


    baseUrl: string;
    sanitizer: DomSanitizer;
    httpClient: HttpClient;

  
  constructor(injector: Injector) {
      this.baseUrl = injector.get('BASE_URL');
      this.httpClient = injector.get(HttpClient);
      this.sanitizer = injector.get(DomSanitizer);
    }

    
    sanitize(url: string) {
        return this.sanitizer.bypassSecurityTrustUrl(url);
    }

    processSuccessResponse(response) {
        if (response && response["result"]) {
            return response["result"]["data"];
        } else {
            return null;
        }
    }

    processErrorResponse(response) {
        if (response && response["error"]["errors"]) {
            return response["error"]["errors"];
        } else {
            return null;
        }
    }

}
