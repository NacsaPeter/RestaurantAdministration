import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';
import { ICreateFeedbackViewModel } from '../models/feedback.model';

@Injectable()
export class FeedbackService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    createFeedback(feedback: ICreateFeedbackViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/feedback/feedback`, feedback);
    }

}
