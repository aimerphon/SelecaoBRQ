import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../models/usuario.model';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-visualizar-usuario',
  templateUrl: './visualizar-usuario.component.html'
})
export class VisualizarUsuarioComponent implements OnInit {

  usuarioForm!: FormGroup;
  nome: String = '';
  cpf: String = '';
  email: String = '';
  telefone: String = '';
  sexo: String = '';
  dataNascimento: String = '';
  public desabilitar: boolean = true;
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
    
    this.usuarioForm.controls['nome'].disable();
    this.usuarioForm.controls['cpf'].disable();
    this.usuarioForm.controls['email'].disable();
    this.usuarioForm.controls['telefone'].disable();
    this.usuarioForm.controls['sexo'].disable();
    this.usuarioForm.controls['dataNascimento'].disable();
  }

  ConsultarUsuarioPorId(id: number) {
    this.usuarioService.consultarUsuarioPorId(id)
      .subscribe(response => {
        if (response.success) {
          let usuarioConsulta = response.data as UsuarioModel;

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

  voltar() {
    this.router.navigate(['/consultar-usuario']);
  }
}
