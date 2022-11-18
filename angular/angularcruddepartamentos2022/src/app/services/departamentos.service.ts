import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable()
export class DepartamentosService {
    constructor(private _http: HttpClient){}

    getDepartamentos(): Observable<any>{
        var request = "/api/departamentos";
        var url = environment.urlApiDepartamentos + request;
        return this._http.get(url);
    }

    deleteDepartamento(id:number):void{
        const request = environment.urlApiDepartamentos
        this._http.delete(request)
    }
}