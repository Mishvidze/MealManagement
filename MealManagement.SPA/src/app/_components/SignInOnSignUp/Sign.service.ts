import { Injectable } from '@angular/core';
import { NgElement, WithProperties } from '@angular/elements';
import { SignUpComponent } from './SignUp/SignUp.component';
import { SignInComponent } from './SignIn/SignIn.component';

@Injectable()
export class SignService {
    showSignUp() {
        // Create element
        const popupEl: NgElement & WithProperties<SignUpComponent> = document.createElement('signup-element') as any;

        // Add to the DOM
        document.body.appendChild(popupEl);
    }

    showSignIn() {
        // Create element
        const popupEl: NgElement & WithProperties<SignInComponent> = document.createElement('signin-element') as any;

        // Add to the DOM
        document.body.appendChild(popupEl);
    }
}