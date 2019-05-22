import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-SignUp',
  templateUrl: './SignUp.component.html',
  styleUrls: ['./SignUp.component.css']
})
export class SignUpComponent{

  @Output()
  SignChange = new EventEmitter();

  constructor() { }

  ngOnInit() {
    
  }

}
