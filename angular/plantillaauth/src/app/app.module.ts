import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { SubordinadosComponent } from './components/subordinados/subordinados.component';
import { PerfilEmpleadoComponent } from './components/perfil-empleado/perfil-empleado.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { EmpleadoDetailsComponent } from './components/empleado-details/empleado-details.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SubordinadosComponent,
    PerfilEmpleadoComponent,
    EmpleadosComponent,
    EmpleadoDetailsComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
