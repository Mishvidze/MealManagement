import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { AlertifyService } from "src/app/_services/alertify.service";
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: "app-SignIn",
  templateUrl: "./SignIn.component.html",
  styleUrls: ["./SignIn.component.css"]
})
export class SignInComponent {

  model: any = {};

  @Output()
  SignChange = new EventEmitter();

  constructor(
    private alertify: AlertifyService,
    private authService: AuthService) {}

  ngOnInit() {}

  SignIn() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      console.log(error);
      this.alertify.error(error);
    }, () => {
    });
  }
}
