import { Component, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'sumar-numeros',
  templateUrl: 'sumarnumeros.component.html',
})
export class SumarNumeros {
  @ViewChild('cajaNumero1') cajaNumero1 = {} as ElementRef;
  @ViewChild('cajaNumero2') cajaNumero2!: ElementRef;
  public sumaTotal: number;

  constructor() {
    this.cajaNumero1 = new ElementRef(0);
    this.sumaTotal = 0;
  }

  sumarNumeros(): void {
    this.sumaTotal =
      parseInt(this.cajaNumero1.nativeElement.value) +
      parseInt(this.cajaNumero2.nativeElement.value);
  }
}
