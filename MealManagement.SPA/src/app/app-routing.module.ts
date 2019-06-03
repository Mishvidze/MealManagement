import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./_components/home/home.component";
import { SignInOrSignUpComponent } from "./_components/SignInOnSignUp/SignInOrSignUp/SignInOrSignUp.component";
import { MealListComponent } from './_components/mealList/mealList.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "signIn",
    component: SignInOrSignUpComponent,
    data: { form: "signIn" }
  },
  {
    path: "signUp",
    component: SignInOrSignUpComponent,
    data: { form: "signUp" }
  },
  {
    path: "mealList",
    component: MealListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
