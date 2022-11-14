import { Component, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'tabla-multiplicar',
  templateUrl: 'tablamultiplicar.component.html',
})
export class TablaMultiplicar {
  @ViewChild('cajaNumero') cajaNumero = {} as ElementRef;
  public numeroInput: number;
  public resultados: Array<number>;

  constructor() {
    this.resultados = new Array<number>();
    this.numeroInput = Number();
  }

  onSubmit = () => {
    this.resultados.splice(0);

    const num = parseInt(this.cajaNumero.nativeElement.value);
    this.numeroInput = num;

    for (let i = 0; i < 11; i++) {
      this.resultados.push(num * i);
    }
  };
}
