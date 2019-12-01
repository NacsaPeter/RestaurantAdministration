import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';
import { IOrderViewModel } from '../models/order.model';
import { ITableReservationViewModel } from '../../reservation/models/reservations.model';

@Injectable()
export class OrderService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    getCurrentTableReservations(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/current`);
    }

    createOrder(order: IOrderViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/order`, order);
    }

    getOrderByTableReservationId(reservation: ITableReservationViewModel): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/order/${reservation.id}`);
    }

    editOrder(order: IOrderViewModel): Observable<any> {
        return this.http.put(`${this.baseUrl}/api/order`, order);
    }

    getCurrentTableReservation(tableNumber: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/table/${tableNumber}`);
    }

    getCategories(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/menu/categories`);
    }

    getOrders(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/order`);
    }

    getOrderById(orderId: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/order/order/${orderId}`);
    }

    getDiscountByCode(code: string): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/discount/${code}`);
    }

    getRegularGuests(name: string): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/regularguest/${name}`);
    }

}
