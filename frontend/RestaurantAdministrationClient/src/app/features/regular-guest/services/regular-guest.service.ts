import { Injectable, Inject } from '@angular/core';
import { API_BASE_URL } from 'src/app/core/core.module';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegularGuestViewModel } from '../models/regular-guest.model';

@Injectable()
export class RegularGuestService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ){}
    
    getRegularGuests(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/regularguest`);
    }

    createRegularGuest(regularGuest: IRegularGuestViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/regularguest`, regularGuest);
    }
}

