import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/app.layout.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: 'reestablecer', data: { breadcrumb: 'EnviarCodigo' }, loadChildren: () => import('./restablecer/validacion/validacion.module').then(m => m.ValidacionModule) },
            { path: 'compararcodigo', data: { breadcrumb: 'CompararCodigo' }, loadChildren: () => import('./restablecer/comparar/comparar.module').then(m => m.CompararModule) },

            { path: 'reestablecer1', data: { breadcrumb: 'Restablecer' }, loadChildren: () => import('./restablecer/restablecer/restablecer.module').then(m => m.restablecerModule)},


            { path: 'login', loadChildren: () => import('./demo/components/auth/login/login.module').then(m => m.LoginModule) },
            { path: '', redirectTo: '/login', pathMatch: 'full' },
            {
                path: '', component: AppLayoutComponent,
                children: [
                    { path: 'dash', loadChildren: () => import('./demo/components/dashboard/dashboard.module').then(m => m.DashboardModule) },
                    { path: 'uikit', loadChildren: () => import('./demo/components/uikit/uikit.module').then(m => m.UIkitModule) },
                    { path: 'utilities', loadChildren: () => import('./demo/components/utilities/utilities.module').then(m => m.UtilitiesModule) },
                    { path: 'documentation', loadChildren: () => import('./demo/components/documentation/documentation.module').then(m => m.DocumentationModule) },
                    { path: 'blocks', loadChildren: () => import('./demo/components/primeblocks/primeblocks.module').then(m => m.PrimeBlocksModule) },
                    { path: 'pages', loadChildren: () => import('./demo/components/pages/pages.module').then(m => m.PagesModule) }
                ]
            },
            { path: 'auth', loadChildren: () => import('./demo/components/auth/auth.module').then(m => m.AuthModule) },
            { path: 'landing', loadChildren: () => import('./demo/components/landing/landing.module').then(m => m.LandingModule) },
            { path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
