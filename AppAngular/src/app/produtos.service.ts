import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApplicationRef, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from './Produto';

const httpOptions : Object = {
  heares: new HttpHeaders({
    'Content-Type': 'application/json'
  })
  
}

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {
  url = 'http://localhost:5206/api/Produto'
  constructor(private http: HttpClient) {
   }

   BuscarTodos(): Observable<Produto[]>{
    const apiUrl = `${this.url}/BuscarTodos`;
    return this.http.get<Produto[]>(apiUrl)
   }

   BuscarPorID(id: number): Observable<Produto>{
    const apiUrl = `${this.url}/BuscarPorId${id}`;
    return this.http.get<Produto>(apiUrl)
   }

   Salvar(produto: Produto): Observable<any>{
    const apiUrl = `${this.url}/adicionar`;
    return this.http.post<Produto>(apiUrl, produto, httpOptions)
   }

   Editar(produto: Produto) : Observable<any>{
    const apiUrl = `${this.url}/editar`;
    return this.http.put<Produto>(apiUrl, produto, httpOptions)
   }

   Deletar(id: number) : Observable<any>{
    const apiUrl = `${this.url}/deletar?id=${id}`;

    return this.http.delete<number>(apiUrl, httpOptions);
   }
}
