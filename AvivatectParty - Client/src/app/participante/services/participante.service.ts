import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';

import { HttpClient } from '@angular/common/http';
import { Participante, Local } from '../models/participante';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class ParticipanteService extends BaseService {

  constructor(private http: HttpClient) { super(); }

  obterLocais(): Observable<Local[]> {
    return this.http
        .get<Local[]>(this.UrlService + 'participantes/locais')
        .catch(super.serviceError);
  }

  obterTodos(): Observable<Participante[]> {
    return this.http
        .get<Participante[]>(this.UrlService + 'participantes')
        .catch(super.serviceError);
  }

  obterParticipante(id: string): Observable<Participante> {
      return this.http
          .get<Participante>(this.UrlService + 'participantes/' + id)
          .catch(super.serviceError);
  }

  registrarParticipante(participante: Participante): Observable<Participante> {
    const response = this.http
        .post(this.UrlService + 'participantes', participante)
        .map(super.extractData)
        .catch(super.serviceError);

    return response;
  }

  atualizarParticipante(participante: Participante): Observable<Participante> {
    const response = this.http
        .put(this.UrlService + 'participantes', participante)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

  excluirParticipante(id: string): Observable<Participante> {
    const response = this.http
        .delete(this.UrlService + 'participante/' + id)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

}
