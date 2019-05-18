import { Component, OnInit } from '@angular/core';
import { NgElement, WithProperties } from '@angular/elements';
import { SignInComponent } from '../SignIn/SignIn.component';
import { SignUpComponent } from '../SignUp/SignUp.component';
import { SignService } from '../Sign.service';

@Component({
  selector: 'app-SignInOrSignUp',
  templateUrl: './SignInOrSignUp.component.html',
  styleUrls: ['./SignInOrSignUp.component.css']
})
export class SignInOrSignUpComponent implements OnInit {

  constructor(public signService: SignService) { }

  ngOnInit() {
  }

  ShowSignIn() {
    debugger
    this.signService.showSignIn();
  }

  ShowSignUp() {
    this.signService.showSignUp();
  }

}
