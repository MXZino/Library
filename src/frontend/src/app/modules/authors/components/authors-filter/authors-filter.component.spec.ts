import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorsFilterComponent } from './authors-filter.component';

describe('AuthorsFilterComponent', () => {
  let component: AuthorsFilterComponent;
  let fixture: ComponentFixture<AuthorsFilterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AuthorsFilterComponent]
    });
    fixture = TestBed.createComponent(AuthorsFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
