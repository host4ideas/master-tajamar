import { Empleado } from '../models/empleado';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmpleadosService {
  constructor(private _http: HttpClient) {}

  getEmpleados(): Observable<any> {
    const request = environment.API_EMPLEADOS + '/api/empleados';

    return this._http.get(request);
  }

  getEmpleadosSalarios(salario: string): Observable<any> {
    const request =
      environment.API_EMPLEADOS + '/api/Empleados/EmpleadosSalario/' + salario;

    return this._http.get(request);
  }

  getOficios(): Observable<any> {
    const request = environment.API_EMPLEADOS + '/api/empleados/oficios/';
    return this._http.get(request);
  }

  getEmpleadosOficio(oficio: string): Observable<any> {
    const request =
      environment.API_EMPLEADOS + '/api/Empleados/EmpleadosOficio/' + oficio;
    return this._http.get(request);
  }

  getEmpleado(idEmpleado: string): Observable<any> {
    const request = environment.API_EMPLEADOS + '/api/Empleados/' + idEmpleado;
    return this._http.get(request);
  }
}
