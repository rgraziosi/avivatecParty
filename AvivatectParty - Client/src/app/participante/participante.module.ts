import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdicionarParticipanteComponent } from './components/adicionar-participante/adicionar-participante.component';
import { Title } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SeoService } from '../core/services/seo.service';
import { ParticipanteService } from './services/participante.service';
import { HttpClientModule } from '@angular/common/http';
import { MyDatePickerModule } from 'mydatepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListaParticipantesComponent } from './components/lista-participantes/lista-participantes.component';
import { RouterModule } from '@angular/router';
import { EditarParticipanteComponent } from './components/editar-participante/editar-participante.component';

@NgModule({
  declarations: [AdicionarParticipanteComponent, ListaParticipantesComponent, EditarParticipanteComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MyDatePickerModule,
    BrowserAnimationsModule,
    RouterModule
  ],
  providers: [
    Title,
    SeoService,
    ParticipanteService
  ],
  exports: [AdicionarParticipanteComponent, ListaParticipantesComponent, EditarParticipanteComponent]
})
export class ParticipanteModule { }
