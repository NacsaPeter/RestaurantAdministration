import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html'
})
export class DialogComponent {

    @Input() dialogClose: any;
    @Input() title: string;
    @Input() disabled: boolean;
    @Input() buttonText: string;
    @Input() closeText = 'Cancel';

}
