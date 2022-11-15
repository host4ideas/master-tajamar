import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Comic } from '../models/comic';

@Component({
  selector: 'app-padre-comics',
  templateUrl: './padre-comics.component.html',
  styleUrls: ['./padre-comics.component.css'],
})
export class PadreComicsComponent implements OnInit {
  public comics: Array<Comic>;
  public comicUpdate!: Comic;
  public comicFav!: Comic;
  @ViewChild('cajaTitulo') cajaTitulo!: ElementRef;
  @ViewChild('cajaDescripcion') cajaDescripcion!: ElementRef;
  @ViewChild('cajaImagen') cajaImagen!: ElementRef;

  constructor() {
    this.comics = [
      new Comic(
        'Spiderman',
        'https://images-na.ssl-images-amazon.com/images/I/61AYfL5069L.jpg',
        'Hombre araña'
      ),
      new Comic(
        'Wolverine',
        'https://i.etsystatic.com/9340224/r/il/42f0e1/1667448004/il_570xN.1667448004_sqy0.jpg',
        'Lobezno'
      ),
      new Comic(
        'Guardianes de la Galaxia',
        'https://cdn.normacomics.com/media/catalog/product/cache/1/thumbnail/9df78eab33525d08d6e5fb8d27136e95/g/u/guardianes_galaxia_guadianes_infinito.jpg',
        'Yo soy Groot'
      ),
      new Comic(
        'Avengers',
        'https://d26lpennugtm8s.cloudfront.net/stores/057/977/products/ma_avengers_01_01-891178138c020318f315132687055371-640-0.jpg',
        'Los Vengadores'
      ),
      new Comic(
        'Spawn',
        'https://i.pinimg.com/originals/e1/d8/ff/e1d8ff4aeab5e567798635008fe98ee1.png',
        'Todd MacFarlane'
      ),
    ];
  }

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

  ngOnInit(): void {}
}
