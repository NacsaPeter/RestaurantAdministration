import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { TableRoutingModule } from './table-routing.module';
import { TablePageComponent } from './pages/table.page.component';
import { TableDialogComponent } from './components/table-dialog.component';
import { TableService } from './services/table.service';

@NgModule({
  declarations: [
    TablePageComponent,
    TableDialogComponent,
  ],
  imports: [
    SharedModule,
    TableRoutingModule,
  ],
  providers: [
    TableService,
  ],
  entryComponents: [
    TableDialogComponent,
  ]
})
export class TableModule { }
