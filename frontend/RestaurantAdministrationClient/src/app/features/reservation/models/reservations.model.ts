export interface ITableReservationViewModel {
    id?: number;
    from: Date;
    to: Date;
    name: string;
    table: ITableViewModel;
}

export interface ITableViewModel {
    id: number;
    number: number;
    numberOfSeats: number;
}

export interface ICreateTableReservationViewModel {
    numberOfSeats: number;
    date: Date;
    hours: number;
    name: string;
}

export interface ITableStateViewModel {
    id: number;
    number: number;
    numberOfSeats: number;
    state: string;
}
