import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReservationRoutingModule } from './reservation-routing.module';
import { ReservationPageComponent } from './pages/reservation.page.component';
import { CurrentReservationsComponent } from './components/current-reservations/current-reservations.component';
import { FinishedReservationsComponent } from './components/finished-reservations/finished-reservations.component';
import { UpcomingReservationsComponent } from './components/upcoming-reservations/upcoming-reservations.component';
import { ReservationService } from './services/reservation.service';
import { ReservationDialogComponent } from './components/reservation-dialog/reservation-dialog.component';
import { FinishReservationDialogComponent } from './components/finish-reservation-dialog/finish-reservation-dialog.component';
import { CurrentReservationDialogComponent } from './components/current-reservation-dialog/current-reservation-dialog.component';

@NgModule({
  declarations: [
    ReservationPageComponent,
    CurrentReservationsComponent,
    FinishedReservationsComponent,
    UpcomingReservationsComponent,
    ReservationDialogComponent,
    FinishReservationDialogComponent,
    CurrentReservationDialogComponent,
  ],
  imports: [
    SharedModule,
    ReservationRoutingModule,
  ],
  providers: [
    ReservationService,
  ],
  entryComponents: [
    ReservationDialogComponent,
    FinishReservationDialogComponent,
    CurrentReservationDialogComponent,
  ]
})
export class ReservationModule { }
