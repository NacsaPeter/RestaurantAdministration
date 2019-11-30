import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ITableStateViewModel } from '../../models/reservations.model';

@Component({
    selector: 'app-current-reservations',
    templateUrl: './current-reservations.component.html'
})
export class CurrentReservationsComponent {

    @Input() tables: ITableStateViewModel[];
    @Output() reservationCardClick = new EventEmitter();

}
