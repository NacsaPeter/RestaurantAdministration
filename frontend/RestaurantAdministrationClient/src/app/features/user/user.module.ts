import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserRoutingModule } from './user-routing.module';
import { UserPageComponent } from './pages/user.page.component';
import { UserService } from './services/user.service';
import { UserDialogComponent } from './components/user-dialog.component';

@NgModule({
  declarations: [
    UserPageComponent,
    UserDialogComponent,
  ],
  imports: [
    SharedModule,
    UserRoutingModule,
  ],
  providers: [
    UserService,
  ],
  entryComponents: [
    UserDialogComponent
  ]
})
export class UserModule { }
