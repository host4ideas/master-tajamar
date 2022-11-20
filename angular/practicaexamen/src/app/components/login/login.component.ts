// Base
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
// Model
// Models
import { Plantilla } from 'src/app/models/plantilla';
// Service
import { AuthService } from 'src/app/services/auth.service';
import { PlantillaService } from 'src/app/services/plantilla.service';
// Rutas
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  // Form inputs
  @ViewChild('cajaUsuario') cajaUsuario!: ElementRef;
  @ViewChild('cajaPass') cajaPass!: ElementRef;

  constructor(
    private plantillaService: PlantillaService,
    private authService: AuthService,
    private router: Router
  ) {}

  login(): void {
    const user = this.cajaUsuario.nativeElement.value;
    const pass = this.cajaPass.nativeElement.value;

    if (user && pass) {
      const loginUser = {
        userName: user,
        password: pass,
      };

      this.authService.login(loginUser);
    }
  }

  ngOnInit(): void {
    this.authService.checkUser().then((user) => {
      if (user) {
        this.router.navigate(['/subordinados']);
      } else {
        this.router.navigate(['/login']);
      }
    });
  }
}
