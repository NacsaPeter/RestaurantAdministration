import { Injectable, Inject } from '@angular/core';
import { ITableViewModel } from '../models/table.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';

@Injectable()
export class TableService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    createTable(table: ITableViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/table`, table);
    }

    editTable(table: ITableViewModel): Observable<any> {
        return this.http.put(`${this.baseUrl}/api/table`, table);
    }

    removeTable(table: ITableViewModel): Observable<any> {
        return this.http.delete(`${this.baseUrl}/api/table/${table.id}`);
    }

    getTables(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/table`);
    }

}
