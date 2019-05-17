import { Component, Injector } from '@angular/core';
import { createCustomElement } from '@angular/elements';
import { SignInComponent } from './_components/SignInOnSignUp/SignIn/SignIn.component';
import { SignUpComponent } from './_components/SignInOnSignUp/SignUp/SignUp.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MealManagement';

  constructor() {
    // // Convert `PopupComponent` to a custom element.
    // const SignInComp = createCustomElement(SignInComponent, {injector});
    // const SignUpComp = createCustomElement(SignUpComponent, {injector});
    // // Register the custom element with the browser.
    // customElements.define('app-signIn', SignInComp);
    // customElements.define('app-signUp', SignUpComp);
  }
}
