import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-padre-deportes',
  templateUrl: './padre-deportes.component.html',
  styleUrls: ['./padre-deportes.component.css'],
})
export class PadreDeportesComponent implements OnInit {
  public deportes: Array<string>;
  public mensaje!: string;

  constructor() {
    this.deportes = ['Golf', 'Futbol', 'Tenis', 'Petanca', 'Ajedrez'];
  }

  seleccionarDeportePadre(eventData: string): void {
    this.mensaje = eventData;
  }

  ngOnInit(): void {}
}
