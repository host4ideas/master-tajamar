import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalesComponent } from './components/hospitales/hospitales.component';
import { UpdateHospitalComponent } from './components/update-hospital/update-hospital.component';
import { CreateHostpitalComponent } from './components/create-hostpital/create-hostpital.component';
import { DeleteHospitalComponent } from './components/delete-hospital/delete-hospital.component';

const routes: Routes = [
  {
    path: '',
    component: HospitalesComponent,
  },
  {
    path: 'update-hospital/:idhospital/:nombre/:direccion/:telefono/:camas',
    component: UpdateHospitalComponent,
  },
  {
    path: 'create-hospital',
    component: CreateHostpitalComponent,
  },
  {
    path: 'delete-hospital/idhospital',
    component: DeleteHospitalComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
