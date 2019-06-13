import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { DateUtils } from 'src/app/common/data-type-utils/date-utils';
import { ParticipanteService } from '../../services/participante.service';
import { Participante, Local } from '../../models/participante';
import { GenericValidator } from 'src/app/common/validation/generic-form-validator';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'avivatec-editar-participante',
  templateUrl: './editar-participante.component.html',
  styleUrls: ['./editar-participante.component.scss']
})
export class EditarParticipanteComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public myDatePickerOptions = DateUtils.getMyDatePickerOptions();

  public errors: any[] = [];
  public participante: Participante;
  public locais: Local[];
  public idParticipante;

  constructor(private participanteService: ParticipanteService,
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) {


    this.participante = new Participante();
  }


  ngOnInit() {
    this.route.params.subscribe(params => {
      this.participanteService.obterParticipante(params.id)
        .subscribe(participante => {
          this.participante = participante;
          this.participante.melhorDiaHora = DateUtils.setMyDatePickerDate(new Date(participante.melhorDiaHora));
        },
          error => this.errors);
    });

    this.participanteService.obterLocais()
      .subscribe(locais => this.locais = locais,
        error => this.errors);
  }

  editarParticipante(form: FormGroup) {
    if (form.value.melhorDiaHora) { this.participante.melhorDiaHora = DateUtils.getMyDatePickerDate(form.value.melhorDiaHora); }
    if (form.valid) {
      this.participanteService.atualizarParticipante(this.participante)
        .subscribe(
          result => { this.onSaveComplete(); },
          fail => { this.onError(fail); }
        );
    }
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onSaveComplete() {
    this.errors = [];
    this.toastr.success('Participante Editado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.participante = new Participante();

    setTimeout(() => this.router.navigate(['/acompanhe']), 2000);

  }

}
