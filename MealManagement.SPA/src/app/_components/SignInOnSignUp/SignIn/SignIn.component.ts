import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { AlertifyService } from "src/app/_services/alertify.service";

@Component({
  selector: "app-SignIn",
  templateUrl: "./SignIn.component.html",
  styleUrls: ["./SignIn.component.css"]
})
export class SignInComponent {
  constructor(private alertify: AlertifyService) {}

  model: any = {};

  @Output()
  SignChange = new EventEmitter();

  ngOnInit() {}

  SignIn() {
    debugger
    this.alertify.message("ცუცკა");
  }
}
