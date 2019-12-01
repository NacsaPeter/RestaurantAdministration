import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';
import { IGeneratePaymentResultViewModel, IGenerateInvoiceViewModel } from '../models/payment.model';
import { IOrderViewModel } from '../models/order.model';

@Injectable()
export class PaymentService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    generatePayment(dto: IGeneratePaymentResultViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/payment/payment`, dto);
    }

    pay(order: IOrderViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/payment`, order);
    }

    generateInvoice(dto: IGenerateInvoiceViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/payment/invoice`, dto);
    }

}
