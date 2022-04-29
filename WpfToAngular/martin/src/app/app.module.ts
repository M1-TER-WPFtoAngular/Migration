import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainWindowComponent } from './home/martin/Desktop/M1-TER-WPFtoAngular/Migration/WpfToAngular/WPF/martin/main-window/main-window.component';

@NgModule({
  declarations: [
    AppComponent,
    MainWindowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
