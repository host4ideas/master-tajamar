import { Component, EventEmitter, Output, Input } from '@angular/core';
import { Comic } from '../models/comic';

@Component({
  selector: 'app-hijo-comic',
  templateUrl: './hijo-comic.component.html',
  styleUrls: ['./hijo-comic.component.css'],
})
export class HijoComicComponent {
  // Mandamos al padre, el comic que queremos actualizar
  @Output() seleccionarComic: EventEmitter<Comic> = new EventEmitter();
  @Output() seleccionarComicFav: EventEmitter<Comic> = new EventEmitter();
  @Output() deleteComic: EventEmitter<Comic> = new EventEmitter();
  @Input() comic!: Comic;

  enviarComic(): void {
    this.seleccionarComic.emit(this.comic);
  }

  enviarComicFav(): void {
    this.seleccionarComicFav.emit(this.comic);
  }
  enviarComicParaDelete(): void {
    this.deleteComic.emit(this.comic);
  }
}
