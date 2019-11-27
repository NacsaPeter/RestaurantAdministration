import { NgModule } from '@angular/core';
import { CoreRoutingModule } from './core-routing.module';
import { SharedModule } from '../shared/shared.module';
import { HomePageComponent } from './pages/home/home.page.component';
import { LoginPageComponent } from './pages/login/login.page.component';
import { LayoutComponent } from './components/layout/layout.component';

@NgModule({
  declarations: [
    HomePageComponent,
    LoginPageComponent,
    LayoutComponent,
  ],
  imports: [
    SharedModule,
    CoreRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class CoreModule { }
