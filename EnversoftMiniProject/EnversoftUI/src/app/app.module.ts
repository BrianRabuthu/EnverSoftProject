import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddSupplierComponent } from './components/add-supplier/add-supplier.component';
import { SupplierDetailsComponent } from './components/supplier-details/supplier-details.component';
import { SuppliersListComponent } from './components/suppliers-list/suppliers-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddSupplierComponent,
    SupplierDetailsComponent,
    SuppliersListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
