import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonajesSerieComponent } from './personajes-serie.component';

describe('PersonajesSerieComponent', () => {
  let component: PersonajesSerieComponent;
  let fixture: ComponentFixture<PersonajesSerieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonajesSerieComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonajesSerieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
