import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { ListMostrarDropComponent } from './list-mostrarDrop.component';
import { MultiDragDropComponent } from './multi-drag-drop.component';

@NgModule({
  imports:      [ BrowserModule, FormsModule, DragDropModule ],
  declarations: [ ListMostrarDropComponent, MultiDragDropComponent ],
  bootstrap:    [ ListMostrarDropComponent ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ListMostrarDropModule { }
