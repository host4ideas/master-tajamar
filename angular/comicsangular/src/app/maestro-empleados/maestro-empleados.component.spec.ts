import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaestroEmpleadosComponent } from './maestro-empleados.component';

describe('MaestroEmpleadosComponent', () => {
  let component: MaestroEmpleadosComponent;
  let fixture: ComponentFixture<MaestroEmpleadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaestroEmpleadosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaestroEmpleadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
