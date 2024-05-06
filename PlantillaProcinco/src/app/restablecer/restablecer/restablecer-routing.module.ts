import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RestablecerComponent } from './restablecer.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: RestablecerComponent }
    ])],
    exports: [RouterModule]
})
export class restablecerRoutingModule { }
