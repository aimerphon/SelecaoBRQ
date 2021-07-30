import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { UsuarioModel } from '../models/usuario.model';
import { UsuarioService } from '../services/usuario.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ExcluirModalComponent } from '../excluir-modal/excluir-modal.component';
import { EventEmitterService } from 'src/app/shared/event-emitter.service';

@Component({
  selector: 'app-consultar-usuario',
  templateUrl: './consultar-usuario.component.html'
})
export class ConsultarUsuarioComponent implements OnInit {

  displayedColumns: string[] = ['nome', 'cpf', 'email', 'telefone', 'sexo', 'dataNascimento', 'editar', 'detalhe', 'excluir'];
  usuarios!: UsuarioModel[];
  dataSource = new MatTableDataSource<UsuarioModel>(this.usuarios);
  
  encontradoRegistro: boolean = false;
  public mensagemNenhumRegistro: string = "Nenhum registro encontrado";

  constructor(private usuarioService: UsuarioService,
    protected toastr: ToastrService, public matDialog: MatDialog,
    private eventEmitterService: EventEmitterService) { }

  ngOnInit(): void {
    this.consultarTodosUsuarios(); 
    if (this.eventEmitterService.subsVar==undefined) {    
      this.eventEmitterService.subsVar = this.eventEmitterService.    
      invokeFirstComponentFunction.subscribe((name:string) => {    
        this.consultarTodosUsuarios();    
      });    
    }   
  }

  consultarTodosUsuarios() {
    try {
      debugger;
      this.usuarioService.consultarTodosUsuario()
        .subscribe(res => {
          if (res.success) {
            this.usuarios = res.data as UsuarioModel[];
            this.encontradoRegistro = this.usuarios.length > 0;
          }
          else {
            this.toastr.error(res.errors[0]);
          }
        });
    } catch (error) {
      this.usuarios = [ { id: 1, nome: "tetes", cpf: "123.123.123.11", email: "aaa@mail.com", telefone: "(71) 99999-9999", sexo: "M", dataNascimento: new Date(Date.now()) }]
      this.toastr.error(error.message);
    }
  }

  openExclusaoModal(id: number) {
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modal-component";
    dialogConfig.height = "150px";
    dialogConfig.width = "600px";
    dialogConfig.data = { idusuario : id };
    const modalDialog = this.matDialog.open(ExcluirModalComponent, dialogConfig);
  }
}