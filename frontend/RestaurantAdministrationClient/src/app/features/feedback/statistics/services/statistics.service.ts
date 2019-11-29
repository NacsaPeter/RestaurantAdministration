import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';

@Injectable()
export class StatisticsService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    getFeedbacks(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/feedback/feedbacks`);
    }

}
