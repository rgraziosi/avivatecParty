import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarParticipanteComponent } from './adicionar-participante.component';

describe('AdicionarParticipanteComponent', () => {
  let component: AdicionarParticipanteComponent;
  let fixture: ComponentFixture<AdicionarParticipanteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarParticipanteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarParticipanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
