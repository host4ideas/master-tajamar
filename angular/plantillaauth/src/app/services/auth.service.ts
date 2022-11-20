// Angular
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// Environment variables
import { environment } from 'src/environments/environment';

/**
 * Servicio agnostico de otros componentes/servicios. Permite validar cualquier peticion a la API con un header de autenticacion.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private _http: HttpClient) {}

  /**
   * Metodo privado. Interactua con getAuthorizationToken para guardar en el localStorage el nuevo token.
   * @returns El valor del nuevo token.
   */
  setToken(): Promise<string> {
    return new Promise((res, rej) => {
      this.getAuthorizationToken().subscribe((response) => {
        const tokenString: string = response.response;
        localStorage.setItem('token', tokenString);
        res(response.response);
      });
    });
  }

  /**
   * Metodo privado. Lee de localStorage el token, sino lo encuentra, lo genera a traves de setToken
   * @returns El valor del nuevo token.
   */
  async getToken(): Promise<string | null> {
    let token = localStorage.getItem('token');

    if (token === null) {
      token = await this.setToken();
    }

    return token;
  }

  /**
   * Recupera un token de autenticacion del servidor.
   * @returns Devuelve la peticion post para recuperar el token del servidor.
   */
  getAuthorizationToken(): Observable<any> {
    const request = environment.API_PLANTILLA + '/Auth/Login';

    const credentials = {
      userName: 'rey',
      password: '7839',
    };

    return this._http.post(request, credentials);
  }

  /**
   * Envuelve la peticion proveyendola de un header de autenticacion.
   * @param callback Funcion de la peticion del usuario.
   * @param args Argumentos para la funcion pasada por parametro.
   * @returns Devuelve una copia de la funcion de la peticion original del usuario con el header de autenticacion.
   */
  async authInterceptor(callback: Function, ...args: any[]): Promise<Function> {
    const token = await this.getToken();

    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    console.log(headers);

    const _callback = callback;

    callback = () => {
      return _callback(...args, headers);
    };

    return callback;
  }
}
