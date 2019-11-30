import { Component, Inject } from '@angular/core';
import { ITableStateViewModel } from '../../models/reservations.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './current-reservation-dialog.component.html'
})
export class CurrentReservationDialogComponent {

    title: string;
    buttonText: string;
    hours = 3;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            table: ITableStateViewModel
        }
    ) {
        this.title = 'Reserve table No. ' + data.table.number;
        this.buttonText = 'Add';
    }
}
