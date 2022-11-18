import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHostpitalComponent } from './create-hostpital.component';

describe('CreateHostpitalComponent', () => {
  let component: CreateHostpitalComponent;
  let fixture: ComponentFixture<CreateHostpitalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateHostpitalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateHostpitalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
