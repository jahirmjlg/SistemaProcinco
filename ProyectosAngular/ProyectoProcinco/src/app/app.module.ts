import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './Categorias/list/list.component';
import {HttpClientModule} from '@angular/common/http';
import { ListEstadosComponent } from './Estados/list-estados/list-estados.component';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    ListEstadosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
