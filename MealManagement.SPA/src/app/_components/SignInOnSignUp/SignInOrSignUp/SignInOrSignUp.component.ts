import {
  Component,
  OnInit,
  Type,
  ComponentFactoryResolver,
  ViewChild
} from "@angular/core";
import { SignInComponent } from "../SignIn/SignIn.component";
import { SignUpComponent } from "../SignUp/SignUp.component";
import { SignDirective } from "../Sign.directive";
import { CommonService } from "src/app/_services/common.service";
import { pathes } from "src/app/_constants/pathes";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-SignInOrSignUp",
  templateUrl: "./SignInOrSignUp.component.html",
  styleUrls: ["./SignInOrSignUp.component.css"]
})
export class SignInOrSignUpComponent implements OnInit {
  signInComponent: Type<any>;
  signUpComponent: Type<any>;

  @ViewChild(SignDirective) signHost: SignDirective;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private common: CommonService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.InitComponents();
    var formName = this.route.snapshot.data["form"];
    this.ChangeForm(formName);
  }

  ChangeForm(formName: string) {
    if (formName == "signIn") {
      this.ShowSignIn();
    } else if (formName == "signUp") {
      this.ShowSignUp();
    }
  }

  InitComponents() {
    this.signInComponent = SignInComponent;
    this.signUpComponent = SignUpComponent;
  }

  ShowSignIn() {
    this.loadComponent(this.signInComponent);

    // this.common.rewriteUrl(pathes.signIn);
  }

  ShowSignUp() {
    this.loadComponent(this.signUpComponent);

    // this.common.rewriteUrl(pathes.signUp);
  }

  loadComponent(component: Type<any>) {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(
      component
    );

    let viewContainerRef = this.signHost.viewContainerRef;
    viewContainerRef.clear();

    let newCompRef = viewContainerRef.createComponent(componentFactory);

    newCompRef.instance.SignChange.subscribe((form: string) => {
      this.ChangeForm(form);
    });
  }
}
