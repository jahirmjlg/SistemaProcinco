import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './Services/authGuard.service';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
  })
  export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) {}

    canActivate(
      next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      const url: string = state.url;
      if (this.authService.isUrlAllowed(url)) {
        return true;
      }

      this.router.navigate(['/notfound']);
      return false;
    }
  }
