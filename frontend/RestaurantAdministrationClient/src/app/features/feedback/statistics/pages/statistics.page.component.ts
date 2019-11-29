import { Component, ViewChild, OnInit } from '@angular/core';
import { IFeedbackViewModel } from '../models/statistics.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { StatisticsService } from '../services/statistics.service';
import { tap, catchError, finalize } from 'rxjs/operators';
import { of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    templateUrl: './statistics.page.component.html'
})
export class StatisticsPageComponent implements OnInit {

    isLoading: boolean;

    displayedColumns: string[] = ['date', 'serviceQuality', 'cleanness', 'foodQuality', 'atmosphere', 'other'];
    dataSource = new MatTableDataSource<IFeedbackViewModel>([]);

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) sort: MatSort;

    constructor(
        private snackbar: MatSnackBar,
        private service: StatisticsService,
        private router: Router,
    ) {}

    ngOnInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.isLoading = true;
        this.service.getFeedbacks().pipe(
            tap(res => this.dataSource = new MatTableDataSource<IFeedbackViewModel>(res)),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    addFeedback() {
        this.router.navigateByUrl('/feedback');
    }

}
