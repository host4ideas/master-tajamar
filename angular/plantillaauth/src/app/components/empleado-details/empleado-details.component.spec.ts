import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadoDetailsComponent } from './empleado-details.component';

describe('EmpleadoDetailsComponent', () => {
  let component: EmpleadoDetailsComponent;
  let fixture: ComponentFixture<EmpleadoDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpleadoDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpleadoDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
