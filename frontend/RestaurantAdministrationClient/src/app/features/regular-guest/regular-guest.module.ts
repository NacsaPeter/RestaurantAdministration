import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegularGuestRoutingModule } from './regular-guest-routing.module';
import { RegularGuestPageComponent } from './pages/regular-guest.page.component';
import { RegularGuestService } from './services/regular-guest.service';
import { RegularGuestDialogComponent } from './components/regular-guest-dialog.component';

@NgModule({
  declarations: [
    RegularGuestPageComponent,
    RegularGuestDialogComponent,
  ],
  imports: [
    SharedModule,
    RegularGuestRoutingModule,
  ],
  providers: [
    RegularGuestService
  ],
  entryComponents: [
    RegularGuestDialogComponent,
  ]
})
export class RegularGuestModule { }
