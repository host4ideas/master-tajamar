import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-deportes',
  templateUrl: 'deportes.component.html',
  styleUrls: ['deportes.component.css'],
})
export class DeportesComponent implements OnInit {
  public sports: Array<string>;
  public originalSports: Array<string>;
  public numeros: Array<number>;
  public numerosOriginales: Array<number>;

  constructor() {
    this.sports = [
      'Fútbol',
      'Tenis',
      'Glof',
      'eSports',
      'Bádminton',
      'Canicas',
    ];
    this.originalSports = [...this.sports];
    this.numeros = [5, 6, 7, 8, 9, 10];
    this.numerosOriginales = [...this.numeros];
  }

  ngOnInit() {}

  quitarEle(array: Array<any>): void {
    array.splice(array.length - 1);
  }

  resetSports(): void {
    this.sports = [...this.originalSports];
  }

  resetNumeros(): void {
    this.numeros = [...this.numerosOriginales];
  }
}
