export interface IUserViewModel {
    id?: number;
    userName: string;
    email: string;
    role: string;
}

export interface ICreateUserViewModel {
    userName: string;
    email: string;
    role: string;
    password: string;
}
