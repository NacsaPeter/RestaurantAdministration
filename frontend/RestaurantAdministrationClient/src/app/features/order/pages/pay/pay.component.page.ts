import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { MatSnackBar, MatDialog } from '@angular/material';
import { OrderService } from '../../services/order.service';
import { IOrderViewModel } from '../../models/order.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap, catchError, finalize, concatMap, filter, mergeMap } from 'rxjs/operators';
import { IRegularGuestViewModel } from 'src/app/features/regular-guest/models/regular-guest.model';
import { IDiscountViewModel } from 'src/app/features/discount/models/discount.model';
import { IGeneratePaymentResultViewModel, IPaymentResultViewModel, IInvoiceViewModel } from '../../models/payment.model';
import { PaymentService } from '../../services/payment.service';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
import { GenerateInvoiceDialogComponent } from '../../components/generate-invoice-dialog.component';

@Component({
    templateUrl: './pay.page.component.html'
})
export class PayPageComponent implements OnInit {

    @ViewChild('title', { static: false }) title: ElementRef;
    @ViewChild('issuer', { static: false }) issuer: ElementRef;
    @ViewChild('billTo', { static: false }) billTo: ElementRef;
    @ViewChild('sum', { static: false }) sum: ElementRef;
    @ViewChild('issuerSig', { static: false }) issuerSig: ElementRef;
    @ViewChild('billToSig', { static: false }) billToSig: ElementRef;

    hasDownload: boolean;
    result: IPaymentResultViewModel;
    invoice: IInvoiceViewModel = {
        id: null,
        date: null,
        companyName: null,
        streetAddress: null,
        cityCountryZIP: null,
        phone: null,
        billToName: null,
        billToStreetAddress: null,
        billToCityCountryZIP: null,
        billToPhone: null,
        netSum: null,
        vatSum: null,
        discount: null,
        priceSum: null,
        invoiceItems: []
    };
    isLoading: boolean;
    displayedColumns: string[] = ['name', 'birthDay', 'address'];
    order: IOrderViewModel = {
        tableReservation: {
            from: null,
            to: null,
            name: null,
            table: {
                id: null,
                number: null,
                numberOfSeats: null,
            }
        },
        isDelivery: null,
        address: null,
        name: null,
        phone: null,
        orderItems: []
    };

    hasRegularGuest: boolean;
    regularGuest: IRegularGuestViewModel = {
        name: null,
        birthDay: null,
        address: null
    };
    regularGuests: IRegularGuestViewModel[] = [];

    hasDiscount: boolean;
    discount: IDiscountViewModel = {
        code: null,
        value: null,
        type: null,
        isUsed: null,
    };

    constructor(
        private snackbar: MatSnackBar,
        private service: OrderService,
        private paymentService: PaymentService,
        private route: ActivatedRoute,
        private router: Router,
        private dialog: MatDialog,
    ) { }

    ngOnInit() {
        this.order.id = +this.route.snapshot.paramMap.get('orderid');
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getOrderById(this.order.id).pipe(
            tap(res => this.order = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    getDiscount() {
        this.isLoading = true;
        this.service.getDiscountByCode(this.discount.code).pipe(
            tap(res => { this.discount = res; this.hasDiscount = !this.discount.isUsed; }),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    removeDiscount() {
        this.hasDiscount = false;
        this.discount.code = null;
    }

    getRegularGuests() {
        this.isLoading = true;
        this.service.getRegularGuests(this.regularGuest.name).pipe(
            tap(res => this.regularGuests = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    setRegularGuest(regularGuest: IRegularGuestViewModel) {
        this.regularGuest = regularGuest;
        this.hasRegularGuest = true;
    }

    removeRegularGuest() {
        this.hasRegularGuest = false;
        this.regularGuest.name = null;
        this.regularGuests = [];
    }

    generatePaymentResult() {
        const dto: IGeneratePaymentResultViewModel = {
            order: this.order,
            regularGuest: this.hasRegularGuest ? this.regularGuest : null,
            discount: this.hasDiscount ? this.discount : null
        };
        this.isLoading = true;
        this.paymentService.generatePayment(dto).pipe(
            tap(res => this.result = res),
            catchError(err => of(this.snackbar.open('Could not generate payment.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    pay() {
        this.isLoading = true;
        this.paymentService.pay(this.order).pipe(
            concatMap(() => of(this.snackbar.open('Payment was succesfull!', 'Close'))),
            concatMap(() => this.router.navigateByUrl('/order/orders')),
            catchError(err => of(this.snackbar.open('Could not finish payment.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    generateInvoice() {
        const dialogRef = this.dialog.open(GenerateInvoiceDialogComponent, {
            data: {
                orderId: this.order.id,
                discount: this.result.fullDiscount
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.paymentService.generateInvoice(item)),
            tap(res => { this.invoice = res; this.hasDownload = true; }),
            concatMap(() => of(this.snackbar.open('Generated invoice.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not generate invoice.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    generatePdf() {
        const doc = new jsPDF();

        const height = 10 + this.order.orderItems.length * 10;

        doc.fromHTML(this.title.nativeElement.innerHTML, 15, 15);
        doc.fromHTML(this.issuer.nativeElement.innerHTML, 15, 45);
        doc.fromHTML(this.billTo.nativeElement.innerHTML, 100, 45);
        doc.autoTable({ startY: 100, html: '#my-table' });
        doc.fromHTML(this.sum.nativeElement.innerHTML, 100, 100 + height);
        doc.fromHTML(this.issuerSig.nativeElement.innerHTML, 40, 160 + height);
        doc.fromHTML(this.billToSig.nativeElement.innerHTML, 130, 160 + height);

        doc.save(`${this.order.date}_order_${this.order.id}.pdf`);
    }

}
