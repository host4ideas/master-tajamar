import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadosSalarioComponent } from './empleados-salario.component';

describe('EmpleadosSalarioComponent', () => {
  let component: EmpleadosSalarioComponent;
  let fixture: ComponentFixture<EmpleadosSalarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpleadosSalarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpleadosSalarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
