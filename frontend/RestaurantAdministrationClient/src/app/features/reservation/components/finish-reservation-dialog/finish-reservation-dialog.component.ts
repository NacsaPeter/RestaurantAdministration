import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITableStateViewModel } from '../../models/reservations.model';

@Component({
    templateUrl: './finish-reservation-dialog.component.html'
})
export class FinishReservationDialogComponent {

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            table: ITableStateViewModel
        }
    ) { }

}
