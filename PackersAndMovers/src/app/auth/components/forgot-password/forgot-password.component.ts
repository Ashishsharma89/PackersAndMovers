import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent {
  email: string = '';
  submitted = false;

  onSubmit() {
    this.submitted = true;
    // TODO: Implement forgot password logic (API call)
  }

  goToLogin() {
    window.location.assign('/login');
  }

}
