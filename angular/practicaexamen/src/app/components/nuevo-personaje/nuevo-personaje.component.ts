// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
import { Personaje } from 'src/app/models/personaje';
import { Serie } from 'src/app/models/serie';
// Service
import { PersonajesService } from 'src/app/services/personajes.service';
import { SeriesService } from 'src/app/services/series.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-nuevo-personaje',
  templateUrl: './nuevo-personaje.component.html',
  styleUrls: ['./nuevo-personaje.component.css'],
})
export class NuevoPersonajeComponent {
  // Form inputs
  @ViewChild('cajaNombre') cajaNombre!: ElementRef;
  @ViewChild('cajaImagen') cajaImagen!: ElementRef;

  public selectedSerie!: string;
  public series!: Serie[];

  constructor(
    private personajesService: PersonajesService,
    private seriesService: SeriesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  loadSeries(): void {
    this.seriesService.getSeries().subscribe((res) => (this.series = res));
  }

  insertarPersonaje(): void {
    const nuevoPersonaje = new Personaje(
      0,
      this.cajaNombre.nativeElement.value,
      this.cajaImagen.nativeElement.value,
      +this.selectedSerie
    );

    this.personajesService
      .createPersonaje(nuevoPersonaje)
      .subscribe((res) =>
        this.router.navigate(['/personajes-serie', this.selectedSerie])
      );
  }

  ngOnInit(): void {
    this.loadSeries();
  }
}
