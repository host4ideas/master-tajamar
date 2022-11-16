import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonasService } from '../services/personas.service';

@Component({
  selector: 'app-personas-api',
  templateUrl: './personas-api.component.html',
  styleUrls: ['./personas-api.component.css'],
})
export class PersonasApiComponent implements OnInit {
  public personas!: Array<Persona>;

  constructor(private _service: PersonasService) {}

  ngOnInit(): void {
    this._service.getPersonas().subscribe((res) => {
      this.personas = res;
    });
    this._service.getPersonas2().then((data) => {
      this.personas = data;
    });
  }
}
