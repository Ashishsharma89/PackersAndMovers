import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from '../../../configs/api-endpoints.config';
import { Observable } from 'rxjs';
import { DriverRequest } from '../models/driver-request.model';
import { BaseUrl } from '../../../configs/base-url.config';

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  readonly baseApiUrl = BaseUrl.baseApiUrl;

  constructor(private http: HttpClient) {}

  getDriverById(id: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}${ApiEndpoints.drivers.GET_DRIVER_BY_ID(id)}`);
  }

  updateDriverLocation(driver: DriverRequest) {
    return this.http.post(
      `${this.baseApiUrl}${ApiEndpoints.drivers.UPDATE_DRIVER_LOCATION}`,
      driver
    );
  }
}
