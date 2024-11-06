import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from "ngx-bootstrap/modal"

import { ProdutosService } from './produtos.service';
import { ProdutosComponent } from './components/produtos/produtos.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    FormsModule
  ],
  providers: [HttpClientModule, ProdutosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
