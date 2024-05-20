import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmptyDemoRoutingModule } from './emptydemo-routing.module';
import { EmptyDemoComponent } from './emptydemo.component';
import { ChartModule } from 'primeng/chart'

@NgModule({
    imports: [
        CommonModule,
        EmptyDemoRoutingModule,
		ChartModule
    ],
    declarations: [EmptyDemoComponent]
})
export class EmptyDemoModule { }
