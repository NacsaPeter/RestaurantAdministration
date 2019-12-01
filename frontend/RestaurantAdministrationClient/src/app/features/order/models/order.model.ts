import { ITableReservationViewModel } from '../../reservation/models/reservations.model';

export interface ITableStateViewModel {
    id: number;
    number: number;
    numberOfSeats: number;
    state: string;
    hasOrder: string;
}

export interface IOrderViewModel {
    id?: number;
    tableReservationId?: number;
    tableReservation?: ITableReservationViewModel;
    date?: Date;
    isDelivery: boolean;
    isPaid?: boolean;
    address: string;
    name: string;
    phone: string;
    orderItems: IOrderItemViewModel[];
}

export interface IOrderItemViewModel {
    id?: number;
    numberOfItems: number;
    notes: string;
    menuItemId: number;
    menuItemName: string;
    menuItemPrice?: number;
}
