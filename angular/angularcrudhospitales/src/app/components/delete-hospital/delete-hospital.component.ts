import {
  Component,
  OnInit,
  ɵViewRef,
  ElementRef,
  ViewChild,
} from '@angular/core';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Hospital } from 'src/app/models/Hospital';
import { HospitalesService } from 'src/app/services/hospitales.service';

@Component({
  selector: 'app-delete-hospital',
  templateUrl: './delete-hospital.component.html',
  styleUrls: ['./delete-hospital.component.css'],
})
export class DeleteHospitalComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private serviceHospitales: HospitalesService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = params.get('idhospital')!;

      this.serviceHospitales.deleteHospital(id);

      this.router.navigate(['/']);
    });
  }
}
