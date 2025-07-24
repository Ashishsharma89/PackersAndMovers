import { Component } from '@angular/core';
import { DriverRequest } from '../models/driver-request.model';
import { DriverService } from '../services/driver.service';

@Component({
  selector: 'app-update-driver-location',
  templateUrl: './update-driver-location.component.html',
  // styleUrls: ['./update-driver-location.component.scss']
})
export class UpdateDriverLocationComponent {
  driver: DriverRequest = {
    driverId: 0,
    latitude: 0,
    longitude: 0
  };

  constructor(private driverService: DriverService) {}

  onSubmit() {
    // Handle form submission
    this.driverService.updateDriverLocation(this.driver).subscribe({
      next: (response) => {
        console.log('Location updated successfully:', response);
      },
      error: (error) => {
        console.error('Error updating location:', error);
      }
    });
  }

  onChangeDriverLatLng(event: { lat: number; lng: number }) {
    this.driver.latitude = event.lat;
    this.driver.longitude = event.lng;
    console.log(`Driver's new location: Latitude ${event.lat}, Longitude ${event.lng}`);  
  }

  // onDriverIdChange(id: number) {
  //   // Fetch driver details by ID if needed
  //   this.driverService.getDriverById(id).subscribe({
  //     next: (driver) => {
  //       // this.driver = driver;
  //     },
  //     error: (error) => {
  //       console.error('Error fetching driver details:', error);
  //     }
  //   });
  // }


}
