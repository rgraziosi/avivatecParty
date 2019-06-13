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
  selector: 'avivatec-adicionar-participante',
  templateUrl: './adicionar-participante.component.html',
  styleUrls: ['./adicionar-participante.component.scss']
})
export class AdicionarParticipanteComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public myDatePickerOptions = DateUtils.getMyDatePickerOptions();

  public errors: any[] = [];
  public participante: Participante;
  public locais: Local[];
  public idParticipante;

  constructor(private participanteService: ParticipanteService,
              private toastr: ToastrService,
              private router: Router) {


    // Erro de versão validator e toast - necessário refatoração
    this.validationMessages = {
      nome: {
        required: 'O Nome é requerido.',
        minlength: 'O Nome precisa ter no mínimo 2 caracteres',
        maxlength: 'O Nome precisa ter no máximo 50 caracteres'
      },
      senha: {
        required: 'A Senha é requerida.',
        minlength: 'A Senha precisa ter no mínimo 5 caracteres',
        maxlength: 'A Senha precisa ter no máximo 20 caracteres',
        regex: 'A Senha precisa números e characters',
      },
      email: {
        required: 'O Email é requerido.',
        maxlength: 'O Email precisa ter no máximo 150 caracteres',
        regex: 'O Email precisa ser válido',
      },
      login: {
        required: 'O Login é requerido.',
        minlength: 'O Login precisa ter no mínimo 2 caracteres',
        maxlength: 'O Login precisa ter no máximo 15 caracteres'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
    this.participante = new Participante();


  }

  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  ngOnInit() {
    // Erro de versão do FormGroup - necessário refatoração
    this.participante.nome = '';
    this.participante.email = '';
    this.participante.login = '';
    this.participante.senha = '';
    this.participante.organizador = false;



    this.participanteService.obterLocais()
      .subscribe(locais => this.locais = locais,
        error => this.errors);
  }

  adicionarParticipante(form: FormGroup) {
    if (form.value.melhorDiaHora) { this.participante.melhorDiaHora = DateUtils.getMyDatePickerDate(form.value.melhorDiaHora); }
    if (form.valid) {
      this.participanteService.registrarParticipante(this.participante)
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
    this.toastr.success('Participante Registrado com Sucesso!', 'Oba :D', { timeOut: 2000 });

    this.participante = new Participante();

    setTimeout(() => this.router.navigate(['/acompanhe']), 2000);

  }

}
