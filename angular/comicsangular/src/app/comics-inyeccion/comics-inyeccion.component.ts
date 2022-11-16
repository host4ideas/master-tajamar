import { Component, OnInit } from '@angular/core';
import { Comic } from '../models/comic';
import { ComicsService } from '../services/comics.service';

@Component({
  selector: 'app-comics-inyeccion',
  templateUrl: './comics-inyeccion.component.html',
  styleUrls: ['./comics-inyeccion.component.css'],
})
export class ComicsInyeccionComponent implements OnInit {
  public comics!: Array<Comic>;

  constructor(private _service: ComicsService) {}

  ngOnInit(): void {
    this.comics = this._service.getComics();
  }
}
