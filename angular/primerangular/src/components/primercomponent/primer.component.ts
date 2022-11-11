import { Component } from '@angular/core';

// Debemos indicar un selector que será el nombre de etiqueta para las páginas de nuestro proyecto
@Component({
  selector: 'primer-component',
  //   template: ` <h1>Soy el primer component de Angular!!!</h1>
  //     <h2 style="color: blue;">{{ titulo }}</h2>
  //     <h2 style="color: red;">
  //       Descripción: {{ descripcion }}
  //     </h2>
  //     <h2 style="color: red;">
  //       Año: {{ anio }}
  //     </h2>`,
  templateUrl: './primer.component.html',
  styleUrls: ['./primer.component.css'],
})

// Una cosa es el nombre de clase y otra el nombre en el html
export class PrimerComponent {
  public titulo: String;
  public descripcion: String;
  public anio: Number;

  constructor() {
    this.titulo = 'Viernes de Angular';
    this.descripcion = 'Aprendiendo Angular a tope!!!';
    this.anio = 2022;
  }
}
