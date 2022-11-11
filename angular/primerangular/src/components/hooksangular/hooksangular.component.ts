import { Component, OnInit, DoCheck } from '@angular/core';

@Component({
  selector: 'hooks-angular',
  templateUrl: './hooksangular.component.html',
})
export class HooksAngular implements OnInit {
  public mensaje: String;

  constructor() {
    this.mensaje = 'Soy hooks angular';
  }

  // Implementamos el método ngOnInit
  ngOnInit(): void {
    console.log('Init');
  }

  // Implementamos el método ngDoCheck
  ngDoCheck(): void {
    console.log('Ejecutando ngDoCheck()');
  }

  cambiarMensaje(): void {
    this.mensaje = 'Single Day!!!';
  }
}
