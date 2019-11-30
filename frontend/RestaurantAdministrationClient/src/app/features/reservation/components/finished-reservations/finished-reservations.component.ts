import { Component, Input, OnChanges, ViewChild, EventEmitter, Output } from '@angular/core';
import { ITableReservationViewModel } from '../../models/reservations.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
    selector: 'app-finished-reservations',
    templateUrl: './finished-reservations.component.html'
})
export class FinishedReservationsComponent implements OnChanges {

    @Input() reservations: ITableReservationViewModel[];
    @Output() removeReservation = new EventEmitter();

    displayedColumns: string[] = ['from', 'to', 'name', 'number', 'numberOfSeats', 'remove'];
    dataSource = new MatTableDataSource<ITableReservationViewModel>([]);

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) sort: MatSort;

    ngOnChanges() {
        this.dataSource = new MatTableDataSource<ITableReservationViewModel>(this.reservations);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

}
