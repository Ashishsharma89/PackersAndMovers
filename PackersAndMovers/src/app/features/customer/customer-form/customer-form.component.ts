import { Component } from '@angular/core';
import { CustomerRequestModel } from '../models/customer-request.model';
import { CustomerService } from '../services/customer.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
// import { SnackbarService } from '../../../shared/snackbar.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss'],
})
export class CustomerFormComponent {
  customer: CustomerRequestModel = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    address: '',
    registrationDate: '',
    status: 'pending'
  };

  constructor(
    private customerService: CustomerService, 
    private router: Router, 
    // private snackbarService: SnackbarService
  ) {}

  onSubmit(form: NgForm) {
    if (form.valid) {
      // Call your service to add the customer here
      console.log('Customer added:', this.customer);
      this.customerService.addCustomer(this.customer).subscribe(response => {
        if (response) {
          debugger;
          // this.snackbarService.success('Customer added successfully!');
          this.router.navigate(['/customer']);
        }
      });
      
    }
  }
}
