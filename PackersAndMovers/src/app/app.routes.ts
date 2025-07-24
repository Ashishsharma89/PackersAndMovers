import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'customer',
    loadChildren: () => import('./features/customer/customer.module').then(m => m.CustomerModule)
  },
  {
    path: 'driver',
    loadChildren: () => import('./features/driver/driver.module').then(m => m.DriverModule)
  },

    // {
    //     path: '',
    //     // canActivate: [AuthGuard],
    //     children: [
    //         { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    //         { path: 'dashboard', loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule) },
    //         { path: 'customer', loadChildren: () => import('./features/customer/customer.module').then(m => m.CustomerModule) },
    //         { path: 'driver', loadChildren: () => import('./features/driver/driver.module').then(m => m.DriverModule) },
    //     ]
    // },
    // {
    //     path: '',
    //     component: OuterLayoutComponent,
    //     children: [
    //         { path: 'map', loadChildren: () => import('./features/transportation/transportation.module').then(m => m.TransportationModule) },
    //     ]
    // },
    // Redirect empty path to dashboard at the top level
    { path: '', redirectTo: 'auth/login', pathMatch: 'full' },
    { path: '**', redirectTo: 'auth/login' }
];
