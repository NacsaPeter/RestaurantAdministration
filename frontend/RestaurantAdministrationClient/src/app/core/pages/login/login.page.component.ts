import { Component } from '@angular/core';
import { finalize, map } from 'rxjs/operators';
import { ILoginUserDto } from '../../models/user.model';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    templateUrl: './login.page.component.html'
})
export class LoginPageComponent {

    constructor(
        private authService: AuthService,
        private router: Router
    ) {}

    user: ILoginUserDto = {
        userName: '',
        password: ''
    };
    isLoginError = false;
    isLoading: boolean;

    LoginUser() {
        this.isLoading = true;
        this.authService.login(this.user).pipe(
            map((res: boolean) => {
                if (res) {
                    this.router.navigateByUrl('/');
                } else {
                    this.user.password = '';
                    this.isLoginError = true;
                }
            }),
            finalize(() => this.isLoading = false)
        ).subscribe();
    }

}
