import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./_components/home/home.component";
import { SignInComponent } from "./_components/SignInOnSignUp/SignIn/SignIn.component";
import { SignUpComponent } from "./_components/SignInOnSignUp/SignUp/SignUp.component";
import { SignInOrSignUpComponent } from './_components/SignInOnSignUp/SignInOrSignUp/SignInOrSignUp.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  // { path: "signIn", component: SignInComponent },
  // { path: "signUp", component: SignUpComponent }
  { path: "signIn", component: SignInOrSignUpComponent },
  { path: "signUp", component: SignInOrSignUpComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
