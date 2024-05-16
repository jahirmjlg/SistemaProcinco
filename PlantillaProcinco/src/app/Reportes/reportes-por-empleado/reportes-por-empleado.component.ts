import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ServiceService } from 'src/app/Services/service.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { dropEmpleados } from 'src/app/Models/EmpleadosViewModel';


@Component({
  selector: 'app-reportes-por-empleado',
  templateUrl: './reportes-por-empleado.component.html',
  styleUrl: './reportes-por-empleado.component.scss',
  providers: [ConfirmationService, MessageService]

})
export class ReportesPorEmpleadoComponent {


    empleadosddl: any[] = [];



    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];


      showPdf: boolean = false;

      showPDF()
      {
          this.showPdf = false;
      }

      public safeUrl: SafeResourceUrl;

      constructor(private sanitizer: DomSanitizer,public router: Router, private service: ServiceService,
        private cookieService: CookieService

      ){}

      getSafeUrl(url: string) {
          return this.sanitizer.bypassSecurityTrustResourceUrl(url);
        }


      ngOnInit(): void {

        this.service.getDdlEmpleados().subscribe((data: dropEmpleados[]) => {
            this.empleadosddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });
        }



        onEmpleadoChange(event: Event): void {

          const usuario : String = this.cookieService.get('usuName');

          const selectElement = event.target as HTMLSelectElement;
          const ID : Number = Number.parseInt(selectElement.value);

          this.service.getPreviewPdfEmpleado(usuario,ID).subscribe(
            (url) => {
              this.safeUrl = this.getSafeUrl(url);
            },
            (error) => {
              console.error('Error al obtener la URL del PDF:', error);
            }
          );
        }
}
