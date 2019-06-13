import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaParticipantesComponent } from './lista-participantes.component';

describe('ListaParticipantesComponent', () => {
  let component: ListaParticipantesComponent;
  let fixture: ComponentFixture<ListaParticipantesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaParticipantesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaParticipantesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
