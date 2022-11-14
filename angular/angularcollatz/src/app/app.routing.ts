// Import components
import { HomeComponent } from './components/home/home.component';
import { CollatzComponent } from './components/collatz/collatz.component';
// Router imports
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'collatz/:num',
    component: CollatzComponent,
  },
];

const appRoutingProvider: any[] = [];
const routing: ModuleWithProviders<any> = RouterModule.forRoot(appRoutes);

export { appRoutingProvider, routing };
