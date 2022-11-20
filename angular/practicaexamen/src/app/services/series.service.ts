// Angular
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// Environment variables
import { environment } from 'src/environments/environment.prod';
// Model
import { Serie } from '../models/serie';

// Para hacerlo global si necesidad de importarlo en app module
@Injectable({
  providedIn: 'root',
})
export class SeriesService {
  constructor(private _http: HttpClient) {}

  /**
   * Petición get para recoger todos los elementos
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  getSeries(): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Series';
    return this._http.get(request);
  }

  /**
   * Petición get para recoger solo un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  findSerie(id: string): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Series/' + id;
    return this._http.get(request);
  }

  /**
   * Petición delete para eliminar un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  deleteSerie(id: string): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Series' + id;
    return this._http.delete(request);
  }

  /**
   * Petición put para actualizar un elemento
   * @param {Serie} serie Serie para actualizar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  updateSerie(serie: Serie): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request = environment.API_SERIES_PERSONAJES + '/api/Series';
    return this._http.put(request, JSON.stringify(serie), {
      headers: header,
    });
  }

  /**
   * Petición post para insertar un elemento
   * @param {Serie} serie Nueva serie para insertar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  createSerie(serie: Serie): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request = environment.API_SERIES_PERSONAJES + '/api/Series';
    return this._http.post(request, JSON.stringify(serie), {
      headers: header,
    });
  }

  /**
   * Petición post para insertar un elemento
   * @param {string} id ID de la serie de la cual seleccionar recoger los personajes
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  getPersonajesSerie(id: string): Observable<any> {
    const request =
      environment.API_SERIES_PERSONAJES + '/api/Series/PersonajesSerie/' + id;
    return this._http.get(request);
  }
}
