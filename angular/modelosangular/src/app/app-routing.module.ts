import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaProductoComponent } from './listaproducto/listaproducto.component';
import { HijoCocheComponent } from './hijo-coche/hijo-coche.component';
import { PadreCochesComponent } from './padre-coches/padre-coches.component';
import { PadreDeportesComponent } from './padre-deportes/padre-deportes.component';

const routes: Routes = [
  {
    path: 'productos',
    component: ListaProductoComponent,
  },
  {
    path: 'coches',
    component: PadreCochesComponent,
  },
  {
    path: 'deportes',
    component: PadreDeportesComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
