import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PadreCochesComponent } from './padre-coches.component';

describe('PadreCochesComponent', () => {
  let component: PadreCochesComponent;
  let fixture: ComponentFixture<PadreCochesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PadreCochesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PadreCochesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
