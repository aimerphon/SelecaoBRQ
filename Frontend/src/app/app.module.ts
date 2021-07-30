import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HomeComponent } from './navegacao/home/home.component';
import { ConsultarUsuarioComponent } from './usuario/consultar-usuario/consultar-usuario.component';
import { CadastrarUsuarioComponent } from './usuario/cadastrar-usuario/cadastrar-usuario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { UsuarioService } from './usuario/services/usuario.service';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog' 
import { AlterarUsuarioComponent } from './usuario/alterar-usuario/alterar-usuario.component';
import { VisualizarUsuarioComponent } from './usuario/visualizar-usuario/visualizar-usuario.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { SomenteNumerosDirective } from './shared/somentenumeros.directive';
import { NgxMaskModule } from 'ngx-mask';
import { ExcluirModalComponent } from './usuario/excluir-modal/excluir-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent,
    ConsultarUsuarioComponent,
    CadastrarUsuarioComponent,
    AlterarUsuarioComponent,
    VisualizarUsuarioComponent,
    SomenteNumerosDirective,
    ExcluirModalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatTableModule,
    MatFormFieldModule,
    MatDialogModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({ preventDuplicates: true, progressBar: true, positionClass: 'toast-top-right' }),
    NgxMaskModule.forRoot()
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/'},
    { provide: HttpClientModule}, 
    { provide: UsuarioService }
  ],
  bootstrap: [AppComponent],
  entryComponents: [ExcluirModalComponent]
})
export class AppModule { }
