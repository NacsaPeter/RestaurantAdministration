import { Component } from '@angular/core';
import { IDiscountViewModel } from '../models/discount.model';
import { DiscountService } from '../services/discount.service';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Observable, of } from 'rxjs';
import { tap, finalize, catchError, filter, mergeMap, concatMap } from 'rxjs/operators';
import { DiscountDialogComponent } from '../components/discount-dialog.component';

@Component({
    templateUrl: './discount.page.component.html'
})
export class DiscountPageComponent {

    displayedColumns: string[] = ['code', 'value', 'type', 'isUsed'];
    discounts: IDiscountViewModel[] = [];
    isLoading: boolean;

    constructor(
        private service: DiscountService,
        private snackbar: MatSnackBar,
        private dialog: MatDialog,
    ){}

    ngOnInit(){
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getDiscounts().pipe(
            tap(res => this.discounts = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    addDiscount(){
        const dialogRef = this.dialog.open(DiscountDialogComponent, {
            data: {  }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createDiscount(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new discount.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add discount.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }
}
