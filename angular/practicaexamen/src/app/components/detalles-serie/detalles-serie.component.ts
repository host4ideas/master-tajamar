// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
import { Serie } from 'src/app/models/serie';
// Service
import { SeriesService } from 'src/app/services/series.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-detalles-serie',
  templateUrl: './detalles-serie.component.html',
  styleUrls: ['./detalles-serie.component.css'],
})
export class DetallesSerie implements OnInit {
  public serie!: Serie;

  constructor(
    private seriesService: SeriesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      // Parseamos a número
      const idserie = params.get('idserie')!;
      this.seriesService
        .findSerie(idserie)
        .subscribe((res) => (this.serie = res));
    });
  }
}
