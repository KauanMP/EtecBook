import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm!: FormGroup;

  constructor(private fb: FormBuilder){}

  ngOnInit(): void{
    this.loginForm = this.fb.group({
      email:['', Validators.required],
      password:['', Validators.required]
    });
  }

  checkEmail() {
    this.loginForm.controls['email'].dirty && this.loginForm.hasError('required', 'email')
  }

  checkPassword() {
    this.loginForm.controls['password'].dirty && this.loginForm.hasError('required', 'password')
  }

  onSubmit() {
    if (this.loginForm.valid) {
      // Enviar os dados para API
      console.log(this.loginForm.value);
    } else {
      // dispara um erro
      this.validateAllFormFields(this.loginForm);
    }
  }

  private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control)
      }
    })
  }
}
