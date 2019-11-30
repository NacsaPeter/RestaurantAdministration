import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ITableViewModel } from '../../../features/table/models/table.model';

@Component({
    selector: 'app-table-item',
    templateUrl: './table-item.component.html'
})
export class TableItemComponent {

    @Input() table: ITableViewModel;
    @Input() isBusy: boolean;
    @Input() isFree: boolean;
    @Input() isReserved: boolean;
    @Input() hasIcons = true;

    @Output() edit = new EventEmitter();
    @Output() remove = new EventEmitter();

}
