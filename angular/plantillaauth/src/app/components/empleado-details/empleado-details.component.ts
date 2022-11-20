// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
import { Plantilla } from 'src/app/models/plantilla';
// Service
import { PlantillaService } from 'src/app/services/plantilla.service';
import { AuthService } from 'src/app/services/auth.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-empleado-details',
  templateUrl: './empleado-details.component.html',
  styleUrls: ['./empleado-details.component.css'],
})
export class EmpleadoDetailsComponent {
  constructor(
    private empleadosService: PlantillaService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  redirect(num: number) {
    this.router.navigate(['numerodoble', num]);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      // Parseamos a número
      const idEmpleado = params.get('idEmpleado')!;
      // this.authService.authInterceptor(this.empleadosService.findEmpleado, idEmpleado);
    });
  }
}
