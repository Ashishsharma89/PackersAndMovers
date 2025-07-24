import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiEndpoints } from '../../../configs/api-endpoints.config';
import { BaseUrl } from '../../../configs/base-url.config';

@Injectable({
    providedIn: 'root'
})
export class DashboardService {
    readonly baseApiUrl = BaseUrl.baseApiUrl;
    
    constructor(private http: HttpClient) {}

    getStats() {
        return this.http.get(`${this.baseApiUrl}${ApiEndpoints.dashboard.GET_DASHBOARD_STATS}`);
    }

    getTopCustomers(): Observable<any> {
        return this.http.get(`${this.baseApiUrl}${ApiEndpoints.dashboard.GET_DASHBOARD_TOP_CUSTOMERS}`);
    }

    getMonthlyTrends(): Observable<any> {
        return this.http.get(`${this.baseApiUrl}${ApiEndpoints.dashboard.GET_DASHBOARD_MONTHLY_TRENDS}`);
    }
}