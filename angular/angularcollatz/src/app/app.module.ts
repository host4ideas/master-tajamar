import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { appRoutingProvider, routing } from './app.routing';

import { AppComponent } from './app.component';
import { MenucollatzComponent } from './components/menucollatz/menucollatz.component';
import { CollatzComponent } from './components/collatz/collatz.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    MenucollatzComponent,
    CollatzComponent,
    HomeComponent,
    MenuComponent,
  ],
  imports: [BrowserModule, routing],
  providers: [appRoutingProvider],
  bootstrap: [AppComponent],
})
export class AppModule {}
