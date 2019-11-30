import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DiscountRoutingModule } from './discount-routing.module';
import { DiscountPageComponent } from './pages/discount.page.component';
import { DiscountService } from './services/discount.service';
import { DiscountDialogComponent } from './components/discount-dialog.component';

@NgModule({
  declarations: [
    DiscountPageComponent,
    DiscountDialogComponent,
  ],
  imports: [
    SharedModule,
    DiscountRoutingModule,
  ],
  providers: [
    DiscountService,
  ],
  entryComponents: [
    DiscountDialogComponent,
  ]
})
export class DiscountModule { }
