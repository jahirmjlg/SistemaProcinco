import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { dropCursos } from 'src/app/Models/CursosViewModel';
import { ServiceService } from 'src/app/Services/service.service';

@Component({
  selector: 'app-participantes-por-curso',
  templateUrl: './participantes-por-curso.component.html',
  styleUrl: './participantes-por-curso.component.scss'
})
export class ParticipantesPorCursoComponent {




    cursosddl: any[] = [];
    fechasddl: any[] = [];

    IDCurso:Number;

    formSelect: FormGroup;


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
        private cookieService: CookieService, private formBuilder: FormBuilder

      ){}

      getSafeUrl(url: string) {
          return this.sanitizer.bypassSecurityTrustResourceUrl(url);
        }


      ngOnInit(): void {

        this.formSelect = this.formBuilder.group({
            curso_id: ['0', [Validators.required]],
            fecha_id: ['0', [Validators.required]],
        })

        this.service.getDdlCursos().subscribe((data: dropCursos[]) => {
            this.cursosddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });
        }


        onCursoChange(ID) {
            if (ID !== '0') {
                this.IDCurso = ID;
              this.service.getDdlFechas(ID).subscribe(
                (data: any) => {
                    if(data[1].text === '1999-01-01 00:00')
                        {
                            data[1].text = 'Todas las fechas'
                        }
                  this.fechasddl = data;
                  this.formSelect.get('fecha_id').setValue('0');
                },
                error => {
                  console.error('Errorr:', error);
                }
              );
            } else {
              this.fechasddl = [];
            }
          }


        onFechaChange(data): void {

          const usuario : String = this.cookieService.get('usuName');

          this.service.getPreviewPdfParticipante(usuario, this.IDCurso,data).subscribe(
            (url) => {
              this.safeUrl = this.getSafeUrl(url);
            },
            (error) => {
              console.error('Error al obtener la URL del PDF:', error);
            }
          );
        }
}
