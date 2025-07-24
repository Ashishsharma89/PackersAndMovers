import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerRoutingModule } from './customer-routing.module';
import { FormsModule } from '@angular/forms';
import { CustomerGridComponent } from './customer-grid/customer-grid.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerService } from './services/customer.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
// import { RequestInterceptor } from '../../shared/request.interceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { CoreModule } from '../../core/core.module';
// ...removed BrowserModule import...

@NgModule({
  declarations: [CustomerGridComponent, CustomerFormComponent],
  imports: [
    CommonModule,
    CoreModule,
    HttpClientModule,
    CustomerRoutingModule,
    MatSnackBarModule,
    FormsModule
  ],
  providers: [
    CustomerService,
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: RequestInterceptor,
    //   multi: true
    // },
  ],
})
export class CustomerModule { }
