import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hospital } from '../models/Hospital';

@Injectable({
  providedIn: 'root',
})
export class HospitalesService {
  constructor(private _http: HttpClient) {}

  /**
   * Petición get para recoger todos los elementos
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  getHospitales(): Observable<any> {
    const request = environment.API_HOSPITALES + '/webresources/hospitales';
    return this._http.get(request);
  }

  /**
   * Petición get para recoger solo un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  findHospital(id: string): Observable<any> {
    const request =
      environment.API_HOSPITALES + '/webresources/hospitales/' + id;
    return this._http.get(request);
  }

  /**
   * Petición delete para eliminar un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  deleteHospital(id: string): Observable<any> {
    const request =
      environment.API_HOSPITALES + '/webresources/hospitales/' + id;
    return this._http.delete(request);
  }

  /**
   * Petición put para actualizar un elemento
   * @param {Hospital} hospital Nuevo hospital para actualizar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  updateHospital(hospital: Hospital): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request = environment.API_HOSPITALES + '/webresources/hospitales/put';
    return this._http.put(request, JSON.stringify(hospital), {
      headers: header,
    });
  }

  /**
   * Petición post para insertar un elemento
   * @param {Hospital} hospital Nuevo hospital para insertar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  createHospital(hospital: Hospital): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request =
      environment.API_HOSPITALES + '/webresources/hospitales/post';
    return this._http.post(request, JSON.stringify(hospital), {
      headers: header,
    });
  }
}
