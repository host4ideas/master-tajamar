import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { DepartamentosComponent } from './components/departamentos/departamentos.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {routing, appRoutingProviders} from './app.routing';
import { DepartamentosService } from './services/departamentos.service';
import { InsertardepartamentoComponent } from './components/insertardepartamento/insertardepartamento.component';
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    DepartamentosComponent,
    InsertardepartamentoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule, routing
  ],
  providers: [appRoutingProviders, DepartamentosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
