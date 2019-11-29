import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegularGuestRoutingModule } from './regular-guest-routing.module';
import { RegularGuestPageComponent } from './pages/regular-guest.page.component';

@NgModule({
  declarations: [
    RegularGuestPageComponent,
  ],
  imports: [
    SharedModule,
    RegularGuestRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class RegularGuestModule { }
