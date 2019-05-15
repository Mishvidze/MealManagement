import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './_components/nav/nav.component';

import { FormsModule } from '@angular/forms';
import { HomeComponent } from './_components/home/home.component';
import { SignInComponent } from './_components/SignInOnSignUp/SignIn/SignIn.component';
import { SignUpComponent } from './_components/SignInOnSignUp/SignUp/SignUp.component';
import { SignInOrSignUpComponent } from './_components/SignInOnSignUp/SignInOrSignUp/SignInOrSignUp.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    SignInComponent,
    SignUpComponent,
    SignInOrSignUpComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
