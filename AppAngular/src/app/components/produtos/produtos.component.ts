import { Component, OnInit } from '@angular/core';
import { ProdutosService } from '../../produtos.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Produto } from '../../Produto';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrl: './produtos.component.css'
})
export class ProdutosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string | undefined;
  produtos: Produto[] = [];
  filtroNome: string = '';
  filtroSetor: string =''

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;
  constructor(private produtosService: ProdutosService) { }

  ngOnInit(): void {


    this.produtosService.BuscarTodos().subscribe(result => {
      this.produtos = result;
    })

  }

  ExibirFormCadastro(): void {

    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormulario = 'Novo Produto'
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      valor: new FormControl(null),
      setor: new FormControl(null)
    })
  }

  ExibirFormEditar(id: number): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;

    this.produtosService.BuscarPorID(id).subscribe(result => {
      this.tituloFormulario = `Atualizar Produto : ${result.nome}`
      this.formulario = new FormGroup({
        id: new FormControl(result.id),
        nome: new FormControl(result.nome),
        valor: new FormControl(result.valor),
        setor: new FormControl(result.setor)
      })
    })
  }

  EnviarForm(): void {
    const produto: Produto = this.formulario.value;

    if (produto.id > 0) {
      this.produtosService.Editar(produto).subscribe(result => {
        this.visibilidadeTabela = true;
        this.visibilidadeFormulario = false
        alert('Produto editado com sucesso!')
        this.produtosService.BuscarTodos().subscribe(result => {
          this.produtos = result;
        })
      })
    }
    else {
      this.produtosService.Salvar(produto).subscribe(result => {
        this.visibilidadeTabela = true;
        this.visibilidadeFormulario = false
        alert('Produto salvo com sucesso!')
        this.produtosService.BuscarTodos().subscribe(result => {
          this.produtos = result;
        })
      })
    }
  }

  produtosFiltrados() {
    return this.produtos.filter(produto => 
      produto.nome.toLowerCase().includes(this.filtroNome.toLowerCase()) &&
      produto.setor.toLowerCase().includes(this.filtroSetor.toLowerCase())
    );
  }

  DeletarProduto(id: number): void {
    const produto = this.produtos.find(p => p.id === id);
    if (produto && window.confirm(`Tem certeza que deseja excluir o produto: ${produto.nome}?`)) {
      this.produtosService.Deletar(id).subscribe(() => {
        alert('Produto excluído com sucesso!');
        this.produtosService.BuscarTodos().subscribe(result => {
          this.produtos = result;
        });
      });
    }
  }
  

  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false
  }
}
