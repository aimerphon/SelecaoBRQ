import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../models/usuario.model';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-alterar-usuario',
  templateUrl: './alterar-usuario.component.html'
})
export class AlterarUsuarioComponent implements OnInit {

  usuarioId!: number;
  usuarioForm!: FormGroup;
  nome: String = '';
  cpf: String = '';
  email: String = '';
  telefone: String = '';
  sexo: String = '';
  dataNascimento: String = '';
  opcaoSexo!: string;

  constructor(private router: Router, private route: ActivatedRoute,
    private usuarioService: UsuarioService, private formBuilder: FormBuilder,
    protected toastr: ToastrService) { }

  ngOnInit(): void {
    this.opcaoSexo = "M";
    this.ConsultarUsuarioPorId(this.route.snapshot.params['id']);
    this.usuarioForm = this.formBuilder.group({
      'usuarioId': null,
      'nome': [null, Validators.required],
      'cpf': [null, Validators.required],
      'email': [null, Validators.required],
      'telefone': [null, Validators.required],
      'sexo': [null, Validators.required],
      'dataNascimento': [null, Validators.required]
    })
  }

  ConsultarUsuarioPorId(id: number) {
    this.usuarioService.consultarUsuarioPorId(id)
      .subscribe(response => {
        if (response.success) {
          let usuarioConsulta = response.data as UsuarioModel;

          this.usuarioId = usuarioConsulta.id;
          this.usuarioForm.setValue({
            usuarioId: usuarioConsulta.id,
            nome: usuarioConsulta.nome,
            cpf: usuarioConsulta.cpf,
            email: usuarioConsulta.email,
            telefone: usuarioConsulta.telefone,
            sexo: usuarioConsulta.sexo,
            dataNascimento: usuarioConsulta.dataNascimento,
          })
        }
        else {
          this.toastr.error(response.errors[0]);
        }
      })
  }

  alterarUsuario(form: UsuarioModel) {
    try {
      this.usuarioService.alterarUsuario(this.usuarioId, form)
        .subscribe(response => {
          if (response.success) {
            this.router.navigate(['/consultar-usuario']);
            this.toastr.success("Operacção realizada com sucesso.");
          }
          else {
            this.toastr.error(response.errors[0]);
          }
        });
    } catch (error) {
      this.toastr.error(error.message);
    }
  }

  cancelarAlteracao() {
    this.router.navigate(['/consultar-usuario']);
  }
}
