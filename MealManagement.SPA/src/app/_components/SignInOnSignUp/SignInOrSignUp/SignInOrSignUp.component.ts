import { Component, OnInit, Type, ComponentFactoryResolver, ViewChild } from '@angular/core';
import { SignInComponent } from '../SignIn/SignIn.component';
import { SignUpComponent } from '../SignUp/SignUp.component';
import { SignDirective } from '../Sign.directive';

@Component({
  selector: 'app-SignInOrSignUp',
  templateUrl: './SignInOrSignUp.component.html',
  styleUrls: ['./SignInOrSignUp.component.css']
})
export class SignInOrSignUpComponent implements OnInit {

  signInComponent: Type<any>;
  signUpComponent: Type<any>;

  @ViewChild(SignDirective) signHost: SignDirective;

  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    this.InitComponents();
  }

  InitComponents(){
    this.signInComponent = SignInComponent;
    this.signUpComponent = SignUpComponent;
  }

  ShowSignIn() {
    this.loadComponent(this.signInComponent);
  }

  ShowSignUp() {
    this.loadComponent(this.signUpComponent);
  }

  loadComponent(component: Type<any>) {

    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(component);

    let viewContainerRef = this.signHost.viewContainerRef;
    viewContainerRef.clear();

    viewContainerRef.createComponent(componentFactory);
  }
}
