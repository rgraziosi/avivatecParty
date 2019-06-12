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

@NgModule({
  declarations: [AdicionarParticipanteComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MyDatePickerModule,
    BrowserAnimationsModule,
  ],
  providers: [
    Title,
    SeoService,
    ParticipanteService
  ],
  exports: [AdicionarParticipanteComponent]
})
export class ParticipanteModule { }
