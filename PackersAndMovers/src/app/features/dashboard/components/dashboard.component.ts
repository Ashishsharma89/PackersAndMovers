import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  selectedItems: any[] = [];

  constructor(
    private dashboardService: DashboardService
  ) {}

  ngOnInit(): void {
    debugger;
    this.dashboardService.getStats().subscribe(stats => {
      debugger;
      console.log('Dashboard Stats:', stats);
    });
  }

  // isSelected(item: any): boolean {
  //   return this.selectedItems.some(selected => selected.name === item.name);
  // }

  // getSelectedSize(item: any): string {
  //   const found = this.selectedItems.find(selected => selected.name === item.name);
  //   return found ? found.size || '' : '';
  // }

  // onCheckboxChange(event: any, item: any) {
  //   if (event.target.checked) {
  //     this.selectedItems.push({ ...item, size: '' });
  //   } else {
  //     this.selectedItems = this.selectedItems.filter(selected => selected.name !== item.name);
  //   }
  // }

  // onSizeChange(size: string, item: any) {
  //   const found = this.selectedItems.find(selected => selected.name === item.name);
  //   if (found) {
  //     found.size = size;
  //   }
  // }

  // onSubmit() {
  //   // Handle form submission logic here
  //   const details = this.selectedItems.map(item => `${item.name}: ${item.size || 'No size selected'}`).join(', ');
  //   alert('Selected items and sizes: ' + details);
  // }
}