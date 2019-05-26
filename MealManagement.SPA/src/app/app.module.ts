import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './_components/nav/nav.component';

import { FormsModule,  ReactiveFormsModule  } from '@angular/forms';
import { HomeComponent } from './_components/home/home.component';
import { SignInComponent } from './_components/SignInOnSignUp/SignIn/SignIn.component';
import { SignUpComponent } from './_components/SignInOnSignUp/SignUp/SignUp.component';
import { SignInOrSignUpComponent } from './_components/SignInOnSignUp/SignInOrSignUp/SignInOrSignUp.component';
import { SignDirective } from './_components/SignInOnSignUp/Sign.directive';
import { CommonService } from './_services/common.service';
import { AlertifyService } from './_services/alertify.service';
import {
  BsDatepickerModule,
} from "ngx-bootstrap";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    SignInOrSignUpComponent,
    SignInComponent,
    SignUpComponent,
    SignDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [
    CommonService, 
    AlertifyService
  ],
  bootstrap: [AppComponent],
  entryComponents:[
    SignInComponent,
    SignUpComponent
  ],
})
export class AppModule { }
