import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';
import {
    ICreateTableReservationViewModel,
    ITableReservationViewModel,
    ITableStateViewModel,
    ITableViewModel
} from '../models/reservations.model';

@Injectable()
export class ReservationService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    createTableReservation(reservation: ICreateTableReservationViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/table/reservation`, reservation);
    }

    createCurrentTableReservation(table: ITableStateViewModel, hours: number): Observable<any> {
        const dto = { table, hours };
        return this.http.post(`${this.baseUrl}/api/table/reservation/table`, dto);
    }

    getUpcomingTableReservations(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/upcoming`);
    }

    getFinishedTableReservations(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/finished`);
    }

    getCurrentTableReservations(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/current`);
    }

    removeTableReservations(reservation: ITableReservationViewModel): Observable<any> {
        return this.http.delete(`${this.baseUrl}/api/table/reservation/${reservation.id}`);
    }

    finishReservation(reservation: ITableReservationViewModel): Observable<any> {
        return this.http.put(`${this.baseUrl}/api/table/reservation/finish/${reservation.id}`, {});
    }

    getCurrentTableReservation(table: ITableStateViewModel): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table/reservation/table/${table.id}`);
    }

}
