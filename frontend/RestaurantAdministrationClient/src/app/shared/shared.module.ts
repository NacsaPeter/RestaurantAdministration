import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DialogComponent } from './components/dialog/dialog.component';
import { RemoveItemDialogComponent } from './components/remove-item/remove-item-dialog.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DialogComponent,
    RemoveItemDialogComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatIconModule,
    MatPaginatorModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatSnackBarModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatIconModule,
    MatPaginatorModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatSnackBarModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    DialogComponent,
    RemoveItemDialogComponent,
  ],
  entryComponents: [
    RemoveItemDialogComponent,
  ]
})
export class SharedModule { }
