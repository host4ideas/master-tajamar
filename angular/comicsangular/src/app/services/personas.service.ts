import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { global } from '../global';
import { environment } from 'src/environments/environment';

@Injectable()
export class PersonasService {
  constructor(private _http: HttpClient) {}

  getPersonas(): Observable<any> {
    // Con variables de entorno
    const request = environment.URL_API_PERSONAS + '/api/personas';

    return this._http.get(request);
  }

  getPersonas2(): Promise<any> {
    // Con global
    const request = global.URL_API_PERSONAS + '/api/personas';

    return new Promise((res, rej) => {
      this._http.get(request).subscribe((response) => {
        res(response);
      });
    });
  }
}
