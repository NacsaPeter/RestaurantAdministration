import { Component, OnInit } from '@angular/core';
import { IOrderViewModel, IOrderItemViewModel } from '../../models/order.model';
import { Observable, of } from 'rxjs';
import { OrderService } from '../../services/order.service';
import { tap, catchError, finalize, concatMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ICategoryViewModel } from 'src/app/features/menu/models/category.model';
import { IMenuItemViewModel } from 'src/app/features/menu/models/menu-item.model';

@Component({
    templateUrl: './delivery.page.component.html'
})
export class DeliveryPageComponent implements OnInit {

    hasAdd: false;
    isLoading: boolean;
    categories: ICategoryViewModel[] = [];
    displayedColumns: string[] = ['name', 'price'];
    order: IOrderViewModel = {
        isDelivery: true,
        address: null,
        name: null,
        phone: null,
        orderItems: []
    };

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
        return this.service.getCategories().pipe(
            tap(res => this.categories = res),
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
        this.service.createOrder(this.order).pipe(
            concatMap(() => of(this.snackbar.open('Added new order.', 'Close'))),
            concatMap(() => this.router.navigateByUrl('/order')),
            catchError(err => of(this.snackbar.open('Could not save order.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

}
