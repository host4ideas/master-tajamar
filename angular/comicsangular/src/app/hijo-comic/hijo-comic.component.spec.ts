import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HijoComicComponent } from './hijo-comic.component';

describe('HijoComicComponent', () => {
  let component: HijoComicComponent;
  let fixture: ComponentFixture<HijoComicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HijoComicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HijoComicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
