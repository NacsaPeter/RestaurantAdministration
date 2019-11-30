import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICreateUserViewModel } from '../models/user.model';

@Component({
    templateUrl: './user-dialog.component.html'
})
export class UserDialogComponent {

    title: string;
    buttonText: string;
    user: ICreateUserViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            isNew: boolean;
        }
    ) {
        if (data.isNew) {
            this.title = 'Add new user';
            this.buttonText = 'Add';
            this.user = {
                userName: null,
                email: null,
                role: null,
                password: null
            };
        }
    }

}
