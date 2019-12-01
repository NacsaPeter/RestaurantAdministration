export interface ILoginUserDto {
    userName: string;
    password: string;
}

export interface ILoggedData {
    isLogged: boolean;
    role: string[];
}

export interface IUserModel {
    userName: string;
    email: string;
    role: string;
    token: string;
}
