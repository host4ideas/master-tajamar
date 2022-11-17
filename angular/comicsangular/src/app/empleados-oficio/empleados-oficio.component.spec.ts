import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadosOficioComponent } from './empleados-oficio.component';

describe('EmpleadosOficioComponent', () => {
  let component: EmpleadosOficioComponent;
  let fixture: ComponentFixture<EmpleadosOficioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpleadosOficioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpleadosOficioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
