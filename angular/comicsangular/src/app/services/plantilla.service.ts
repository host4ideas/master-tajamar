import { EmpleadoPlantilla } from '../models/empleadoPlantilla.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class PlantillaService {
  constructor(private _http: HttpClient) {}

  getFunciones(): Observable<any> {
    const request = environment.API_PLANTILLA + '/api/Plantilla/Funciones';
    return this._http.get(request);
  }

  getPlantillaFunciones(funcion: string): Observable<any> {
    const request =
      environment.API_PLANTILLA +
      '/api/Plantilla/PlantillaFunciones?' +
      funcion;

    return this._http.get(request);
  }
}
