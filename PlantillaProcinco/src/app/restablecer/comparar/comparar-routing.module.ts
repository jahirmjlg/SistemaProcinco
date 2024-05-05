import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CompararComponent } from './comparar.component'; 

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: CompararComponent }
    ])],
    exports: [RouterModule]
})
export class CompararRoutingModule { }
