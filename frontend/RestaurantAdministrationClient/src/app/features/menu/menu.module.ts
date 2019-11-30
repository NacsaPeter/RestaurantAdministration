import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { MenuRoutingModule } from './menu-routing.module';
import { MenuPageComponent } from './pages/menu.page.component';
import { MenuService } from './services/menu.service';
import { MenuDialogComponent } from './components/menu-dialog.component';

@NgModule({
  declarations: [
    MenuPageComponent,
    MenuDialogComponent
  ],
  imports: [
    SharedModule,
    MenuRoutingModule,
  ],
  providers: [
    MenuService
  ],
  entryComponents: [
    MenuDialogComponent
  ]
})
export class MenuModule { }
