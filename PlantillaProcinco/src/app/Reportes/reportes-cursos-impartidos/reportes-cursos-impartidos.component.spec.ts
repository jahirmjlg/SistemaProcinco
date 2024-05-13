import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportesCursosImpartidosComponent } from './reportes-cursos-impartidos.component';

describe('ReportesCursosImpartidosComponent', () => {
  let component: ReportesCursosImpartidosComponent;
  let fixture: ComponentFixture<ReportesCursosImpartidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReportesCursosImpartidosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReportesCursosImpartidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
