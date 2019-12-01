import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { IGenerateInvoiceViewModel } from '../models/payment.model';

@Component({
    templateUrl: './generate-invoice-dialog.component.html'
})
export class GenerateInvoiceDialogComponent {

    invoiceData: IGenerateInvoiceViewModel = {
        orderId: null,
        billToName: null,
        billToStreetAddress: null,
        billToCity: null,
        billToCountry: null,
        billToZIP: null,
        billToPhone: null,
        discount: null,
    };

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            orderId: number;
            discount: number;
        }
    ) {
        this.invoiceData.orderId = data.orderId;
        this.invoiceData.discount = data.discount;
    }
}
