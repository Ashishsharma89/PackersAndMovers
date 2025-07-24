import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../configs/api-endpoints.config';
import { BaseUrl } from '../../configs/base-url.config';
import { CustomerRegisterModel } from '../models/register.model';

@Injectable()
export class AuthService {
  readonly baseApiUrl = BaseUrl.baseApiUrl;

  constructor(private http: HttpClient) {}

  login(credentials: { email: string; password: string }): Observable<any> {
    return this.http.post(`${this.baseApiUrl}${ApiEndpoints.auth.LOGIN}`, credentials);
  }

  register(data: CustomerRegisterModel): Observable<any> {
    return this.http.post(`${this.baseApiUrl}${ApiEndpoints.auth.REGISTER}`, data);
  }

  // Add more auth-related methods as needed
}
