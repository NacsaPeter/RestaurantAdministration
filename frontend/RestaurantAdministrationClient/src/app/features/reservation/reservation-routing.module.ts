import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReservationPageComponent } from './pages/reservation.page.component';

const routes: Routes = [
  { path: '', component: ReservationPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservationRoutingModule { }
