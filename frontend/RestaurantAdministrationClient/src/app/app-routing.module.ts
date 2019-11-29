import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './core/pages/login/login.page.component';
import { LayoutComponent } from './core/components/layout/layout.component';
import { CoreModule } from './core/core.module';

const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  {
    path: '',
    component: LayoutComponent,
    loadChildren: () => CoreModule,
  },
  {
    path: 'discount',
    component: LayoutComponent,
    loadChildren: () => import('./features/discount/discount.module').then(m => m.DiscountModule)
  },
  {
    path: 'feedback',
    loadChildren: () => import('./features/feedback/feedback/feedback.module').then(m => m.FeedbackModule)
  },
  {
    path: 'statistics',
    component: LayoutComponent,
    loadChildren: () => import('./features/feedback/statistics/statistics.module').then(m => m.StatisticsModule)
  },
  {
    path: 'menu',
    component: LayoutComponent,
    loadChildren: () => import('./features/menu/menu.module').then(m => m.MenuModule)
  },
  {
    path: 'order',
    component: LayoutComponent,
    loadChildren: () => import('./features/order/order.module').then(m => m.OrderModule)
  },
  {
    path: 'regularguest',
    component: LayoutComponent,
    loadChildren: () => import('./features/regular-guest/regular-guest.module').then(m => m.RegularGuestModule)
  },
  {
    path: 'reservation',
    component: LayoutComponent,
    loadChildren: () => import('./features/reservation/reservation.module').then(m => m.ReservationModule)
  },
  {
    path: 'table',
    component: LayoutComponent,
    loadChildren: () => import('./features/table/table.module').then(m => m.TableModule)
  },
  {
    path: 'user',
    component: LayoutComponent,
    loadChildren: () => import('./features/user/user.module').then(m => m.UserModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
