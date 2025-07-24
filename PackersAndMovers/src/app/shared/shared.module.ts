import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { MapComponent } from './components/map/map.component';
import { GoogleMapService } from './services/google-map.service';


@NgModule({
  declarations: [
    SidebarComponent,
    MapComponent
  ],
  imports: [CommonModule],
  exports: [
    SidebarComponent,
    MapComponent
  ],
  providers: [GoogleMapService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA], // No schemas needed
  // No schemas needed
})
export class SharedModule {}
