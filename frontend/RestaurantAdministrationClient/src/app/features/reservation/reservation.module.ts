import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReservationRoutingModule } from './reservation-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    ReservationRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class ReservationModule { }
