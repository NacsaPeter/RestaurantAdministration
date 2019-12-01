import { Injectable } from '@angular/core';
import { CanActivateChild, Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { ILoggedData } from '../models/user.model';

@Injectable()
export class AdminGuard implements CanActivate, CanActivateChild {

    constructor(
        private router: Router,
        private authService: AuthService
    ) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {
        return this.authService.isAuthenticated$.pipe(
            take(1),
            map((isLoggedData: ILoggedData) => {
                if (!isLoggedData || isLoggedData.role[0] !== 'Admin') {
                    this.router.navigate(['/reservation']);
                    return false;
                }
                return true;
            })
        );
    }

    canActivateChild(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | Promise<boolean> | boolean {
        return this.canActivate(next, state);
    }

}
