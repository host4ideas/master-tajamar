import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PadreComicsComponent } from './padre-comics.component';

describe('PadreComicsComponent', () => {
  let component: PadreComicsComponent;
  let fixture: ComponentFixture<PadreComicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PadreComicsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PadreComicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
