import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/supplier.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {
  supplier = {
    SupplierName: '',
    SupplierTelephone: '',
    isActive: false

  };
  submitted = false;
  errorResponse = "";

  constructor(private supplierService: SupplierService) { }

  ngOnInit() {
  }

  saveSupplier() {
    const data = {
      SupplierName: this.supplier.SupplierName,
      SupplierTelephone: this.supplier.SupplierTelephone,
      isActive: true
    };

    this.supplierService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
          error => {
            console.log(error);
            this.errorResponse = error.error.Message;
        });
  }

  newSupplier() {
    this.submitted = false;
    this.supplier = {
      SupplierName: '',
      SupplierTelephone: '',
      isActive: false
    };
  }
}
