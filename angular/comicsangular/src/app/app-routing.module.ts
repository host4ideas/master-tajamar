import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PadreComicsComponent } from './padre-comics/padre-comics.component';
import { ComicsInyeccionComponent } from './comics-inyeccion/comics-inyeccion.component';
import { PersonasApiComponent } from './personas-api/personas-api.component';
import { EmpleadosSalarioComponent } from './empleados-salario/empleados-salario.component';
import { EmpleadosOficioComponent } from './empleados-oficio/empleados-oficio.component';
import { EmpleadosPlantillaComponent } from './empleados-plantilla/empleados-plantilla.component';
import { MaestroEmpleadosComponent } from './maestro-empleados/maestro-empleados.component';
import { DetallesEmpleadoComponent } from './detalles-empleado/detalles-empleado.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'comics',
    component: PadreComicsComponent,
  },
  {
    path: 'comics-inyeccion',
    component: ComicsInyeccionComponent,
  },
  {
    path: 'personas-api',
    component: PersonasApiComponent,
  },
  {
    path: 'empleados-api',
    component: EmpleadosSalarioComponent,
  },
  {
    path: 'empleados-oficios-api',
    component: EmpleadosOficioComponent,
  },
  {
    path: 'plantilla-api',
    component: EmpleadosPlantillaComponent,
  },
  {
    path: 'maestro-empleados',
    component: MaestroEmpleadosComponent,
  },
  {
    path: 'detalles-empleados/:idEmpleado',
    component: DetallesEmpleadoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
