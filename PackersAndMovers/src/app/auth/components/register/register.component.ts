import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';
import { CustomerRegisterModel } from '../../models/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
    formData: CustomerRegisterModel = {
        name: '',
        lastName: '',
        email: '',
        password: '',
        age: 0,
        confirmPassword: ''
    };

    constructor(
        private router: Router,
        private authService: AuthService,
        // private snackbarService: SnackbarService
    ) {}

    onSubmit(registerForm: NgForm) {
        if (registerForm.invalid) {
            return;
        }
        this.authService.register(this.formData).subscribe({
            next: (_res) => {
                // this.snackbarService.success('Registration successful!');
                // Registration successful, navigate to login
                this.goToLogin();
            },
            error: (_err) => {
                this.goToLogin();

                // Handle registration error (e.g., show error message)
                // console.error('Registration failed:', err);
            }
        });
    }

    goToLogin() {
        console.log('Navigating to login page');
        this.router.navigate(['/login']);
    }
}