// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
import { Personaje } from 'src/app/models/personaje';
import { Serie } from 'src/app/models/serie';
// Service
import { SeriesService } from 'src/app/services/series.service';
import { PersonajesService } from 'src/app/services/personajes.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-modificar-personaje',
  templateUrl: './modificar-personaje.component.html',
  styleUrls: ['./modificar-personaje.component.css'],
})
export class ModificarPersonajeComponent implements OnInit {
  public selectedSerie!: string;
  public selectedPersonaje!: string;

  public personajes!: Personaje[];
  public series!: Serie[];

  constructor(
    private seriesService: SeriesService,
    private personajesService: PersonajesService,
    private router: Router
  ) {}

  loadSeries(): void {
    this.seriesService.getSeries().subscribe((res) => (this.series = res));
  }

  loadPersonajes(): void {
    this.personajesService
      .getPersonajes()
      .subscribe((res) => (this.personajes = res));
  }

  modificarPersonaje(): void {
    this.personajesService
      .updatePersonajeSerie(this.selectedPersonaje, this.selectedSerie)
      .subscribe((res) =>
        this.router.navigate(['/personajes-serie', this.selectedSerie])
      );
  }

  ngOnInit(): void {
    this.loadPersonajes();
    this.loadSeries();
  }
}
