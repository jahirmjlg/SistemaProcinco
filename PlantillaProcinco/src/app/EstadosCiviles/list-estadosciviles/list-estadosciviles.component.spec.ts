import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEstadoscivilesComponent } from './list-estadosciviles.component';

describe('ListEstadoscivilesComponent', () => {
  let component: ListEstadoscivilesComponent;
  let fixture: ComponentFixture<ListEstadoscivilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListEstadoscivilesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListEstadoscivilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
