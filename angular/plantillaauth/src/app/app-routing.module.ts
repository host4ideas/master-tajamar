import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { EmpleadoDetailsComponent } from './components/empleado-details/empleado-details.component';

const routes: Routes = [
  {
    path: '',
    component: EmpleadosComponent,
  },
  {
    path: 'empleado/:idEmpleado',
    component: EmpleadoDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
