import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// Routing
import { routing, appRoutingProvider } from './app.routing';
// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { CineComponent } from './components/cine/cine.component';
import { MusicaComponent } from './components/musica/musica.component';
import { TelevisionComponent } from './components/television/television.component';
import { MenuComponent } from './components/menu/menu.component';
import { ErrornotfoundComponent } from './components/errornotfound/errornotfound.component';
import { NumerodobleComponent } from './components/numerodoble/numerodoble.component';
import { MenucollatzComponent } from './components/menucollatz/menucollatz.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CineComponent,
    MusicaComponent,
    TelevisionComponent,
    MenuComponent,
    ErrornotfoundComponent,
    NumerodobleComponent,
    MenucollatzComponent,
  ],
  imports: [BrowserModule, routing],
  providers: [appRoutingProvider],
  bootstrap: [AppComponent],
})
export class AppModule {}
