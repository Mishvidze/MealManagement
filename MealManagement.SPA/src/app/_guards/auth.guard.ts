import { Injectable } from "@angular/core";
import { AuthService } from "../_services/auth.service";
import { Router, CanActivate, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";

@Injectable({
  providedIn: "root"
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {
    if (this.authService.loggedIn()) {
        return true;
      }
  
      this.alertify.error('You shall not pass!!!');
      this.router.navigate(['/signIn']);
      return false;
  }
}
