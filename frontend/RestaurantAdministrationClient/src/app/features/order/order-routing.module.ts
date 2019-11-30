import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderPageComponent } from './pages/order/order.page.component';
import { DeliveryPageComponent } from './pages/delivery/delivery.page.component';
import { CreateOrderPageComponent } from './pages/create-order/create-order.page.component';
import { EditOrderPageComponent } from './pages/edit-order/edit-order.page.component';
import { OrdersListPageComponent } from './pages/orders-list/orders-list.component';

const routes: Routes = [
  { path: '', component: OrderPageComponent },
  { path: 'delivery', component: DeliveryPageComponent },
  { path: 'create/:number', component: CreateOrderPageComponent },
  { path: 'edit/:number', component: EditOrderPageComponent },
  { path: 'orders', component: OrdersListPageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
