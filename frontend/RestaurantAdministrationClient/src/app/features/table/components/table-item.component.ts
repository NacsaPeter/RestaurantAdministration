import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ITableViewModel } from '../models/table.model';

@Component({
    selector: 'app-table-item',
    templateUrl: './table-item.component.html'
})
export class TableItemComponent {

    @Input() table: ITableViewModel;

    @Output() edit = new EventEmitter();
    @Output() remove = new EventEmitter();

}
