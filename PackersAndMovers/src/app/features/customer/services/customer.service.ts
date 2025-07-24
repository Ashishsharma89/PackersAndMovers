import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from '../../../configs/api-endpoints.config';
import { Observable, of } from 'rxjs';
import { CustomerResponseModel } from '../models/customer-response.model';
import { BaseUrl } from '../../../configs/base-url.config';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  readonly baseApiUrl = BaseUrl.baseApiUrl;

  constructor(private http: HttpClient) {}

  getCustomers(): Observable<CustomerResponseModel[]> {
    return this.http.get<CustomerResponseModel[]>(`${this.baseApiUrl}${ApiEndpoints.customers.GET_CUSTOMERS}`);
  }
  addCustomer(customer: CustomerResponseModel): Observable<CustomerResponseModel> {
    return this.http.post<CustomerResponseModel>(
      `${this.baseApiUrl}${ApiEndpoints.customers.ADD_CUSTOMER}`,
      customer
    );
  }
}
