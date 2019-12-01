import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './core/pages/login/login.page.component';
import { LayoutComponent } from './core/components/layout/layout.component';
import { AuthGuard } from './core/guards/auth.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  {
    path: '', redirectTo: 'reservation', pathMatch: 'full'
  },
  {
    path: 'discount',
    component: LayoutComponent,
    loadChildren: () => import('./features/discount/discount.module').then(m => m.DiscountModule),
    canActivate: [AdminGuard],
    canActivateChild: [AdminGuard],
  },
  {
    path: 'feedback',
    loadChildren: () => import('./features/feedback/feedback/feedback.module').then(m => m.FeedbackModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
  {
    path: 'statistics',
    component: LayoutComponent,
    loadChildren: () => import('./features/feedback/statistics/statistics.module').then(m => m.StatisticsModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
  {
    path: 'menu',
    component: LayoutComponent,
    loadChildren: () => import('./features/menu/menu.module').then(m => m.MenuModule),
    canActivate: [AdminGuard],
    canActivateChild: [AdminGuard],
  },
  {
    path: 'order',
    component: LayoutComponent,
    loadChildren: () => import('./features/order/order.module').then(m => m.OrderModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
  {
    path: 'regularguest',
    component: LayoutComponent,
    loadChildren: () => import('./features/regular-guest/regular-guest.module').then(m => m.RegularGuestModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
  {
    path: 'reservation',
    component: LayoutComponent,
    loadChildren: () => import('./features/reservation/reservation.module').then(m => m.ReservationModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
  {
    path: 'table',
    component: LayoutComponent,
    loadChildren: () => import('./features/table/table.module').then(m => m.TableModule),
    canActivate: [AdminGuard],
    canActivateChild: [AdminGuard],
  },
  {
    path: 'user',
    component: LayoutComponent,
    loadChildren: () => import('./features/user/user.module').then(m => m.UserModule),
    canActivate: [AdminGuard],
    canActivateChild: [AdminGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
