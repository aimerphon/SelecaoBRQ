import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpParams, HttpClient } from '@angular/common/http';
import { UsuarioModel } from "../models/usuario.model";
import { Response } from "../../shared/models/response"

@Injectable({
    providedIn: 'root'
})
export class UsuarioService {

    //private url = "https://localhost:44314/api/UsuarioCache/"
    private url = "https://localhost:44314/api/UsuarioBanco/"

    constructor(private http: HttpClient) {
     }

    consultarTodosUsuario(): Observable<Response> {
        return this.http.get<Response>(this.url + "ObterTodos");
    }

    consultarUsuarioPorId(id: number) {
        return this.http.get<Response>(this.url + "ObterPorId/" + id.toString());
    }

    adicionarUsuario(usuario: UsuarioModel) {
        return this.http.post<Response>(this.url + "AdicionarUsuario", usuario);
    }

    alterarUsuario(id: number, usuario: UsuarioModel) {
        usuario.id = id;
        return this.http.put<Response>(this.url + "AlterarUsuario/" + id, usuario);
    }

    excluirUsuario(id: number) {
        return this.http.delete<Response>(this.url + "ExcluirUsuario/" + id.toString());
    }
}