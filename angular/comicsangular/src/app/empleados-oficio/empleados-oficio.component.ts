import {
  Component,
  OnInit,
  ɵViewRef,
  ElementRef,
  ViewChild,
} from '@angular/core';
import { Empleado } from '../models/empleado';
import { EmpleadosService } from '../services/empleados.service';

@Component({
  selector: 'app-empleados-oficio',
  templateUrl: './empleados-oficio.component.html',
  styleUrls: ['./empleados-oficio.component.css'],
})
export class EmpleadosOficioComponent implements OnInit {
  @ViewChild('selectOficio') selectOficio!: ElementRef;
  public oficios!: string[];
  public empleados!: Empleado[];

  constructor(private empleadosService: EmpleadosService) {}

  getEmpleadosOficio(): void {
    const oficio = this.selectOficio.nativeElement.value;

    this.empleadosService
      .getEmpleadosOficio(oficio)
      .subscribe((response) => (this.empleados = response));
  }

  ngOnInit(): void {
    this.empleadosService
      .getOficios()
      .subscribe((response) => (this.oficios = response));
  }
}
