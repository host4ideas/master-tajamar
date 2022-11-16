import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Comic } from '../models/comic';
import { ComicsService } from '../services/comics.service';

@Component({
  selector: 'app-padre-comics',
  templateUrl: './padre-comics.component.html',
  styleUrls: ['./padre-comics.component.css'],
})
export class PadreComicsComponent implements OnInit {
  public comics!: Array<Comic>;
  public comicUpdate!: Comic;
  public comicFav!: Comic;
  @ViewChild('cajaTitulo') cajaTitulo!: ElementRef;
  @ViewChild('cajaDescripcion') cajaDescripcion!: ElementRef;
  @ViewChild('cajaImagen') cajaImagen!: ElementRef;

  constructor(private _service: ComicsService) {}

  /**
   *
   * @param comic Comic que usaremos para settear los valores de los inputs y como comic a actualizar con los nuevos valores
   */
  seleccionarComic(comic: Comic): void {
    this.comicUpdate = comic;
    this.cajaTitulo.nativeElement.value = comic.titulo;
    this.cajaDescripcion.nativeElement.value = comic.descripcion;
    this.cajaImagen.nativeElement.value = comic.imagen;
  }

  actualizarComic(): void {
    if (this.comicUpdate) {
      this.comicUpdate.descripcion = this.cajaTitulo.nativeElement.value;
      this.comicUpdate.titulo = this.cajaDescripcion.nativeElement.value;
      this.comicUpdate.imagen = this.cajaImagen.nativeElement.value;
    }
  }

  seleccionarComicFav(comic: Comic): void {
    this.comicFav = comic;
  }

  deleteComic(comic: Comic): void {
    console.log(comic);
    this.comics.splice(this.comics.indexOf(comic), 1);
  }

  ngOnInit(): void {
    this.comics = this._service.getComics();
  }
}
