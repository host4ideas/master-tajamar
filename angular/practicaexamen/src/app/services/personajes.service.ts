// Angular
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// Environment variables
import { environment } from 'src/environments/environment.prod';
// Model
import { Personaje } from '../models/personaje';

// Para hacerlo global si necesidad de importarlo en app module
@Injectable({
  providedIn: 'root',
})
export class PersonajesService {
  constructor(private _http: HttpClient) {}

  /**
   * Petición get para recoger todos los elementos
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  getPersonajes(): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Personajes';
    return this._http.get(request);
  }

  /**
   * Petición get para recoger solo un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  findPersonaje(id: string): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Personajes/' + id;
    return this._http.get(request);
  }

  /**
   * Petición delete para eliminar un elemento
   * @param {string} id ID del elemento para la petición
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  deletePersonaje(id: string): Observable<any> {
    const request = environment.API_SERIES_PERSONAJES + '/api/Personajes/' + id;
    return this._http.delete(request);
  }

  /**
   * Petición put para actualizar un elemento
   * @param {Personaje} personaje Serie para actualizar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  updatePersonaje(personaje: Personaje): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request = environment.API_SERIES_PERSONAJES + '/api/Personajes/';
    return this._http.put(request, JSON.stringify(personaje), {
      headers: header,
    });
  }

  /**
   * Petición post para insertar un elemento
   * @param {Personaje} personaje Nuevo personaje para insertar
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  createPersonaje(personaje: Personaje): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request = environment.API_SERIES_PERSONAJES + '/api/Personajes/';
    return this._http.post(request, JSON.stringify(personaje), {
      headers: header,
    });
  }

  /**
   * Petición post para cambiar un personaje de serie
   * @param {string} idpersonaje ID del personaje al cual cambiar de serie
   * @param {string} idserie ID de una serie para cambiar el personaje
   * @returns {Observable<any>} Observable al cual nos suscribiremos en el componente
   */
  updatePersonajeSerie(idpersonaje: string, idserie: string): Observable<any> {
    const header = new HttpHeaders().set('Content-Type', 'application/json');
    const request =
      environment.API_SERIES_PERSONAJES +
      `/api/Personajes/${idpersonaje}/${idserie}`;

    return this._http.put(request, null);
  }
}
