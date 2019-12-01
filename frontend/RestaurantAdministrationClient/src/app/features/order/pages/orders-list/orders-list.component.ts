import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar } from '@angular/material';
import { IOrderViewModel } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
import { tap, catchError, finalize } from 'rxjs/operators';
import { of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    templateUrl: './orders-list.page.component.html'
})
export class OrdersListPageComponent implements OnInit {

    isLoading: boolean;

    displayedColumns: string[] = ['date', 'details1', 'details2', 'details3', 'isPaid', 'pay'];
    dataSource = new MatTableDataSource<IOrderViewModel>([]);

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) sort: MatSort;

    constructor(
        private snackbar: MatSnackBar,
        private service: OrderService,
        private router: Router
    ) {}

    ngOnInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.isLoading = true;
        this.service.getOrders().pipe(
            tap(res => this.dataSource = new MatTableDataSource<IOrderViewModel>(res)),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    pay(order: IOrderViewModel) {
        this.router.navigate(['/order/pay', order.id]);
    }

}
