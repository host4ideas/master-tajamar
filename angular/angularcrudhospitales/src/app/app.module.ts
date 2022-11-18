import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { HospitalesComponent } from './components/hospitales/hospitales.component';
import { CreateHostpitalComponent } from './components/create-hostpital/create-hostpital.component';
import { UpdateHospitalComponent } from './components/update-hospital/update-hospital.component';
import { DeleteHospitalComponent } from './components/delete-hospital/delete-hospital.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HospitalesComponent,
    CreateHostpitalComponent,
    UpdateHospitalComponent,
    DeleteHospitalComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
