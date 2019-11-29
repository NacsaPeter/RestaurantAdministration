import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OrderRoutingModule } from './order-routing.module';
import { OrderPageComponent } from './pages/order.page.component';

@NgModule({
  declarations: [
    OrderPageComponent,
  ],
  imports: [
    SharedModule,
    OrderRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class OrderModule { }
