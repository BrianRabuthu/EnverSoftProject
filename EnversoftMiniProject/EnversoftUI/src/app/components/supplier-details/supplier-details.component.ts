import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/supplier.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styleUrls: ['./supplier-details.component.css']
})
export class SupplierDetailsComponent implements OnInit {
  currentSupplier = null;
  message = '';

  constructor(
    private supplierService: SupplierService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.message = '';
    this.getSupplier(this.route.snapshot.paramMap.get('id'));
  }

  getSupplier(id) {
    this.supplierService.get(id)
      .subscribe(
        data => {
          this.currentSupplier = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
