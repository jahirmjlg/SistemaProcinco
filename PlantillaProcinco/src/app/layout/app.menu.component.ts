import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import {AppLayoutComponent} from '../layout/app.layout.component';
import {ServiceService} from '../Services/service.service';
import { CookieService } from 'ngx-cookie-service';


@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];
    permisosPermitidos: Set<string> = new Set();

    constructor(private servicioLogin: ServiceService, private cookieService: CookieService, public layoutService: LayoutService, private layoutcomponent: AppLayoutComponent) { }


    showPDF()
    {
        this.layoutcomponent.showPdf = true;
    }


        modelo = [
            {
                label: 'Procinco',
                icon: 'pi pi-fw pi-globe',
                items: [
                    {
                        label: 'Acceso', icon: 'pi pi-fw pi-user',
                        items: [

                            {
                                label: 'Usuarios',
                                icon: 'pi pi-fw pi-user',
                                routerLink: ['/pages/usuarios']
                            },
                            {
                                label: 'Roles',
                                icon: 'pi pi-fw pi-user',
                                routerLink: ['/pages/roles']
                            },
                            {
                                label: 'Login',
                                icon: 'pi pi-fw pi-user',
                                routerLink: ['/auth/login']
                            },
                            {
                                label: 'enviar codigo',
                                icon: 'pi pi-fw pi-user',
                                routerLink: ['/pages/enviarcodigo']
                            },
                        ]
                    },
                ]
            },
            {
                items: [
                    {
                        label: 'General', icon: 'pi pi-fw pi-cog',
                        items: [

                            {
                                label: 'Empleados',
                                icon: 'pi pi-fw pi-cog',
                                routerLink: ['/pages/empleados']
                            },
                            {
                                label: 'Estados',
                                icon: 'pi pi-fw pi-cog',
                                routerLink: ['pages/estados']
                            },
                            {
                                label: 'Ciudades',
                                icon: 'pi pi-fw pi-cog',
                                routerLink: ['/pages/ciudades']
                            },
                            {
                                label: 'Estados Civiles',
                                icon: 'pi pi-fw pi-cog',
                                routerLink: ['/pages/estadosciviles']
                            },

                        ]
                    },
                ]
            },
            {
                items: [
                    {
                        label: 'Procinco', icon: 'pi pi-fw pi-globe',
                        items: [


                            {
                                label: 'Cursos Impartidos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/cursosimp']
                            },
                            {
                                label: 'Cursos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/cursos']
                            },
                            {
                                label: 'Contenido por Cursos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/contenidoporcurso']
                            },
                            {
                                label: 'Contenido',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/contenido']
                            },
                            {
                                label: 'Categorias',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/categorias']
                            },
                            {
                                label: 'Informes de Empleados',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/informesempleados']
                            },
                            {
                                label: 'Titulos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/titulos']
                            },
                            {
                                label: 'Cargos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/cargos']
                            },

                        ]
                    },
                ]
            },
            {
                label: 'Home',
                items: [
                    { label: 'Inicio', icon: 'pi pi-fw pi-home', routerLink: ['/pages/empty'] },
                    { label: 'Dashboard', icon: 'pi pi-fw pi-database', routerLink: ['/uikit/charts'] },
                    { label: 'Drag', icon: 'pi pi-fw pi-table', routerLink: ['/pages/drag'] },

                ]
            },
            {
                label: 'UI Components',
                items: [
                    { label: 'Form Layout', icon: 'pi pi-fw pi-id-card', routerLink: ['/uikit/formlayout'] },
                    { label: 'Input', icon: 'pi pi-fw pi-check-square', routerLink: ['/uikit/input'] },
                    { label: 'Float Label', icon: 'pi pi-fw pi-bookmark', routerLink: ['/uikit/floatlabel'] },
                    { label: 'Invalid State', icon: 'pi pi-fw pi-exclamation-circle', routerLink: ['/uikit/invalidstate'] },
                    { label: 'Button', icon: 'pi pi-fw pi-box', routerLink: ['/uikit/button'] },
                    { label: 'Table', icon: 'pi pi-fw pi-table', routerLink: ['/uikit/table'] },
                    { label: 'List', icon: 'pi pi-fw pi-list', routerLink: ['/uikit/list'] },
                    { label: 'Tree', icon: 'pi pi-fw pi-share-alt', routerLink: ['/uikit/tree'] },
                    { label: 'Panel', icon: 'pi pi-fw pi-tablet', routerLink: ['/uikit/panel'] },
                    { label: 'Overlay', icon: 'pi pi-fw pi-clone', routerLink: ['/uikit/overlay'] },
                    { label: 'Media', icon: 'pi pi-fw pi-image', routerLink: ['/uikit/media'] },
                    { label: 'Menu', icon: 'pi pi-fw pi-bars', routerLink: ['/uikit/menu'], routerLinkActiveOptions: { paths: 'subset', queryParams: 'ignored', matrixParams: 'ignored', fragment: 'ignored' } },
                    { label: 'Message', icon: 'pi pi-fw pi-comment', routerLink: ['/uikit/message'] },
                    { label: 'File', icon: 'pi pi-fw pi-file', routerLink: ['/uikit/file'] },
                    { label: 'Chart', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/uikit/charts'] },
                    { label: 'Misc', icon: 'pi pi-fw pi-circle', routerLink: ['/uikit/misc'] }
                ]
            },
            // {
            //     label: 'Prime Blocks',
            //     items: [
            //         { label: 'Free Blocks', icon: 'pi pi-fw pi-eye', routerLink: ['/blocks'], badge: 'NEW' },
            //         { label: 'All Blocks', icon: 'pi pi-fw pi-globe', url: ['https://www.primefaces.org/primeblocks-ng'], target: '_blank' },
            //     ]
            // },
            {
                label: 'Utilities',
                items: [
                    { label: 'PrimeIcons', icon: 'pi pi-fw pi-prime', routerLink: ['/utilities/icons'] },
                    // { label: 'PrimeFlex', icon: 'pi pi-fw pi-desktop', url: ['https://www.primefaces.org/primeflex/'], target: '_blank' },
                ]
            },
            // {
            //     label: 'Pages',
            //     icon: 'pi pi-fw pi-briefcase',
            //     items: [
            //         {
            //             label: 'Landing',
            //             icon: 'pi pi-fw pi-globe',
            //             routerLink: ['/landing']
            //         },
            //         {
            //             label: 'Auth',
            //             icon: 'pi pi-fw pi-user',
            //             items: [
            //                 {
            //                     label: 'Login',
            //                     icon: 'pi pi-fw pi-sign-in',
            //                     routerLink: ['/auth/login']
            //                 },
            //                 {
            //                     label: 'Error',
            //                     icon: 'pi pi-fw pi-times-circle',
            //                     routerLink: ['/auth/error']
            //                 },
            //                 {
            //                     label: 'Access Denied',
            //                     icon: 'pi pi-fw pi-lock',
            //                     routerLink: ['/auth/access']
            //                 }
            //             ]
            //         },
            //         {
            //             label: 'Crud',
            //             icon: 'pi pi-fw pi-pencil',
            //             routerLink: ['/pages/crud']
            //         },
            //         {
            //             label: 'Timeline',
            //             icon: 'pi pi-fw pi-calendar',
            //             routerLink: ['/pages/timeline']
            //         },
            //         {
            //             label: 'Not Found',
            //             icon: 'pi pi-fw pi-exclamation-circle',
            //             routerLink: ['/notfound']
            //         },
            //         {
            //             label: 'Empty',
            //             icon: 'pi pi-fw pi-circle-off',
            //             routerLink: ['/pages/empty']
            //         },
            //     ]
            // },
            // {
            //     label: 'Procinco',
            //     items: [
            //         {
            //             label: 'Submenu 1', icon: 'pi pi-fw pi-bookmark',
            //             items: [
            //                 {
            //                     label: 'Submenu 1.1', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //                 {
            //                     label: 'Submenu 1.2', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-bookmark' }
            //                     ]
            //                 },
            //             ]
            //         },
            //         {
            //             label: 'Submenu 2', icon: 'pi pi-fw pi-bookmark',
            //             items: [
            //                 {
            //                     label: 'Submenu 2.1', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //                 {
            //                     label: 'Submenu 2.2', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //             ]
            //         }
            //     ]
            // },
            // {
            //     label: 'Get Started',
            //     items: [
            //         {
            //             label: 'Documentation', icon: 'pi pi-fw pi-question', routerLink: ['/documentation']
            //         },
            //         {
            //             label: 'View Source', icon: 'pi pi-fw pi-search', url: ['https://github.com/primefaces/sakai-ng'], target: '_blank'
            //         }
            //     ]
            // }
        ];





        ngOnInit() {
        const admin = this.cookieService.get('esAdmin').toString()

        if (admin != "true")
        {

            const roleId = Number.parseInt(this.cookieService.get('roleID'));

            this.servicioLogin.getPantallasDeRol(roleId).subscribe(pantallasPermitidas => {

                const nombresPermitidos = new Set(pantallasPermitidas.map(pant => pant.pantalla.toLowerCase().trim()));

                const filtrarSubitems = (subitems) => {
                    return subitems.filter(opcion => {
                        const nombreLowerCase = opcion.label.toLowerCase().trim();
                        return nombresPermitidos.has(nombreLowerCase);
                    });
                };

                this.model = this.menuCompleto
                    .map(section => {
                        const itemsFiltrados = section.items.map(subSection => {
                            const subItemsFiltrados = filtrarSubitems(subSection.items || []);
                            return {
                                ...subSection,
                                items: subItemsFiltrados
                            };
                        }).filter(subSection => subSection.items.length > 0);

                        return {
                            ...section,
                            items: itemsFiltrados
                        };
                    })
                    .filter(section => section.items.length > 0);
            });


        }
        else
        {
            this.model = this.menuCompleto;

        }


        }





        menuCompleto = [
            {
                label: 'Procinco',
                icon: 'pi pi-fw pi-globe',
                items: [
                    {
                        label: 'Acceso',
                        icon: 'pi pi-fw pi-user',
                        items: [
                            { label: 'Usuarios', icon: 'pi pi-fw pi-user', routerLink: ['/pages/usuarios'] },
                            { label: 'Roles', icon: 'pi pi-fw pi-user', routerLink: ['/pages/roles'] },
                        ]
                    }
                ]
            },
            {
                items: [
                    {
                        label: 'General',
                        icon: 'pi pi-fw pi-cog',
                        items: [
                            { label: 'Empleados', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/empleados'] },
                            { label: 'Estados', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/estados'] },
                            { label: 'Ciudades', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/ciudades'] },
                            { label: 'Estados Civiles', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/estadosciviles'] },
                            { label: 'Empresas', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/empresas'] },
                            { label: 'Participantes', icon: 'pi pi-fw pi-cog', routerLink: ['/pages/participantes'] },


                        ]
                    }
                ]
            },
            {
                items: [
                    {
                        label: 'Procinco',
                        icon: 'pi pi-fw pi-globe',
                        items: [
                            { label: 'Asignar Cursos', icon: 'pi pi-fw pi-globe', routerLink: ['/pages/asignarcursos'] },

                            { label: 'Contenido por Cursos', icon: 'pi pi-fw pi-globe', routerLink: ['/pages/contenidoporcurso'] },
                            {
                                label: 'Cursos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/treecontenidoporcurso']
                            },
                            {
                                label: 'Contenido',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/contenido']
                            },

                            {
                                label: 'Categorias',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/categorias']
                            },
                            {
                                label: 'Informes de Empleados',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/informesdeempleados']
                            },
                            {
                                label: 'Titulos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/titulos']
                            },
                            {
                                label: 'cargos',
                                icon: 'pi pi-fw pi-globe',
                                routerLink: ['/pages/cargos']
                            },
                        ]
                    }
                ]
            },
            {
                items: [
                    {
                        label: 'Reportes',
                        icon: 'pi pi-folder-open',
                        items: [
                            { label: 'Reporte Cursos Impartidos', icon: 'pi pi-file-pdf', routerLink: ['/pages/reportecursosimp'] },
                            { label: 'Reporte Por Empleado', icon: 'pi pi-file-pdf', routerLink: ['/pages/reporteporempleado'] },
                            { label: 'Participantes Por Curso', icon: 'pi pi-file-pdf', routerLink: ['/pages/participantesporcurso'] },
                            { label: 'Reporte Cursos y Contenidos Por Categoria', icon: 'pi pi-file-pdf', routerLink: ['/pages/reportecursosporcategoria'] },
                            { label: 'Reporte 2', icon: 'pi pi-file-pdf', routerLink: ['/pages/'] },
                        ]
                    }
                ]
            },
            {
                items: [
                    {
                        label: 'Dashboards', icon: 'pi pi-database',
                        items: [


                            {
                                label: 'Dashboards',
                                icon: 'pi pi-fw pi-database',
                                routerLink: ['/uikit/charts']
                            }


                        ]
                    },
                ]
            },
        ];


    }





