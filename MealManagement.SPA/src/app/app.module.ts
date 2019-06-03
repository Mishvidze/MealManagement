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
import { AuthService } from './_services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { MealListComponent } from './_components/mealList/mealList.component';
import { AuthGuard } from './_guards/auth.guard';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    SignInOrSignUpComponent,
    SignInComponent,
    SignUpComponent,
    SignDirective,
    MealListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    })
  ],
  providers: [
    CommonService, 
    AlertifyService,
    AuthService,
    AuthGuard
  ],
  bootstrap: [AppComponent],
  entryComponents:[
    SignInComponent,
    SignUpComponent
  ],
})
export class AppModule { }
