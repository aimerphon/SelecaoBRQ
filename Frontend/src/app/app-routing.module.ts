import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './navegacao/home/home.component';
import { AlterarUsuarioComponent } from './usuario/alterar-usuario/alterar-usuario.component';
import { CadastrarUsuarioComponent } from './usuario/cadastrar-usuario/cadastrar-usuario.component';
import { ConsultarUsuarioComponent } from './usuario/consultar-usuario/consultar-usuario.component';
import { VisualizarUsuarioComponent } from './usuario/visualizar-usuario/visualizar-usuario.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'consultar-usuario', component: ConsultarUsuarioComponent },
  { path: 'cadastrar-usuario', component: CadastrarUsuarioComponent},
  { path: 'alterar-usuario/:id', component: AlterarUsuarioComponent},
  { path: 'visualizar-usuario/:id', component: VisualizarUsuarioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
