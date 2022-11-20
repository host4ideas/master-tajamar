// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
import { Personaje } from 'src/app/models/personaje';
// Service
import { SeriesService } from 'src/app/services/series.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-personajes-serie',
  templateUrl: './personajes-serie.component.html',
  styleUrls: ['./personajes-serie.component.css'],
})
export class PersonajesSerie implements OnInit {
  public personajes!: Personaje[];

  constructor(
    private seriesService: SeriesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  redirect(num: number) {
    this.router.navigate(['numerodoble', num]);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const idserie = params.get('idserie')!;
      this.seriesService.getPersonajesSerie(idserie).subscribe((res) => {
        this.personajes = res;
      });
    });
  }
}
