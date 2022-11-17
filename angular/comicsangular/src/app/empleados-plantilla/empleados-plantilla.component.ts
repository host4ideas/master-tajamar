import {
  Component,
  OnInit,
  ɵViewRef,
  ElementRef,
  ViewChild,
} from '@angular/core';
import { PlantillaService } from '../services/plantilla.service';
import { EmpleadoPlantilla } from '../models/empleadoPlantilla.model';

@Component({
  selector: 'app-empleados-plantilla',
  templateUrl: './empleados-plantilla.component.html',
  styleUrls: ['./empleados-plantilla.component.css'],
})
export class EmpleadosPlantillaComponent implements OnInit {
  @ViewChild('selectFuncion') selectFuncion!: ElementRef;
  public funciones!: string[];
  public plantilla!: EmpleadoPlantilla[];
  public selectedFunciones!: string[];

  constructor(private _plantillaService: PlantillaService) {}

  getPlantillaFunciones(): void {
    let funciones = 'funcion=';

    for (let i = 0; i < this.selectedFunciones.length; i++) {
      if (i === this.selectedFunciones.length - 1) {
        funciones += `${this.selectedFunciones[i]}`;
      } else {
        funciones += `${this.selectedFunciones[i]}&funcion=`;
      }
    }

    this._plantillaService
      .getPlantillaFunciones(funciones)
      .subscribe((response) => {
        this.plantilla = response;
      });
  }

  mostrarPlantilla(): void {
    let funciones = '&funcion=';

    for (const option of this.selectFuncion.nativeElement.options) {
      if (option.selected) {
        console.log(option.value);

        funciones += option.value + '&funcion=';
      }
    }

    this._plantillaService
      .getPlantillaFunciones(funciones)
      .subscribe((response) => {
        this.plantilla = response;
      });
  }
  
  reset(): void {
    if (this.selectedFunciones) {
      this.selectFuncion.nativeElement.value = undefined;
      this.plantilla.splice(0);
    }
  }

  ngOnInit(): void {
    this._plantillaService.getFunciones().subscribe((response) => {
      this.funciones = response;
    });
  }
}
