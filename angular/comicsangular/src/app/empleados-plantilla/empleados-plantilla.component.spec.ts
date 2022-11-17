import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadosPlantillaComponent } from './empleados-plantilla.component';

describe('EmpleadosPlantillaComponent', () => {
  let component: EmpleadosPlantillaComponent;
  let fixture: ComponentFixture<EmpleadosPlantillaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpleadosPlantillaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpleadosPlantillaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
