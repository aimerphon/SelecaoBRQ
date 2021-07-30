import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioModel } from '../models/usuario.model';
import { UsuarioService } from '../services/usuario.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html'
})
export class CadastrarUsuarioComponent implements OnInit {

  usuarioForm!: FormGroup;
  opcaoSexo!: string;
  constructor(private router: Router, private route: ActivatedRoute,
    private usuariosService: UsuarioService, private formBuilder: FormBuilder,
    protected toastr: ToastrService) { }

  ngOnInit(): void {
    this.opcaoSexo = "M";
    this.usuarioForm = this.formBuilder.group({
      'usuarioId': null,
      'nome': [null, Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(60),
        Validators.required])],
      'cpf': [null, Validators.required],
      'email': [null, Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(60),
        Validators.required])],
      'telefone': [null, Validators.compose([
        Validators.minLength(11),
        Validators.maxLength(11),
        Validators.required])],
      'sexo': [null, Validators.required],
      'dataNascimento': [null, Validators.required]
    })
  }

  adicionarUsuario(form: UsuarioModel) {
    try {
      this.usuariosService.adicionarUsuario(form)
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

  cancelarCadastro() {
    this.router.navigate(['/consultar-usuario']);
  }
}
