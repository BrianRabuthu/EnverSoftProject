import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/supplier.service';

@Component({
  selector: 'app-suppliers-list',
  templateUrl: './suppliers-list.component.html',
  styleUrls: ['./suppliers-list.component.css']
})
export class SuppliersListComponent implements OnInit {

  suppliers: any;
  currentSupplier = null;
  currentIndex = -1;
  SupplierName = '';
  errorResponse = '';


  constructor(private supplierService: SupplierService) { }

  ngOnInit() {
    this.retrieveSuppliers();
  }

  retrieveSuppliers() {
    this.supplierService.getAll()
      .subscribe(
        data => {
          this.suppliers = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList() {
    this.retrieveSuppliers();
    this.currentSupplier = null;
    this.currentIndex = -1;
  }

  setActiveSupplier(supplier, index) {
    this.currentSupplier = supplier;
    this.currentIndex = index;
  }

  searchSupplier() {
    this.supplierService.findSupplier(this.SupplierName)
      .subscribe(
        data => {
          this.suppliers = data;
          this.errorResponse = '';
          this.currentSupplier = null;
          this.currentIndex = -1;
        },
        error => {
          console.log(error);
          this.errorResponse = error.error.Message;
          this.suppliers = null;
        });
  }
}
