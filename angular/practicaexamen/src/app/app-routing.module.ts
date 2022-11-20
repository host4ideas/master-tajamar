import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetallesSerie } from './components/detalles-serie/detalles-serie.component';
import { PersonajesSerie } from './components/personajes-serie/personajes-serie.component';
import { NuevoPersonajeComponent } from './components/nuevo-personaje/nuevo-personaje.component';
import { ModificarPersonajeComponent } from './components/modificar-personaje/modificar-personaje.component';
import { PlantillaComponent } from './components/plantilla/plantilla.component';
import { SubordinadosComponent } from './components/subordinados/subordinados.component';
import { PerfilEmpleadoComponent } from './components/perfil-empleado/perfil-empleado.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {
    path: 'detalles-serie/:idserie',
    component: DetallesSerie,
  },
  {
    path: 'personajes-serie/:idserie',
    component: PersonajesSerie,
  },
  {
    path: 'nuevo-personaje',
    component: NuevoPersonajeComponent,
  },
  {
    path: 'modificar-personaje',
    component: ModificarPersonajeComponent,
  },
  {
    path: 'plantilla',
    component: PlantillaComponent,
  },
  {
    path: 'subordinados',
    component: SubordinadosComponent,
  },
  {
    path: 'perfil-empleado',
    component: PerfilEmpleadoComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
