import { Component, Inject } from '@angular/core';
import { ICreateTableReservationViewModel } from '../../models/reservations.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './reservation-dialog.component.html'
})
export class ReservationDialogComponent {

    title: string;
    buttonText: string;
    reservation: ICreateTableReservationViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            isNew: boolean;
            reservation?: ICreateTableReservationViewModel;
        }
    ) {
        if (data.isNew) {
            this.title = 'Add new reservation';
            this.buttonText = 'Add';
            this.reservation = {
                numberOfSeats: null,
                date: null,
                hours: 3,
                name: null
            };
        } else {
            this.title = 'Edit reservation for' + data.reservation.name;
            this.buttonText = 'Save';
            this.reservation = data.reservation;
        }
    }

}
