// Base
import {
  Component,
  OnInit,
  ɵViewRef,
  ElementRef,
  ViewChild,
} from '@angular/core';
// Model
import { Hospital } from 'src/app/models/Hospital';
// Service
import { HospitalesService } from 'src/app/services/hospitales.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-update-hospital',
  templateUrl: './update-hospital.component.html',
  styleUrls: ['./update-hospital.component.css'],
})
export class UpdateHospitalComponent implements OnInit {
  // Form inputs
  @ViewChild('cajaNombre') cajaNombre!: ElementRef;
  @ViewChild('cajaDireccion') cajaDireccion!: ElementRef;
  @ViewChild('cajaTeléfono') cajaTeléfono!: ElementRef;
  @ViewChild('cajaCamas') cajaCamas!: ElementRef;

  public hospital!: Hospital;

  constructor(
    private hospitalesService: HospitalesService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  updateDepartamento(): void {
    const newHospital = new Hospital(
      this.hospital.idhospital,
      this.cajaNombre.nativeElement.value,
      this.cajaDireccion.nativeElement.value,
      this.cajaTeléfono.nativeElement.value,
      parseInt(this.cajaCamas.nativeElement.value)
    );

    this.hospitalesService.updateHospital(newHospital).subscribe(response => {
      
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.hospital = new Hospital(
        +params.get('idhospital')!,
        params.get('nombre')!,
        params.get('direccion')!,
        params.get('telefono')!,
        +params.get('camas')!
      );
    });
  }
}
