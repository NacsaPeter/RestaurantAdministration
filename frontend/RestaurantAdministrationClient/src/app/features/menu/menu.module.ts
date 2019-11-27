import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { MenuRoutingModule } from './menu-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    MenuRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class MenuModule { }
