import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DriverGridComponent } from './driver-grid/driver-grid.component';
import { UpdateDriverLocationComponent } from './update-driver-location/update-driver-location.component';

const routes: Routes = [
  { path: 'list', component: DriverGridComponent },
  { path: 'update-location', component: UpdateDriverLocationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule {}
