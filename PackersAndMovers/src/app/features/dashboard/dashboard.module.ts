import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './components/dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardService } from './services/dashboard.service';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from '../../core/core.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [CommonModule, CoreModule,
   HttpClientModule, DashboardRoutingModule],
  providers: [DashboardService],
})
export class DashboardModule {}
