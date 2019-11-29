import { Component, Input, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './remove-item-dialog.component.html'
})
export class RemoveItemDialogComponent {

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            text: string;
            item: any;
        }
    ) { }

}
