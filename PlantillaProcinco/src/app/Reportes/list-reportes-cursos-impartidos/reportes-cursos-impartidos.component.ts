import { Component } from '@angular/core';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { ServiceService } from 'src/app/Services/service.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-list-reportecursosimpartidos',
  templateUrl: './reportes-cursos-impartidos.component.html',
  providers: [ConfirmationService, MessageService]
})
export class ReportesCursosImpartidosComponent {

  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];


    showPdf: boolean = false;

    showPDF()
    {
        this.showPdf = false;
    }

    public safeUrl: SafeResourceUrl;

    constructor(private sanitizer: DomSanitizer,public router: Router, private service: ServiceService){}

    getSafeUrl(url: string) {
        return this.sanitizer.bypassSecurityTrustResourceUrl(url);
      }


    ngOnInit(): void {
        this.service.getPreviewPdfUrl().subscribe(
          (url) => {
            this.safeUrl = this.getSafeUrl(url);
          },
          (error) => {
            console.error('Error al obtener la URL del PDF:', error);
          }
        );
      }


}
