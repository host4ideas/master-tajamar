// Angular
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
// Services
import { AuthService } from 'src/app/services/auth.service';
import { PlantillaService } from 'src/app/services/plantilla.service';
// Models
import { Plantilla } from 'src/app/models/plantilla';

@Component({
  selector: 'app-subordinados',
  templateUrl: './subordinados.component.html',
  styleUrls: ['./subordinados.component.css'],
})
export class SubordinadosComponent {
  public plantilla!: Plantilla[];

  constructor(
    private servicePlantilla: PlantillaService,
    private authService: AuthService
  ) {}

  /**
   * Carga los empleados del servidor. Actualiza la variable public plantilla para mostrar los empleados al usuario.
   */
  async loadSubordinados(): Promise<void> {
    /*
      LLamamos al metodo auth para recoger la funcion copia provista del header.
      Para no perder el contexto de la peticion original, le damos el contexto del service al que pertenece.
    */
    const validatedCall = await this.authService.authInterceptor(
      this.servicePlantilla.getSubordinados.bind(this.servicePlantilla)
    );

    /*
      La funcion copia de auth es la misma que una peticion http.
      Si hay un código existente en localStorage, pero no es válido, devolverá un error 401 y se reseteara el token.
    */
    validatedCall().subscribe(
      (res: Plantilla[]) => (this.plantilla = res),
      (err: HttpErrorResponse) => {
        if (err.status == 401) {
          this.authService.logout();
        }
      }
    );
  }

  ngOnInit(): void {
    this.loadSubordinados();
  }
}
