import { Component, OnInit } from '@angular/core';
import { DepartamentosService } from 'src/app/services/departamentos.service';
import { Departamento } from 'src/app/models/departamento';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})
export class DepartamentosComponent implements OnInit {
  public departamentos!: Array<Departamento>;

  constructor(private _service: DepartamentosService, private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._service.getDepartamentos().subscribe(response => {
      this.departamentos = response;
    });

    this._activatedRoute.params.subscribe((params) => {
      if(params["id"]){
        const id = parseInt(params["id"]);
        this._service.deleteDepartamento(id);
      }
    })
  }
}
