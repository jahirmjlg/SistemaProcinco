import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEstadosComponent } from './list-estados.component';

describe('ListEstadosComponent', () => {
  let component: ListEstadosComponent;
  let fixture: ComponentFixture<ListEstadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListEstadosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListEstadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
