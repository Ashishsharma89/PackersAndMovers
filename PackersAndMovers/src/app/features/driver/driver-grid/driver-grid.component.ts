import { Component } from '@angular/core';

@Component({
  selector: 'app-driver-grid',
  templateUrl: './driver-grid.component.html',
//   styleUrls: ['./driver-grid.component.scss']
})
export class DriverGridComponent {
  drivers = [
    { driverId: 1, latitude: 12.9716, longitude: 77.5946 },
    { driverId: 2, latitude: 28.7041, longitude: 77.1025 }
  ];

goToDriverForm() {
    window.location.href = '/driver/update-location';
  }
}
