import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  hide: boolean = true;

  constructor(
    private authService: AuthService,
    // private localStorageService: LocalStorageService,
    // private snackbarService: SnackbarService
  ) {}

  onSubmit(form: any) {
    if (form.valid) {
      this.authService.login({ email: this.email, password: this.password }).subscribe({
        next: (response) => {
          if (response.token) {
            // this.localStorageService.set('token', JSON.stringify(response.token.result));
            // Decode JWT and store user details
            const payload = response.token.result.split('.')[1];
            const decoded = JSON.parse(atob(payload));
            const user = {
              id: decoded.nameid,
              email: decoded.email,
              role: decoded.role
            };
            // this.localStorageService.set('user', user);
          }
        //   this.snackbarService.success('Login successful!');
          window.location.assign('/dashboard');
        },
        error: (err) => {
          // Handle error (show message, etc.)
          console.log('Login failed. Please check your credentials.');
        }
      });
    }
  }

  goToRegister() {
    window.location.assign('/register');
  }

  forgotPassword(){
    window.location.assign('/forgot-password');
  }
}
