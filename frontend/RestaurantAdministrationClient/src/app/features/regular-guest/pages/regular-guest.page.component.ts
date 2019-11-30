import { Component } from '@angular/core';
import { IRegularGuestViewModel } from '../models/regular-guest.model';
import { RegularGuestService } from '../services/regular-guest.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, of } from 'rxjs';
import { tap, catchError, finalize, filter, mergeMap, concatMap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { RegularGuestDialogComponent } from '../components/regular-guest-dialog.component';

@Component({
    templateUrl: './regular-guest.page.component.html'
})
export class RegularGuestPageComponent {

    displayedColumns: string[] = ['name', 'birthDay', 'address'];
    regularGuests: IRegularGuestViewModel[] = [];
    isLoading: boolean;

    constructor(
        private service: RegularGuestService,
        private snackbar: MatSnackBar,
        private dialog: MatDialog,
    ){}

    ngOnInit(){
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getRegularGuests().pipe(
            tap(res => this.regularGuests = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    addRegularGuest(){
        const dialogRef = this.dialog.open(RegularGuestDialogComponent, {
            data: {  }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createRegularGuest(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new regular guest.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add regular guest.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }
}
