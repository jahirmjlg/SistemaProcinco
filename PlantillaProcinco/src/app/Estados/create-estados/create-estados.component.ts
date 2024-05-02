
import { Component} from '@angular/core';
import {EstadoService} from '../../Services/estado.service';
import { Estado } from 'src/app/Models/EstadoViewModel';
import {Router} from '@angular/router';
import { Product } from 'src/app/demo/api/product';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA ,NO_ERRORS_SCHEMA}  from '@angular/core';

@Component({
  selector: 'app-create-estados',

  templateUrl: './create-estados.component.html',
  styleUrl: './create-estados.component.scss',
  providers: [ConfirmationService, MessageService]

})
export class CreateEstadosComponent {

    productDialog: boolean = false;

    display: boolean = false;

    deleteProductDialog: boolean = false;

    deleteProductsDialog: boolean = false;

    products: Product[] = [];

    product: Product = {};

    selectedProducts: Product[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];


    //

    images: any[] = [];


    selectedProduct: Product = {};

    visibleSidebar1: boolean = false;

    visibleSidebar2: boolean = false;

    visibleSidebar3: boolean = false;

    visibleSidebar4: boolean = false;

    visibleSidebar5: boolean = false;


    //


    constructor(private productService: ProductService, private messageService: MessageService, private estadoservice: EstadoService, private router: Router, private confirmationService: ConfirmationService) { }

    ngOnInit() {

    this.productService.getProducts().then(data => this.products = data);




}
}
