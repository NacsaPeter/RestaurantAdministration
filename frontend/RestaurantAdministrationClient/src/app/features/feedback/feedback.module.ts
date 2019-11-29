import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeedbackRoutingModule } from './feedback-routing.module';
import { FeedbackPageComponent } from './pages/feedback.page.component';

@NgModule({
  declarations: [
    FeedbackPageComponent,
  ],
  imports: [
    SharedModule,
    FeedbackRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class FeedbackModule { }
