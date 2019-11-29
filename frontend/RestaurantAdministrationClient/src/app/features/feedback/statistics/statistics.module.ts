import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { StatisticsRoutingModule } from './statistics-routing.module';
import { StatisticsPageComponent } from './pages/statistics.page.component';
import { StatisticsService } from './services/statistics.service';

@NgModule({
  declarations: [
      StatisticsPageComponent,
  ],
  imports: [
    SharedModule,
    StatisticsRoutingModule,
  ],
  providers: [
    StatisticsService,
  ],
  entryComponents: []
})
export class StatisticsModule { }
