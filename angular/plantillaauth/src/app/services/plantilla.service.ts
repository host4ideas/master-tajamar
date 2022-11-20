// Angular
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// Environment variables
import { environment } from 'src/environments/environment';
// Model
import { Plantilla } from '../models/plantilla';

// Para hacerlo global si necesidad de importarlo en app module
@Injectable({
  providedIn: 'root',
})
export class PlantillaService {
  constructor(private _http: HttpClient) {}

  /**
   * Petición get para recoger todos los elementos
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  getEmpleados(headers: HttpHeaders): Observable<any> {
    const request = environment.API_PLANTILLA + '/api/Empleados/';
    return this._http.get(request, { headers: headers });
  }

  /**
   * Petición get para recoger solo un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  findEmpleado(id: string, headers: HttpHeaders): Observable<any> {
    const request = environment.API_PLANTILLA + `/api/Empleados/${id}`;
    return this._http.get(request, { headers: headers });
  }
}
