import { NgModule, InjectionToken } from '@angular/core';
import { CoreRoutingModule } from './core-routing.module';
import { SharedModule } from '../shared/shared.module';
import { HomePageComponent } from './pages/home/home.page.component';
import { LoginPageComponent } from './pages/login/login.page.component';
import { LayoutComponent } from './components/layout/layout.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { environment } from 'src/environments/environment';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@NgModule({
  declarations: [
    HomePageComponent,
    LoginPageComponent,
    LayoutComponent,
    SidebarComponent,
  ],
  imports: [
    SharedModule,
    CoreRoutingModule,
  ],
  providers: [
    { provide: API_BASE_URL, useValue: environment.apiBaseUrl },
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2000 }}
  ],
  entryComponents: []
})
export class CoreModule { }
