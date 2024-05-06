import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './list-mostrarDrop.component.html',
  styleUrls: [ './list-mostrarDrop.component.scss' ]
})
export class ListMostrarDropComponent  {
  events = [];

  clearEvents(): void {
    this.events = [];
  }

  itemsRemoved(ev, list) {
    this.events.push({text: `itemsRemoved from ${list}`, ev: JSON.stringify(ev)});
  }

  itemsAdded(ev, list) {
    this.events.push({text: `itemsAdded to ${list}`, ev: JSON.stringify(ev)});
  }

  itemsUpdated(ev, list) {
    this.events.push({text: `itemsUpdated in ${list}`, ev: JSON.stringify(ev)});
  }

  selectionChanged(ev, list) {
    this.events.push({text: `selectionChanged in ${list}`, ev: JSON.stringify(ev)});
  }
}
