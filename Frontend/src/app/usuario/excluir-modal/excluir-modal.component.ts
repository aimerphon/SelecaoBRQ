import { Component, Inject, OnInit } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventEmitterService } from 'src/app/shared/event-emitter.service';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-excluir-modal',
  templateUrl: './excluir-modal.component.html'
})
export class ExcluirModalComponent implements OnInit {

  idUsuario!: number;
  constructor(private router: Router, private route: ActivatedRoute,
    private usuarioService: UsuarioService,
    protected toastr: ToastrService,
    public dialogRef: MatDialogRef<ExcluirModalComponent>,
    @Inject(MAT_DIALOG_DATA) data: any,
    private eventEmitterService: EventEmitterService) {
    this.idUsuario = data.idusuario;
  }

  ngOnInit(): void {
  }
  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  excluirUsuario() {
    try {
      this.usuarioService.excluirUsuario(this.idUsuario)
        .subscribe(response => {

          if (response.success) {
            this.toastr.success("Operacção realizada com sucesso.");
            this.firstComponentFunction();
          }
          else {
            this.toastr.error(response.errors[0]);
          }
        });
      this.router.navigate(['/consultar-usuario']);
      this.cancelarExclusao();
    } catch (error) {
      this.cancelarExclusao();
      this.toastr.error(error.message);
    }
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  cancelarExclusao() {
    this.dialogRef.close();
  }
    
  firstComponentFunction(){    
    this.eventEmitterService.onFirstComponentButtonClick();    
  }  
}
