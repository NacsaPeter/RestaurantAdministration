import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/core/core.module';
import { IUserViewModel, ICreateUserViewModel } from '../models/user.model';

@Injectable()
export class UserService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ) {}

    removeUser(user: IUserViewModel): Observable<any> {
        return this.http.delete(`${this.baseUrl}/api/user/${user.id}`);
    }

    getUsers(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/user`);
    }

    registerUser(user: ICreateUserViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/user/signup`, user);
    }

}
