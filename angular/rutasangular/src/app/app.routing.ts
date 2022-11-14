// Components
import { HomeComponent } from './components/home/home.component';
import { CineComponent } from './components/cine/cine.component';
import { MusicaComponent } from './components/musica/musica.component';
import { TelevisionComponent } from './components/television/television.component';
import { ErrornotfoundComponent } from './components/errornotfound/errornotfound.component';
import { NumerodobleComponent } from './components/numerodoble/numerodoble.component';
// Router imports
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'musica',
    component: MusicaComponent,
  },
  {
    path: 'cine',
    component: CineComponent,
  },
  {
    path: 'television',
    component: TelevisionComponent,
  },
  {
    path: 'numerodoble/',
    component: NumerodobleComponent,
  },
  {
    path: 'numerodoble/:num',
    component: NumerodobleComponent,
  },
  {
    path: '**',
    component: ErrornotfoundComponent,
  },
];

const appRoutingProvider: any[] = [];
const routing: ModuleWithProviders<any> = RouterModule.forRoot(appRoutes);

export { appRoutingProvider, routing };
