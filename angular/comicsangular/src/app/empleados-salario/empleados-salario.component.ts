import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { EmpleadosService } from '../services/empleados.service';
import { Empleado } from '../models/empleado';

@Component({
  selector: 'app-empleados-salario',
  templateUrl: './empleados-salario.component.html',
  styleUrls: ['./empleados-salario.component.css'],
})
export class EmpleadosSalarioComponent implements OnInit {
  public empleados!: Empleado[];
  @ViewChild('cajaSalario') cajaSalario!: ElementRef;

  constructor(private _empleadosService: EmpleadosService) {}

  mostrarEmpleadosSalario(): void {
    let salario = this.cajaSalario.nativeElement.value;
    this._empleadosService.getEmpleadosSalarios(salario).subscribe((res) => {
      this.empleados = res;
    });
  }

  ngOnInit(): void {
    this._empleadosService
      .getEmpleados()
      .subscribe((res) => (this.empleados = res));
  }
}
