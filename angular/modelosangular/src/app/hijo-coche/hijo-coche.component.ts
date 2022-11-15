import { Component, OnInit, Input } from '@angular/core';
import { Coche } from '../models/coche';

@Component({
  selector: 'app-hijo-coche',
  templateUrl: './hijo-coche.component.html',
  styleUrls: ['./hijo-coche.component.css'],
})
export class HijoCocheComponent implements OnInit {
  @Input() car!: Coche;
  public mensaje!: string;

  comprobarEstado(): boolean {
    if (this.car.estado === false) {
      this.mensaje = 'El coche está apagado';
      this.car.velocidad = 0;
      return false;
    } else {
      this.mensaje = 'El coche está encendido';
      return true;
    }
  }

  encenderCoche(): void {
    this.car.estado = !this.car.estado;
    this.comprobarEstado();
  }

  acelerarCoche(): void {
    if (this.comprobarEstado() === false) {
      alert('Donde vas??? El coche está apagado.');
    } else {
      this.car.velocidad += this.car.aceleracion;
    }
  }

  ngOnInit(): void {
    this.comprobarEstado();
  }
}
