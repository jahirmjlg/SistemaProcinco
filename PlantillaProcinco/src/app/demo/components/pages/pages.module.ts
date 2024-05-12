import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { AuthGuard } from 'src/app/auth.guard';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        PagesRoutingModule
    ],
    providers: [AuthGuard],
})
export class PagesModule { }
