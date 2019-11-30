import { IMenuItemViewModel } from './menu-item.model';

export interface ICategoryViewModel{
    id?: number;
    name: string;
    menuItems: IMenuItemViewModel[];
}