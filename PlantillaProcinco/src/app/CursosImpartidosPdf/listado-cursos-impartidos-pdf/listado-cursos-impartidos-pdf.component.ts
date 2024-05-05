import { Component } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';


@Component({
  selector: 'app-listado-cursos-impartidos-pdf',
  templateUrl: './listado-cursos-impartidos-pdf.component.html',
  styleUrl: './listado-cursos-impartidos-pdf.component.scss'
})
export class ListadoCursosImpartidosPdfComponent {


    showPdf: boolean = false;

}
