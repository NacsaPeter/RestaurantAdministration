import { Component, Input, Inject } from '@angular/core';
import { ITableViewModel } from '../models/table.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './table-dialog.component.html'
})
export class TableDialogComponent {

    title: string;
    buttonText: string;
    table: ITableViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            isNew: boolean;
            table?: ITableViewModel;
        }
    ) {
        if (data.isNew) {
            this.title = 'Add new table';
            this.buttonText = 'Add';
            this.table = {
                number: null,
                numberOfSeats: null
            };
        } else {
            this.title = 'Edit table No.' + data.table.number;
            this.buttonText = 'Save';
            this.table = data.table;
        }
    }

}
