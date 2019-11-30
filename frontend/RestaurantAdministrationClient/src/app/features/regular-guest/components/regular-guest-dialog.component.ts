import { Component, Inject } from '@angular/core';
import { IRegularGuestViewModel } from '../models/regular-guest.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './regular-guest-dialog.component.html'
})
export class RegularGuestDialogComponent {

    title: string;
    buttonText: string;
    regularGuest: IRegularGuestViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {}
    ){
        this.title = 'Add new regular guest';
        this.buttonText = 'Add';
        this.regularGuest = {
            name: null,
            birthDay: null,
            address: null
        };
    }
}