import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DiscountRoutingModule } from './discount-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    DiscountRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class DiscountModule { }
