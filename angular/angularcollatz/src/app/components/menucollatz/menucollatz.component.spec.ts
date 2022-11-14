import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenucollatzComponent } from './menucollatz.component';

describe('MenucollatzComponent', () => {
  let component: MenucollatzComponent;
  let fixture: ComponentFixture<MenucollatzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenucollatzComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenucollatzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
