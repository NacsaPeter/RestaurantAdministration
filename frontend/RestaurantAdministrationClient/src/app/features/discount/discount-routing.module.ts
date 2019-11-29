import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DiscountPageComponent } from './pages/discount.page.component';

const routes: Routes = [
  { path: '', component: DiscountPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiscountRoutingModule { }
