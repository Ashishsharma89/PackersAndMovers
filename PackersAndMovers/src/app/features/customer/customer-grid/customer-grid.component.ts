import { Component, OnInit } from '@angular/core';
import { CustomerResponseModel } from '../models/customer-response.model';
import { CustomerService } from '../services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-grid',
  templateUrl: './customer-grid.component.html',
  styleUrls: ['./customer-grid.component.scss'],
})
export class CustomerGridComponent implements OnInit {
  customers: CustomerResponseModel[] = [];

  constructor(private customerService: CustomerService, private router: Router) {}
  
  ngOnInit(): void {
    this.getCustomerDetails();
  }

  getCustomerDetails(): void {
    // Simulate fetching customer details (replace with actual service call if needed)
    // For now, just log the existing customers array
    // Replace with actual service call
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
    });
  }

  goToCustomerForm(): void {
    // Navigate to the customer form component
    // This can be done using Angular Router if needed
    // For now, just log a message
    this.router.navigate(['/customer/form']);
    // Example: this.router.navigate(['/customer/form']);
  }
}
