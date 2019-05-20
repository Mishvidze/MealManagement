import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[sign-host]',
})
export class SignDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}

