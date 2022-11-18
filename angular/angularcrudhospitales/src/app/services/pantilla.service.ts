import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Plantilla } from '../models/plantilla';

@Injectable({
  providedIn: 'root',
})
export class PlantillaService {
  constructor(private _http: HttpClient) {}

  getPlantilla(): Observable<any> {
    const request = environment.API_PLANTILLA + '/api/plantilla';
    return this._http.get(request);
  }
}
