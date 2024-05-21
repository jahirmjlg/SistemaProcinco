import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "./service/app.layout.service";

import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent {

    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private cookieService: CookieService, private router: Router) { }

    logOut()
    {
        this.cookieService.deleteAll();
        window.location.reload();
        window.location.replace('/');

    }

    ngOnInit() {
        var empleado = document.getElementById('emp');


        var nombre = this.cookieService.get('namee')


        empleado.textContent = nombre;



    }
}
