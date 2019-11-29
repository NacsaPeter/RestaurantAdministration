import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserRoutingModule } from './user-routing.module';
import { UserPageComponent } from './pages/user.page.component';

@NgModule({
  declarations: [
    UserPageComponent,
  ],
  imports: [
    SharedModule,
    UserRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class UserModule { }
