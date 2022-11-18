import { TestBed } from '@angular/core/testing';

import { PantillaService } from './pantilla.service';

describe('PantillaService', () => {
  let service: PantillaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PantillaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
