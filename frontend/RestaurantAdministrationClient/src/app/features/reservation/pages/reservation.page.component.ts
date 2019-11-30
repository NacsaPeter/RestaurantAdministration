import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ReservationService } from '../services/reservation.service';
import { MatDialog } from '@angular/material/dialog';
import { ReservationDialogComponent } from '../components/reservation-dialog/reservation-dialog.component';
import { tap, filter, mergeMap, concatMap, catchError, finalize } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { ITableReservationViewModel, ITableStateViewModel } from '../models/reservations.model';
import { RemoveItemDialogComponent } from 'src/app/shared/components/remove-item/remove-item-dialog.component';
import { FinishReservationDialogComponent } from '../components/finish-reservation-dialog/finish-reservation-dialog.component';
import { CurrentReservationDialogComponent } from '../components/current-reservation-dialog/current-reservation-dialog.component';

@Component({
    templateUrl: './reservation.page.component.html'
})
export class ReservationPageComponent implements OnInit {

    isLoading: boolean;
    upcomingTableReservations: ITableReservationViewModel[] = [];
    finishedTableReservations: ITableReservationViewModel[] = [];
    currentTableReservations: ITableStateViewModel[] = [];

    constructor(
        private snackbar: MatSnackBar,
        private service: ReservationService,
        private dialog: MatDialog,
    ) { }

    ngOnInit() {
        this.fetchData().subscribe();
    }

    addReservation() {
        const dialogRef = this.dialog.open(ReservationDialogComponent, {
            data: { isNew: true }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createTableReservation(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new reservation.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add reservation.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getUpcomingTableReservations().pipe(
            tap(res => this.upcomingTableReservations = res),
            mergeMap(() => this.getFinishedReservations()),
            mergeMap(() => this.getCurrentReservations()),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    getFinishedReservations(): Observable<any> {
        this.isLoading = true;
        return this.service.getFinishedTableReservations().pipe(
            tap(res => this.finishedTableReservations = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    getCurrentReservations(): Observable<any> {
        this.isLoading = true;
        return this.service.getCurrentTableReservations().pipe(
            tap(res => this.currentTableReservations = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    removeReservation(reservation: ITableReservationViewModel) {
        const dialogRef = this.dialog.open(RemoveItemDialogComponent, {
            data: {
                text: reservation.name + `'s reservation`,
                item: {...reservation}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.removeTableReservations(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Removed table reservation.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not remove table reservation.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    reservationCardClick(table: ITableStateViewModel) {
        if (table.state === 'Busy') {
            this.finishReservation(table);
        } else {
            this.createCurrentReservation(table);
        }
    }

    finishReservation(table: ITableStateViewModel) {
        const dialogRef = this.dialog.open(FinishReservationDialogComponent, {
            data: {
                table: {...table}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.getCurrentTableReservation(item)),
            concatMap(res => this.service.finishReservation(res)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Finished table reservation.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not finish table reservation.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    createCurrentReservation(table: ITableStateViewModel) {
        const dialogRef = this.dialog.open(CurrentReservationDialogComponent, {
            data: {
                table: {...table}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createCurrentTableReservation(table, item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Created table reservation.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not create table reservation.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

}
