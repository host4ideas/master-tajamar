import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-collatz',
  templateUrl: './collatz.component.html',
  styleUrls: ['./collatz.component.css'],
})
export class CollatzComponent implements OnInit {
  public numCollatz!: number;
  public resultadoCollatz: Array<number>;

  constructor(private route: ActivatedRoute) {
    this.resultadoCollatz = [];
  }

  // Si el número es par, se divide entre 2.
  // Si el número es impar, se multiplica por 3 y se suma 1.
  calcularCollatz(num: number): number | void {
    const resto = num % 2;
    let resultado = 0;

    if (num !== 0) {
      if (resto === 0) {
        resultado = num / 2;
      } else {
        resultado = num * 3 + 1;
      }

      if (resultado !== 1) {
        this.calcularCollatz(resultado);
        this.resultadoCollatz.push(resultado);
      } else {
        return;
      }
    } else {
      return;
    }
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.resultadoCollatz.splice(0);
      // Parseamos a número
      this.numCollatz = +params.get('num')!;
      this.calcularCollatz(this.numCollatz);
    });
  }
}
