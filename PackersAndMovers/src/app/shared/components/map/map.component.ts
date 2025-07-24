import { Component, EventEmitter, Output, signal, ViewChild } from '@angular/core';
import { MapInfoWindow, MapMarker } from '@angular/google-maps';
import { BranchMapMarker } from '../../models/branch-map-maker.model';
import { GoogleMapService } from '../../services/google-map.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  //   styleUrls: ['./map.component.scss']
})
export class MapComponent {
@ViewChild(MapInfoWindow) infoWindow: MapInfoWindow | undefined;
@Output() newLatLng = new EventEmitter<{ lat: number; lng: number }>();

  branches = signal<any[]>([]);
  center: google.maps.LatLngLiteral = { lat: 46.8182, lng: 8.2275 }; // Center of Switzerland
  zoom = 8;
  markers: BranchMapMarker[] = [];
  selectedBranch = signal<any | null>(null);

  constructor(private googleMapService: GoogleMapService) {
    this.branches.set(this.googleMapService.getDefaultBranches());
    this.updateMarkers();
  }

  updateMarkers() {
    this.markers = this.googleMapService.getMarkers(this.branches());
  }

  
onMarkerClick(marker: MapMarker, branch: any) {
    this.selectedBranch.set(branch);
    if (this.infoWindow) {
        this.infoWindow.open(marker);
    }
}

onMapClick(event: google.maps.MapMouseEvent) {
    const result = this.googleMapService.addBranchOnMapClick(this.branches(), event);
    this.branches.set(result.branches);
    this.updateMarkers();
    if (result.center) {
        this.center = result.center;
    }
    // Show details of the newly added branch
    const newBranch = (result as any).center;
    if (newBranch) {
        this.newLatLng.emit({ lat: newBranch.lat, lng: newBranch.lng });
        
        // this.selectedBranch.set(newBranch);
        // // Optionally open info window for the new branch
        // if (this.infoWindow) {
        //     this.infoWindow.open();
        // }
    }
}

  onInfoWindowClose() {}
}
