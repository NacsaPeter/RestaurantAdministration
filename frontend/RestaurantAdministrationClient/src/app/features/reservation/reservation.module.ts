import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReservationRoutingModule } from './reservation-routing.module';
import { ReservationPageComponent } from './pages/reservation.page.component';

@NgModule({
  declarations: [
    ReservationPageComponent,
  ],
  imports: [
    SharedModule,
    ReservationRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class ReservationModule { }
