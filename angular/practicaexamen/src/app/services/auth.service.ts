// Angular
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Router } from '@angular/router';
// Environment variables
import { environment } from 'src/environments/environment';
// Models
import { Plantilla } from '../models/plantilla';

/**
 * Objecto usuario utilizado solo para guardar el usuario en localStorage
 */
interface LoggedUser {
  userName: string;
}

/**
 * Servicio agnostico de otros componentes/servicios. Permite validar cualquier peticion a la API con un header de autenticacion.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private _http: HttpClient, private router: Router) {}

  /**
   * @param user Objecto usuario
   */
  setUser(user: Plantilla) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  /**
   * Cerrar sesion
   */
  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  /**
   * Login
   * @param {LoggedUser} credentials Objecto con las credenciales
   * @returns
   */
  login(credentials: LoggedUser) {
    this.checkUser().then((user) => {
      if (user) {
        this.router.navigate(['/subordinados']);
      } else {
        this.getAuthorizationToken(credentials).subscribe((response) => {
          if (response) {
            const tokenString: string = response.response;
            localStorage.setItem('user', JSON.stringify(credentials.userName));
            this.setAuthorizationToken(tokenString);
            this.router.navigate(['/subordinados']);
          }
        });
      }
    });
  }

  /**
   * Metodo privado. Interactua con getAuthorizationToken para guardar en el localStorage el nuevo token.
   * @returns El valor del nuevo token.
   */
  getLocalToken(): Promise<string> {
    return new Promise((res, rej) => {
      this.checkUser().then((user) => {
        if (!user) {
          this.router.navigate(['/login']);
        } else {
          res(localStorage.getItem('token')!);
        }
      });
    });
  }

  /**
   * Recupera un token de autenticacion del servidor.
   * @returns Devuelve la peticion post para recuperar el token del servidor.
   */
  getAuthorizationToken(credentials: Object): Observable<any> {
    const request = environment.API_PLANTILLA + '/Auth/Login';
    return this._http.post(request, credentials);
  }

  /**
   * Recupera un token de autenticacion del servidor.
   * @returns Devuelve la peticion post para recuperar el token del servidor.
   */
  setAuthorizationToken(tokenString: string): void {
    localStorage.setItem('token', tokenString);
  }

  /**
   * Metodo privado. Lee de localStorage el user, sino lo encuentra, redirige a login.
   * @returns El valor del nuevo token.
   */
  async checkUser(): Promise<Plantilla | null> {
    const user = localStorage.getItem('user');

    if (user === null) {
      return null;
    }

    const parsedUser = JSON.parse(user);

    return parsedUser;
  }

  /**
   * Envuelve la peticion proveyendola de un header de autenticacion.
   * @param callback Funcion de la peticion del usuario.
   * @param args Argumentos para la funcion pasada por parametro.
   * @returns Devuelve una copia de la funcion de la peticion original del usuario con el header de autenticacion.
   */
  async authInterceptor(callback: Function, ...args: any[]): Promise<Function> {
    const token = await this.getLocalToken();

    const headers = new HttpHeaders().set('Authorization', 'bearer ' + token);

    const _callback = callback;

    callback = () => {
      return _callback(...args, headers);
    };

    return callback;
  }
}
