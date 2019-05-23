import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-SignUp',
  templateUrl: './SignUp.component.html',
  styleUrls: ['./SignUp.component.css']
})
export class SignUpComponent{

  @Output()
  SignChange = new EventEmitter();

  constructor(private alertify: AlertifyService) { }

  ngOnInit() {
    
  }

}
