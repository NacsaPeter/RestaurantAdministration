import { Injectable, Inject } from '@angular/core';
import { API_BASE_URL } from 'src/app/core/core.module';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDiscountViewModel } from '../models/discount.model';

@Injectable()
export class DiscountService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ){}

    getDiscounts(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/discount/discounts`);
    }

    createDiscount(discount: IDiscountViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/discount/discount`, discount);
    }

    removeDiscount(discount: IDiscountViewModel): Observable<any> {
        console.log(`${this.baseUrl}​/api​/discount​/discount​/${discount.id}`);
        return this.http.delete(`${this.baseUrl}​/api​/discount​/discount​/${discount.id}`);
    }
}