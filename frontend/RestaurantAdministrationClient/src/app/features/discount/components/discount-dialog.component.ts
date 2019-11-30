import { Component, Inject } from '@angular/core';
import { IDiscountViewModel } from '../models/discount.model';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
    templateUrl: './discount-dialog.component.html'
})
export class DiscountDialogComponent {

    title: string;
    buttonText: string;
    discount: IDiscountViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {}
    ){
        this.title = 'Add new discount';
        this.buttonText = 'Add';
        this.discount = {
            code: null,
            value: null,
            type: null,
            isUsed: false
        };
    }
}