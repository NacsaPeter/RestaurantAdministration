import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { OrderService } from '../../services/order.service';
import { tap, catchError, finalize, mergeMap, concatMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ITableReservationViewModel } from 'src/app/features/reservation/models/reservations.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ICategoryViewModel } from 'src/app/features/menu/models/category.model';
import { IOrderViewModel, IOrderItemViewModel } from '../../models/order.model';
import { IMenuItemViewModel } from 'src/app/features/menu/models/menu-item.model';

@Component({
    templateUrl: './edit-order.page.component.html'
})
export class EditOrderPageComponent implements OnInit {

    reservation: ITableReservationViewModel;
    tableNumber: number;
    hasAdd: false;
    isLoading: boolean;
    categories: ICategoryViewModel[] = [];
    displayedColumns: string[] = ['name', 'price'];
    order: IOrderViewModel = {
        tableReservationId: null,
        isDelivery: false,
        address: null,
        name: null,
        phone: null,
        orderItems: []
    };

    constructor(
        private service: OrderService,
        private snackbar: MatSnackBar,
        private route: ActivatedRoute,
        private router: Router,
    ) {}

    ngOnInit() {
        this.tableNumber = +this.route.snapshot.paramMap.get('number');
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getCurrentTableReservation(this.tableNumber).pipe(
            tap(res =>  { this.reservation = res; this.order.tableReservationId = this.reservation.id; }),
            mergeMap(() => this.getMenu()),
            mergeMap(() => this.getOrder()),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    getMenu(): Observable<any> {
        this.isLoading = true;
        return this.service.getCategories().pipe(
            tap(res => this.categories = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    getOrder(): Observable<any> {
        this.isLoading = true;
        return this.service.getOrderByTableReservationId(this.reservation).pipe(
            tap(res => this.order = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    removeOrderItem(orderItem: IOrderItemViewModel) {
        const index = this.order.orderItems.indexOf(orderItem);
        this.order.orderItems.splice(index, 1);
    }

    cancel() {
        this.router.navigateByUrl('/order');
    }

    addItem(menuItem: IMenuItemViewModel) {
        const item: IOrderItemViewModel = {
            numberOfItems: 1,
            notes: null,
            menuItemId: menuItem.id,
            menuItemName: menuItem.name
        };
        this.order.orderItems.push(item);
        this.hasAdd = false;
    }

    save() {
        this.isLoading = true;
        this.service.editOrder(this.order).pipe(
            concatMap(() => of(this.snackbar.open('Edited order.', 'Close'))),
            concatMap(() => this.router.navigateByUrl('/order')),
            catchError(err => of(this.snackbar.open('Could not save order.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

}
