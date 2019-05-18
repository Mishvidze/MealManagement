import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './_components/nav/nav.component';

import { FormsModule } from '@angular/forms';
import { HomeComponent } from './_components/home/home.component';
import { SignInComponent } from './_components/SignInOnSignUp/SignIn/SignIn.component';
import { SignUpComponent } from './_components/SignInOnSignUp/SignUp/SignUp.component';
import { SignInOrSignUpComponent } from './_components/SignInOnSignUp/SignInOrSignUp/SignInOrSignUp.component';
import { createCustomElement } from '@angular/elements';
import { SignService } from './_components/SignInOnSignUp/Sign.service';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    SignInOrSignUpComponent,
    SignInComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [SignService],
  bootstrap: [AppComponent],
  entryComponents:[
    SignInComponent,
    SignUpComponent
  ],
})
export class AppModule {
  constructor(injector: Injector) {
    // Convert `PopupComponent` to a custom element.
    const SignInComp = createCustomElement(SignInComponent, {injector});
    const SignUpComp = createCustomElement(SignUpComponent, {injector});
    // Register the custom element with the browser.
    customElements.define('signin-element', SignInComp);
    customElements.define('signup-element', SignUpComp);
  }
 }
