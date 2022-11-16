import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PadreComicsComponent } from './padre-comics/padre-comics.component';
import { ComicsInyeccionComponent } from './comics-inyeccion/comics-inyeccion.component';
import { PersonasApiComponent } from './personas-api/personas-api.component';

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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
