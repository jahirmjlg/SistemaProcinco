import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {ServiceService} from '../Services/service.service'
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

interface Pantalla {
    pantalla: string;
}

@Injectable({
    providedIn: 'root'
  })

  export class AuthService {
    private allowedScreens: Set<string>;

    constructor(private http: HttpClient, private service: ServiceService,
        private cookieService: CookieService, private router: Router) {
      this.allowedScreens = new Set();
    }


    urlsPermitidas = this.service.urlLocalhost + 'PantallaPorRol/'



    loadPermissions(): void {
    const roleId = Number.parseInt(this.cookieService.get('roleID'));

        this.service.getPantallasDeRol(roleId).subscribe({
          next: (pantallas: Pantalla[]) => {
            console.log(pantallas)

            this.allowedScreens = new Set(pantallas.map(pant => pant.pantalla.toLowerCase().trim()));
          },
          error: (error) => {
            console.error('Error', error);
          }
        });
      }

      isUrlAllowed(url: string): boolean {

        const admin = this.cookieService.get('esAdmin').toString()

        if (admin != "true"){
            return true;
        }


        const urlSegments = url.split('/').filter(segment => segment);

        const screenNameIndex = urlSegments.indexOf('pages') + 1;
        if (screenNameIndex > 0 && screenNameIndex < urlSegments.length) {
            const screenName = urlSegments[screenNameIndex].toLowerCase().trim();
            return this.allowedScreens.has(screenName);
        }

        this.router.navigate(['/login']);
        // window.location.reload();
      return false;
    }
  }
