import { Component } from '@angular/core';


import {CursosImpartidosService} from '../../Services/cursosimpartidos.service';
import {Router} from '@angular/router';

import { Product } from 'src/app/demo/api/product';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CursosImpartidos } from 'src/app/Models/CursosImpartidos';

@Component({
  selector: 'app-list-cursosimpartidos',
  templateUrl: './list-cursosimpartidos.component.html',
  styleUrl: './list-cursosimpartidos.component.scss'
})
export class ListCursosimpartidosComponent {

    productDialog: boolean = false;

    deleteProductDialog: boolean = false;

    deleteProductsDialog: boolean = false;

    products: Product[] = [];

    product: Product = {};

    selectedProducts: Product[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    cursosimpartidos!:CursosImpartidos[];


    constructor(private productService: ProductService, private cursosimpartidosservice: CursosImpartidosService, private router: Router) { }

    ngOnInit() {


        // Respuesta de la api
        this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
            console.log(Response.data);
            this.cursosimpartidos = Response.data;

          }, error=>{
            console.log(error);
          });

          //

        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }

    openNew() {
        this.product = {};
        this.submitted = false;
        this.productDialog = true;
    }

    deleteSelectedProducts() {
        this.deleteProductsDialog = true;
    }

    editProduct(product: Product) {
        this.product = { ...product };
        this.productDialog = true;
    }

    deleteProduct(product: Product) {
        this.deleteProductDialog = true;
        this.product = { ...product };
    }





    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.products.length; i++) {
            if (this.products[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        let id = '';
        const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (let i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    }
}
