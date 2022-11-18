import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Empleado } from '../models/empleado';
import { EmpleadosService } from '../services/empleados.service';

@Component({
  selector: 'app-detalles-empleado',
  templateUrl: './detalles-empleado.component.html',
  styleUrls: ['./detalles-empleado.component.css'],
})
export class DetallesEmpleadoComponent implements OnInit {
  public empleado!: Empleado;
  constructor(
    private route: ActivatedRoute,
    private _empleadosService: EmpleadosService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const idEmpleado = params.get('idEmpleado');

      console.log(idEmpleado);

      if (idEmpleado) {
        this._empleadosService
          .getEmpleado(idEmpleado)
          .subscribe((response) => (this.empleado = response));
      }
    });
  }
}
 