import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { tap } from 'rxjs/operators';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {

    isDiscount: boolean;
    isFeedback: boolean;
    isMenu: boolean;
    isOrder: boolean;
    isRegularGuest: boolean;
    isReservation: boolean;
    isTable: boolean;
    isUser: boolean;
    isAdmin: boolean;

    ngOnInit() {
        this.authService.currentUser$.pipe(
            tap(res => this.isAdmin = (res && res.role === 'Admin'))
        ).subscribe();
    }

    constructor(
        private router: Router,
        private authService: AuthService,
    ) {
        const url = this.router.url;
        if (url.match('/discount')) {
            this.isDiscount = true;
        } else if (url.match('/statistics')) {
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

    logout() {
        this.authService.logout();
    }

}
