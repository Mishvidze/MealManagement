import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { AlertifyService } from "src/app/_services/alertify.service";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap";
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';
import { User } from 'src/app/_models/user';

@Component({
  selector: "app-SignUp",
  templateUrl: "./SignUp.component.html",
  styleUrls: ["./SignUp.component.css"]
})
export class SignUpComponent {
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  user: User;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit() {
    this.bsConfig = {
      containerClass: "theme-red"
    };
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      username: ["", Validators.required],
      dateOfBirth: [null, Validators.required],
      password: [
        "",
        [Validators.required, Validators.minLength(4), Validators.maxLength(8)]
      ],
      confirmPassword: ["", Validators.required]
    });
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.alertify.success('Registration successful');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.authService.login(this.user).subscribe(() => {
          this.router.navigate(['/mealList']);
        });
      });
    }
  }

  cancel(){
    this.alertify.error("ცუცუნა");
  }
}
