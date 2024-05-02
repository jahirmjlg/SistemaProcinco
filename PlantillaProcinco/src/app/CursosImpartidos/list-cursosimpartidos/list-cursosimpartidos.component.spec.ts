import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCursosimpartidosComponent } from './list-cursosimpartidos.component';

describe('ListCursosimpartidosComponent', () => {
  let component: ListCursosimpartidosComponent;
  let fixture: ComponentFixture<ListCursosimpartidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListCursosimpartidosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListCursosimpartidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
