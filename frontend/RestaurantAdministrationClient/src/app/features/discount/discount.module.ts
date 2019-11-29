import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DiscountRoutingModule } from './discount-routing.module';
import { DiscountPageComponent } from './pages/discount.page.component';

@NgModule({
  declarations: [
    DiscountPageComponent,
  ],
  imports: [
    SharedModule,
    DiscountRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class DiscountModule { }
