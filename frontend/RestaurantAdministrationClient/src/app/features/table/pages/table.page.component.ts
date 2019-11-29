import { Component, OnInit } from '@angular/core';
import { ITableViewModel } from '../models/table.model';
import { MatDialog } from '@angular/material/dialog';
import { TableDialogComponent } from '../components/table-dialog.component';
import { RemoveItemDialogComponent } from 'src/app/shared/components/remove-item/remove-item-dialog.component';
import { Observable, of } from 'rxjs';
import { TableService } from '../services/table.service';
import { tap, catchError, finalize, filter, mergeMap, concatMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    templateUrl: './table.page.component.html'
})
export class TablePageComponent implements OnInit {

    tables: ITableViewModel[] = [];
    isLoading: boolean;

    constructor(
        private dialog: MatDialog,
        private snackbar: MatSnackBar,
        private service: TableService,
    ) {}

    ngOnInit() {
        this.fetchData().subscribe();
    }

    addTable() {
        const dialogRef = this.dialog.open(TableDialogComponent, {
            data: { isNew: true }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createTable(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new table.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add table.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    editTable(table: ITableViewModel) {
        const dialogRef = this.dialog.open(TableDialogComponent, {
            data: {
                isNew: false,
                table: {...table}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.editTable(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Edited table.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not edit table.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    removeTable(table: ITableViewModel) {
        const dialogRef = this.dialog.open(RemoveItemDialogComponent, {
            data: {
                text: 'table No.' + table.number,
                item: {...table}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.removeTable(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Removed table.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not remove table.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getTables().pipe(
            tap(res => this.tables = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

}
