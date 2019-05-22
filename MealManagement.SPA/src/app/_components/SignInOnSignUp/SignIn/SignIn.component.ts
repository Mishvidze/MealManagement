import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-SignIn',
  templateUrl: './SignIn.component.html',
  styleUrls: ['./SignIn.component.css']
})
export class SignInComponent {

  model: any = {};
  
  @Output()
  SignChange = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
