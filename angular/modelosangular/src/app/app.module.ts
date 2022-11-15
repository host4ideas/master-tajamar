import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListaProductoComponent } from './listaproducto/listaproducto.component';
import { HijoCocheComponent } from './hijo-coche/hijo-coche.component';
import { PadreCochesComponent } from './padre-coches/padre-coches.component';
import { HijoDeporteComponent } from './hijo-deporte/hijo-deporte.component';
import { PadreDeportesComponent } from './padre-deportes/padre-deportes.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaProductoComponent,
    HijoCocheComponent,
    PadreCochesComponent,
    HijoDeporteComponent,
    PadreDeportesComponent,
    MenuComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
