import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { FeedbackRoutingModule } from './feedback-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    FeedbackRoutingModule,
  ],
  providers: [],
  entryComponents: []
})
export class FeedbackModule { }
