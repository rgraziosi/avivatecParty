import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcompanheComponent } from './acompanhe.component';

describe('AcompanheComponent', () => {
  let component: AcompanheComponent;
  let fixture: ComponentFixture<AcompanheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcompanheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcompanheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
