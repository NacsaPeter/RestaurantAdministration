import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { MenuRoutingModule } from './menu-routing.module';
import { MenuPageComponent } from './pages/menu.page.component';

@NgModule({
  declarations: [
    MenuPageComponent,
  ],
  imports: [
    SharedModule,
    MenuRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class MenuModule { }
