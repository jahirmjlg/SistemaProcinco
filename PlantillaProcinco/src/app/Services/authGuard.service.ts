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

            if (roleId !== null) {
                const pantallaAdicional = {
                    pantalla: "empty",
                };
                pantallas.push(pantallaAdicional);
            }

            this.allowedScreens = new Set(
                pantallas.map(pant =>
                    pant.pantalla.toLowerCase().replace(/\s+/g, '')
                ));

            console.log("Allowed screens :", Array.from(this.allowedScreens));
          },
          error: (error) => {
            console.error('Error', error);
          }
        });
      }

      isUrlAllowed(url: string): boolean {
        this.loadPermissions();

        const admin = this.cookieService.get('esAdmin').toString()

        if (admin === "true"){

            return true;
        }

        const urlSegments = url.split('/').filter(segment => segment.trim() !== '');

        const screenNameIndex = urlSegments.indexOf('pages') + 1;
        if (screenNameIndex > 0 && screenNameIndex < urlSegments.length) {
            const screenName = urlSegments[screenNameIndex].toLowerCase().trim();
            console.log(`Screen name extracted: ${screenName}`);

            if(screenName == "empty")
                {
                    return true;
                }

            return this.allowedScreens.has(screenName);
        }

        this.router.navigate(['/login']);
        // window.location.reload();
      return false;
    }
  }
