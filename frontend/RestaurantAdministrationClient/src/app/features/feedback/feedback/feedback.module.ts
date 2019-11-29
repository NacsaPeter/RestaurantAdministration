import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeedbackRoutingModule } from './feedback-routing.module';
import { FeedbackPageComponent } from './pages/feedback.page.component';
import { RatingModule } from 'ng-starrating';
import { FeedbackService } from './services/feedback.service';

@NgModule({
  declarations: [
    FeedbackPageComponent,
  ],
  imports: [
    SharedModule,
    FeedbackRoutingModule,
    RatingModule,
  ],
  providers: [
    FeedbackService,
  ],
  entryComponents: []
})
export class FeedbackModule { }
