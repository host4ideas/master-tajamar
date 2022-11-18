import { Component, OnInit } from '@angular/core';
import { Hospital } from 'src/app/models/Hospital';
import { HospitalesService } from 'src/app/services/hospitales.service';

@Component({
  selector: 'app-hospitales',
  templateUrl: './hospitales.component.html',
  styleUrls: ['./hospitales.component.css'],
})
export class HospitalesComponent implements OnInit {
  public hospitales!: Hospital[];

  constructor(private hospitalesService: HospitalesService) {}

  loadHospitales(): void {
    this.hospitalesService.getHospitales().subscribe((response) => {
      this.hospitales = response;
    });
  }

  ngOnInit(): void {
    this.loadHospitales();
  }
}
