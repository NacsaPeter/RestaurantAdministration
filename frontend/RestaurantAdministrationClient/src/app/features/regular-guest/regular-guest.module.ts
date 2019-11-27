import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegularGuestRoutingModule } from './regular-guest-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    RegularGuestRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class RegularGuestModule { }
