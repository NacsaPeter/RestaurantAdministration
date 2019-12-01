import { IOrderViewModel } from './order.model';
import { IRegularGuestViewModel } from '../../regular-guest/models/regular-guest.model';
import { IDiscountViewModel } from '../../discount/models/discount.model';

export interface IPaymentResultViewModel {
    fullPrice: number;
    fullDiscount: number;
    result: number;
}

export interface IGeneratePaymentResultViewModel {
    order: IOrderViewModel;
    regularGuest: IRegularGuestViewModel;
    discount: IDiscountViewModel;
}

export interface IGenerateInvoiceViewModel {
    orderId: number;
    billToName: string;
    billToStreetAddress: string;
    billToCity: string;
    billToCountry: string;
    billToZIP: string;
    billToPhone: string;
    discount: number;
}

export interface IInvoiceViewModel {
    id: number;
    date: Date;
    companyName: string;
    streetAddress: string;
    cityCountryZIP: string;
    phone: string;
    billToName: string;
    billToStreetAddress: string;
    billToCityCountryZIP: string;
    billToPhone: string;
    netSum: number;
    vatSum: number;
    discount: number;
    priceSum: number;
    invoiceItems: IInvoiceItemViewModel[];
}

export interface IInvoiceItemViewModel {
    id: number;
    description: string;
    vat: number;
    unitPrice: number;
    quantity: number;
    netAmount: number;
    vatContent: number;
    amount: number;
}
