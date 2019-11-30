import { Component, OnInit } from '@angular/core';
import { IMenuItemViewModel } from '../models/menu-item.model';
import { MenuService } from '../services/menu.service';
import { Observable, of, concat } from 'rxjs';
import { ICategoryViewModel } from '../models/category.model';
import { tap, catchError, finalize, concatMap, mergeMap, filter } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MenuDialogComponent } from '../components/menu-dialog.component';
import { RemoveItemDialogComponent } from 'src/app/shared/components/remove-item/remove-item-dialog.component';

@Component({
    templateUrl: './menu.page.component.html'
})
export class MenuPageComponent implements OnInit{

    isSave: boolean;
    categories: ICategoryViewModel[] = [];
    displayedColumns: string[] = ['name', 'price', 'edit', 'delete'];
    isLoading: boolean;
    category: ICategoryViewModel = {
        name: null,
        menuItems: []
    }

    constructor(
        private service: MenuService,
        private snackbar: MatSnackBar,
        private dialog: MatDialog,
    ){}

    ngOnInit(){
        this.fetchData().subscribe();
    }

    fetchData(): Observable<any> {
        this.isLoading = true;
        return this.service.getCategories().pipe(
            tap(res => this.categories = res),
            catchError(err => of(this.snackbar.open('Could not fetch data.', 'Close'))),
            finalize(() => this.isLoading = false)
        );
    }

    save(){
        this.isSave = true;
        this.service.createCategory(this.category).pipe(
            concatMap(() => this.fetchData()),
            catchError(() => of(this.snackbar.open('Could not add category.', 'Close'))),
            finalize(() => this.category.name = "")
        ).subscribe();

    }

    addMenuItem(category){
        const dialogRef = this.dialog.open(MenuDialogComponent, {
            data: { isNew: true, categoryId: category.id}
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.createMenuItem(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Added new menu item.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not add menu item.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    editMenuItem(menuItem: IMenuItemViewModel){
        const dialogRef = this.dialog.open(MenuDialogComponent, {
            data: {
                isNew: false,
                menuItem: {...menuItem}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.editMenuItem(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Edited menu item.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not edit menu item.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

    removeMenuItem(menuItem: IMenuItemViewModel){
        const dialogRef = this.dialog.open(RemoveItemDialogComponent, {
            data: {
                text: menuItem.name + ' menu item',
                item: {...menuItem}
            }
        });
        dialogRef.afterClosed().pipe(
            tap(() => this.isLoading = true),
            filter(item => !!item),
            mergeMap(item => this.service.removeMenuItem(item)),
            concatMap(() => this.fetchData()),
            concatMap(() => of(this.snackbar.open('Removed menu item.', 'Close'))),
            catchError(() => of(this.snackbar.open('Could not remove menu item.', 'Close'))),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }
}
