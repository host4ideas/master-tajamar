import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComicsInyeccionComponent } from './comics-inyeccion.component';

describe('ComicsInyeccionComponent', () => {
  let component: ComicsInyeccionComponent;
  let fixture: ComponentFixture<ComicsInyeccionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComicsInyeccionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComicsInyeccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
