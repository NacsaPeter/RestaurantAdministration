import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from 'src/app/core/core.module';
import { Observable } from 'rxjs';
import { ICategoryViewModel } from '../models/category.model';
import { IMenuItemViewModel } from '../models/menu-item.model';

@Injectable()
export class MenuService {

    constructor(
        @Inject(API_BASE_URL) private baseUrl: string,
        private http: HttpClient,
    ){}

    getCategories(): Observable<any> {
        return this.http.get(`${this.baseUrl}/api/menu/categories`);
    }

    createCategory(category: ICategoryViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/menu/category`, category);
    }

    createMenuItem(menuItem: IMenuItemViewModel): Observable<any> {
        return this.http.post(`${this.baseUrl}/api/menu/menuitem`, menuItem);
    }

    editMenuItem(menuItem: IMenuItemViewModel): Observable<any> {
        return this.http.put(`${this.baseUrl}/api/menu/menuitem`, menuItem);
    }

    removeMenuItem(menuItem: IMenuItemViewModel): Observable<any> {
        return this.http.delete(`${this.baseUrl}/api/menu/menuitem/${menuItem.id}`);
    }
}
