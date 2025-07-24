import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent {
    password: string = '';
    confirmPassword: string = '';
    successMessage = '';
    errorMessage = '';

    @ViewChild('resetForm') resetForm!: NgForm;

    onSubmit() {
        if (this.resetForm.invalid || this.password !== this.confirmPassword) {
            return;
        }
        // Here you would call your API to reset the password
        this.successMessage = 'Password has been reset successfully!';
        this.errorMessage = '';
        this.password = '';
        this.confirmPassword = '';
    }
    
    goToLogin() {
        window.location.href = '/login';
    }
}