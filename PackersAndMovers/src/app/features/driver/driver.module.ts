import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DriverGridComponent } from './driver-grid/driver-grid.component';
import { UpdateDriverLocationComponent } from './update-driver-location/update-driver-location.component';
import { DriverRoutingModule } from './driver-routing.module';
import { DriverService } from './services/driver.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from '../../core/core.module';
import { SharedModule } from '../../shared/shared.module';
// import { TransportationModule } from '../transportation/transportation.module';

@NgModule({
  declarations: [DriverGridComponent, UpdateDriverLocationComponent],
  imports: [
    CommonModule,
    CoreModule,
    HttpClientModule,
    MatSnackBarModule,
    FormsModule,
    SharedModule,
    DriverRoutingModule
  ],
  providers: [DriverService],
})
export class DriverModule {}
