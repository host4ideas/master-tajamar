import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-hijo-deporte',
  templateUrl: './hijo-deporte.component.html',
  styleUrls: ['./hijo-deporte.component.css'],
})
export class HijoDeporteComponent implements OnInit {
  @Input() deporte!: string;
  @Output() seleccionarDeporte: EventEmitter<string> = new EventEmitter();

  seleccionarFavoritoHijo(): void {
    this.seleccionarDeporte.emit(this.deporte);
  }

  ngOnInit(): void {}
}
