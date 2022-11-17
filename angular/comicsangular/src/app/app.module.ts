import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// Routing
import { AppRoutingModule } from './app-routing.module';
// Components
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PadreComicsComponent } from './padre-comics/padre-comics.component';
import { HijoComicComponent } from './hijo-comic/hijo-comic.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ComicsInyeccionComponent } from './comics-inyeccion/comics-inyeccion.component';
import { PersonasApiComponent } from './personas-api/personas-api.component';
// Services
import { ComicsService } from './services/comics.service';
import { PersonasService } from './services/personas.service';
import { EmpleadosService } from './services/empleados.service';
import { EmpleadosSalarioComponent } from './empleados-salario/empleados-salario.component';
import { EmpleadosOficioComponent } from './empleados-oficio/empleados-oficio.component';
import { EmpleadosPlantillaComponent } from './empleados-plantilla/empleados-plantilla.component';
import { PlantillaService } from './services/plantilla.service';
import { MaestroEmpleadosComponent } from './maestro-empleados/maestro-empleados.component';
import { DetallesEmpleadoComponent } from './detalles-empleado/detalles-empleado.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PadreComicsComponent,
    HijoComicComponent,
    HomeComponent,
    ComicsInyeccionComponent,
    PersonasApiComponent,
    EmpleadosSalarioComponent,
    EmpleadosOficioComponent,
    EmpleadosPlantillaComponent,
    MaestroEmpleadosComponent,
    DetallesEmpleadoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
  ],
  providers: [
    ComicsService,
    PersonasService,
    EmpleadosService,
    PlantillaService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
