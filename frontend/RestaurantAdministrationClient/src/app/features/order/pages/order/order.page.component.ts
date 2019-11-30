import { Component, OnInit } from '@angular/core';
import { ITableStateViewModel } from '../../models/order.model';
import { Observable, of } from 'rxjs';
import { OrderService } from '../../services/order.service';
import { tap, catchError, finalize } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
    templateUrl: './order.page.component.html'
})
export class OrderPageComponent implements OnInit {

    tables: ITableStateViewModel[] = [];
    isLoading: boolean;

    constructor(
        private service: OrderService,
        private snackbar: MatSnackBar,
        private router: Router,
    ) {}

    ngOnInit() {
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getCurrentTableReservations().pipe(
            tap(res => this.tables = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    navigate(table: ITableStateViewModel) {
        if (table.state === 'Busy') {
            if (table.hasOrder) {
                this.router.navigate(['/order/edit', table.number]);
            } else {
                this.router.navigate(['/order/create', table.number]);
            }
        }
    }

    navigateDelivery() {
        this.router.navigateByUrl('/order/delivery');
    }

    navigateOrders() {
        this.router.navigateByUrl('/order/orders');
    }

}
