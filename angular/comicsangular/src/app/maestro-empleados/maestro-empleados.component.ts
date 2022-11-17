import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from '../services/empleados.service';
import { Empleado } from '../models/empleado';

@Component({
  selector: 'app-maestro-empleados',
  templateUrl: './maestro-empleados.component.html',
  styleUrls: ['./maestro-empleados.component.css'],
})
export class MaestroEmpleadosComponent implements OnInit {
  public empleados!: Empleado[];

  constructor(private _empleadosService: EmpleadosService) {}

  ngOnInit(): void {
    this._empleadosService
      .getEmpleados()
      .subscribe((response) => (this.empleados = response));
  }
}
