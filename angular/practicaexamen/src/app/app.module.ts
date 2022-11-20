import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { DetallesSerie } from './components/detalles-serie/detalles-serie.component';
import { PersonajesSerie } from './components/personajes-serie/personajes-serie.component';
import { NuevoPersonajeComponent } from './components/nuevo-personaje/nuevo-personaje.component';
import { ModificarPersonajeComponent } from './components/modificar-personaje/modificar-personaje.component';
import { PlantillaComponent } from './components/plantilla/plantilla.component';
import { SubordinadosComponent } from './components/subordinados/subordinados.component';
import { PerfilEmpleadoComponent } from './components/perfil-empleado/perfil-empleado.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [AppComponent, MenuComponent, DetallesSerie, PersonajesSerie, NuevoPersonajeComponent, ModificarPersonajeComponent, PlantillaComponent, SubordinadosComponent, PerfilEmpleadoComponent, LoginComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
