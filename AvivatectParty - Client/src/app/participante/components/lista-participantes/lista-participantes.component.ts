import { Component, OnInit } from '@angular/core';
import { Participante } from '../../models/participante';
import { ParticipanteService } from '../../services/participante.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'avivatec-lista-participantes',
  templateUrl: './lista-participantes.component.html',
  styleUrls: ['./lista-participantes.component.scss'],
})
export class ListaParticipantesComponent implements OnInit {

  public participantes: Participante[];
  errorMessage: string;
  errors: any[];

  constructor(private participanteService: ParticipanteService, private toastr: ToastrService, ) { }

  ngOnInit() {
    this.participanteService.obterTodos()
      .subscribe(participantes => this.participantes = participantes,
        error => this.errorMessage);
  }

  excluirParticipante(id) {
    this.participanteService.excluirParticipante(id)
      .subscribe(
        result => { this.onExcludeComplete(id); },
        fail => { this.onError(fail); }
      );
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onExcludeComplete(idExclude) {
    this.errors = [];
    this.participantes.forEach((element, index) => {
      if (element.id == idExclude) { this.participantes.splice(index, 1); }
    });
    this.toastr.success('Participante Excluido com Sucesso! o alert de confirmação vem na proxima versão', 'Eita', { timeOut: 3000 });
  }

}
