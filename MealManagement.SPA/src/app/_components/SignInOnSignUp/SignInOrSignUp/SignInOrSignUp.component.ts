import { Component, OnInit } from '@angular/core';
import { NgElement, WithProperties } from '@angular/elements';
import { SignInComponent } from '../SignIn/SignIn.component';
import { SignUpComponent } from '../SignUp/SignUp.component';

@Component({
  selector: 'app-SignInOrSignUp',
  templateUrl: './SignInOrSignUp.component.html',
  styleUrls: ['./SignInOrSignUp.component.css']
})
export class SignInOrSignUpComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  ShowSignIn() {
    debugger
    // Create element
    const popupEl: NgElement & WithProperties<SignInComponent> = document.createElement('signin-element') as any;

    // Add to the DOM
    document.body.appendChild(popupEl);
  }

  ShowSignUp() {
    debugger
    // Create element
    const popupEl: NgElement & WithProperties<SignUpComponent> = document.createElement('signup-element') as any;

    // Add to the DOM
    document.body.appendChild(popupEl);
  }

}
