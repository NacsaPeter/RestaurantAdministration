import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OrderRoutingModule } from './order-routing.module';
import { OrderPageComponent } from './pages/order/order.page.component';
import { OrderService } from './services/order.service';
import { DeliveryPageComponent } from './pages/delivery/delivery.page.component';
import { CreateOrderPageComponent } from './pages/create-order/create-order.page.component';
import { EditOrderPageComponent } from './pages/edit-order/edit-order.page.component';
import { OrdersListPageComponent } from './pages/orders-list/orders-list.component';
import { PayPageComponent } from './pages/pay/pay.component.page';
import { PaymentService } from './services/payment.service';
import { GenerateInvoiceDialogComponent } from './components/generate-invoice-dialog.component';

@NgModule({
  declarations: [
    OrderPageComponent,
    DeliveryPageComponent,
    CreateOrderPageComponent,
    EditOrderPageComponent,
    OrdersListPageComponent,
    PayPageComponent,
    GenerateInvoiceDialogComponent,
  ],
  imports: [
    SharedModule,
    OrderRoutingModule,
  ],
  providers: [
    OrderService,
    PaymentService,
  ],
  entryComponents: [
    GenerateInvoiceDialogComponent,
  ]
})
export class OrderModule { }
