import { TestBed } from '@angular/core/testing';

import { InformeEmpladosService } from './informe-emplados.service';

describe('InformeEmpladosService', () => {
  let service: InformeEmpladosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InformeEmpladosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
