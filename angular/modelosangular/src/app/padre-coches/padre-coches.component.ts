import { Component, OnInit } from '@angular/core';
import { Coche } from '../models/coche';

@Component({
  selector: 'app-padre-coches',
  templateUrl: './padre-coches.component.html',
  styleUrls: ['./padre-coches.component.css'],
})
export class PadreCochesComponent implements OnInit {
  public coches: Array<Coche>;

  constructor() {
    this.coches = [
      new Coche('Ford', 'Focus', 180, 10, false),
      new Coche('Volkswagen', 'Golf', 210, 18, true),
      new Coche('MINI', 'Cooper S', 180, 17, false),
    ];
  }

  ngOnInit(): void {}
}
