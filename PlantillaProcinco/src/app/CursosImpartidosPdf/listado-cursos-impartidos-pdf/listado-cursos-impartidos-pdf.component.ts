import { Component } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';
import { Router } from 'express';
import { CookieService } from 'ngx-cookie-service';


@Component({
  selector: 'app-listado-cursos-impartidos-pdf',
  templateUrl: './listado-cursos-impartidos-pdf.component.html',
  styleUrl: './listado-cursos-impartidos-pdf.component.scss'
})
export class ListadoCursosImpartidosPdfComponent {


    constructor(
        // private cursoservice: CursoService,
        private router: Router,
         private cookieService: CookieService,
        private messageService: MessageService) {


}


}
