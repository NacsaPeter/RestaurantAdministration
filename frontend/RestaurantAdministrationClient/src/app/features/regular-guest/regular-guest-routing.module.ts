import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegularGuestPageComponent } from './pages/regular-guest.page.component';

const routes: Routes = [
  { path: '', component: RegularGuestPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegularGuestRoutingModule { }
