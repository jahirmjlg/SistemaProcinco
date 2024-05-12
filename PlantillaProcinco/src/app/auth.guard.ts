import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './Services/authGuard.service';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
    providedIn: 'root'
  })
  export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router,  private cookieService: CookieService) {}


    canActivate(
      next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      const url: string = state.url;

      const admin = this.cookieService.get('esAdmin').toString()

      if (admin != "true"){
          return true;
      }


      if (!this.authService.isUrlAllowed(url)) {
        this.router.navigate(['/login']);
        return false;
      }
      return true;
    }
  }
