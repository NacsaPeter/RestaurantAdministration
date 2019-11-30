import { Component, Inject } from '@angular/core';
import { IMenuItemViewModel } from '../models/menu-item.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    templateUrl: './menu-dialog.component.html'
})
export class MenuDialogComponent{

    title: string;
    buttonText: string;
    menuItem: IMenuItemViewModel;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {
            isNew: boolean;
            categoryId: number;
            menuItem?: IMenuItemViewModel;
        }
    ){
        if(data.isNew){
            this.title = 'Add new menu item';
            this.buttonText = 'Add';
            this.menuItem = {
                name: null,
                price: null,
                categoryId: data.categoryId
            };
        }
        else {
            this.title = 'Edit ' + data.menuItem.name + ' menu item.';
            this.buttonText = 'Save';
            this.menuItem = data.menuItem;
        }
    }
}