import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { AlertifyService } from "src/app/_services/alertify.service";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap";

@Component({
  selector: "app-SignUp",
  templateUrl: "./SignUp.component.html",
  styleUrls: ["./SignUp.component.css"]
})
export class SignUpComponent {
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private alertify: AlertifyService,
    private formBuilder: FormBuilder
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
    this.alertify.error("ცუცუნა");
  }

  cancel(){
    this.alertify.error("ცუცუნა");
  }
}
