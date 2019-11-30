import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IUserViewModel } from '../models/user.model';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserService } from '../services/user.service';
import { tap, catchError, finalize, filter, mergeMap, concatMap } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { RemoveItemDialogComponent } from 'src/app/shared/components/remove-item/remove-item-dialog.component';
import { UserDialogComponent } from '../components/user-dialog.component';

@Component({
    templateUrl: './user.page.component.html'
})
export class UserPageComponent implements OnInit {

    isLoading: boolean;

    displayedColumns: string[] = ['userName', 'email', 'role', 'remove'];
    dataSource = new MatTableDataSource<IUserViewModel>([]);

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) sort: MatSort;

    constructor(
        private snackbar: MatSnackBar,
        private service: UserService,
        private dialog: MatDialog,
    ) {}

    ngOnInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.fetchData().subscribe();
    }

    removeUser(user: IUserViewModel) {
        const dialogRef = this.dialog.open(RemoveItemDialogComponent, {
            data: {
                text: 'user ' + user.userName,
                item: {...user}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.removeUser(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Removed user.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not remove user.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getUsers().pipe(
            tap(res => this.dataSource = new MatTableDataSource<IUserViewModel>(res)),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    addUser() {
        const dialogRef = this.dialog.open(UserDialogComponent, {
            data: { isNew: true }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.registerUser(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new user.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add user.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

}
