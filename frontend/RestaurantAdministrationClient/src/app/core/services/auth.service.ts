import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { ILoginUserDto, ILoggedData, IUserModel } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { map, tap, catchError } from 'rxjs/operators';
import * as jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';

const JWT_ACCESS_KEY = 'restaurant_administraton_jwt';

@Injectable({providedIn: 'root'})
export class AuthService {

    private isAuthenticated: BehaviorSubject<ILoggedData> =
        new BehaviorSubject<ILoggedData>({ isLogged: false, role: [] });
    private currentUser: BehaviorSubject<IUserModel> =
        new BehaviorSubject<IUserModel>(null);
    private jwtToken = '';

    constructor(
        private http: HttpClient,
        private router: Router
    ) {
        this.loginWithJwt(sessionStorage.getItem(JWT_ACCESS_KEY));
    }

    get isAuthenticated$(): Observable<ILoggedData> {
        return this.isAuthenticated.asObservable();
    }

    get currentUser$(): Observable<IUserModel> {
        return this.currentUser.asObservable();
    }

    get authToken(): string {
        return this.jwtToken;
    }

    login(user: ILoginUserDto): Observable<boolean> {
        return this.http.post(`${environment.apiBaseUrl}/api/user/login`, user).pipe(
            tap((res: IUserModel) => {
                this.loginWithJwt(res.token);
                sessionStorage.setItem(JWT_ACCESS_KEY, res.token);
            }),
            map(() => true),
            catchError(() => of(false))
        );
    }

    private loginWithJwt(token: string): void {
        this.jwtToken = token;
        const currentUserObj = (this.jwtToken !== null)
            ? jwt_decode(this.jwtToken)
            : null;
        const isAuthenticated = (currentUserObj !== null)
            ? { isLogged: !!currentUserObj, role: (typeof currentUserObj.role === 'string') ? [currentUserObj.role] : currentUserObj.role }
            : { isLogged: !!currentUserObj, role: [] };
        this.isAuthenticated.next(isAuthenticated);
        this.currentUser.next(isAuthenticated ? currentUserObj : null);
    }

    logout() {
        sessionStorage.removeItem(JWT_ACCESS_KEY);
        this.jwtToken = '';
        this.isAuthenticated.next({ isLogged: false, role: null });
        this.currentUser.next(null);
        this.router.navigate(['/login']);
    }

}
