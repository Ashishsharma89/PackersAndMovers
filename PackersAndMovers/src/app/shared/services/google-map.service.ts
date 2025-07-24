import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BranchMapMarker } from '../models/branch-map-maker.model';


@Injectable({
  providedIn: 'root'
})
export class GoogleMapService {

  private defaultBranches = [
    { id: 1, name: 'Google', lat: 46.948, lng: 7.4474, postCode: '3000', canton: 'BE', location: 'Bern' }
  ];

  getDefaultBranches(): any[] {
    return [...this.defaultBranches];
  }

  constructor(private http: HttpClient) {}

//   // Example: Get geocode for an address
//   getGeocode(address: string): Observable<any> {
//     const url = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(address)}&key=${this.apiKey}`;
//     return this.http.get(url);
//   }

//   // Example: Get directions between two locations
//   getDirections(origin: string, destination: string): Observable<any> {
//     const url = `https://maps.googleapis.com/maps/api/directions/json?origin=${encodeURIComponent(origin)}&destination=${encodeURIComponent(destination)}&key=${this.apiKey}`;
//     return this.http.get(url);
//   }

  getMarkers(branches: any[]): BranchMapMarker[] {
    return branches
      .map((branch: any) => ({
        label: '',
        position: { lat: branch.lat, lng: branch.lng },
        title: branch.name,
        options: { animation: google.maps.Animation.DROP },
        branch: branch,
      }))
      .filter((marker: any) => !isNaN(marker.position.lat) && !isNaN(marker.position.lng));
  }

  addBranchOnMapClick(branches: any[], event: google.maps.MapMouseEvent): { branches: any[], center: { lat: number, lng: number } | null } {
    if (event.latLng) {
      const lat = event.latLng.lat();
      const lng = event.latLng.lng();
      const newBranch = {
        id: Date.now(),
        name: 'New Branch',
        lat,
        lng,
        postCode: '',
        canton: '',
        location: ''
      };
      return {
        branches: [...branches, newBranch],
        center: { lat, lng }
      };
    }
    return { branches, center: null };
  }
}
