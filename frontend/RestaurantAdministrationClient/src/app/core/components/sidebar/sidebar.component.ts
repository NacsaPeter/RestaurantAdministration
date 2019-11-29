import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})
export class SidebarComponent {

    isDiscount: boolean;
    isFeedback: boolean;
    isMenu: boolean;
    isOrder: boolean;
    isRegularGuest: boolean;
    isReservation: boolean;
    isTable: boolean;
    isUser: boolean;

    constructor(
        private router: Router
    ) {
        const url = this.router.url;
        if (url.match('/discount')) {
            this.isDiscount = true;
        } else if (url.match('/feedback')) {
            this.isFeedback = true;
        } else if (url.match('/menu')) {
            this.isMenu = true;
        } else if (url.match('/order')) {
            this.isOrder = true;
        } else if (url.match('/regularguest')) {
            this.isRegularGuest = true;
        } else if (url.match('/reservation')) {
            this.isReservation = true;
        } else if (url.match('/table')) {
            this.isTable = true;
        } else if (url.match('/user')) {
            this.isUser = true;
        }
    }

    navigate(url: string) {
        this.router.navigateByUrl(url);
    }

}
