import { Component, Input, Output, EventEmitter, ViewChild, OnChanges } from '@angular/core';
import { ITableReservationViewModel } from '../../models/reservations.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
    selector: 'app-upcoming-reservations',
    templateUrl: './upcoming-reservations.component.html'
})
export class UpcomingReservationsComponent implements OnChanges {

    @Input() reservations: ITableReservationViewModel[];
    @Output() addReservation = new EventEmitter();
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
