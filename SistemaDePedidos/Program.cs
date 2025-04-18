﻿using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDePedidos.Domain;
using SistemaDePedidos.ValueObjects;
using SistemaDePedidos.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
  public static class Program
  {
    public static void Main()
    {
      var db = new ApplicationContext();
      AplicarMigracoes(db);
      InserirDados(db);
      InserirDadosEmMassa(db);
      ConsultarDados(db);
      //CadastrarPedido(db);
      //ConsultarPedidoCarregamentoAdiantado(db);
      //AtualizarDados(db);
      //RemoverRegistro(db);
    }

    private static void AplicarMigracoes(ApplicationContext db)
    {
      db.Database.Migrate();
    }

    private static void RemoverRegistro(ApplicationContext db)
    {
      //var cliente = db.Clientes.Find(2);
      var cliente = new Cliente { Id = 3 };
      //db.Clientes.Remove(cliente);
      //db.Remove(cliente);
      db.Entry(cliente).State = EntityState.Deleted;

      db.SaveChanges();
    }

    private static void AtualizarDados(ApplicationContext db)
    {
      //var cliente = db.Clientes.Find(1);

      var cliente = new Cliente
      {
        Id = 1
      };

      var clienteDesconectado = new
      {
        Nome = "Cliente Desconectado Passo 3",
        Telefone = "7966669999"
      };

      db.Attach(cliente);
      db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);

      //db.Clientes.Update(cliente);
      db.SaveChanges();
    }

    private static void ConsultarPedidoCarregamentoAdiantado(ApplicationContext db)
    {
      var pedidos = db
          .Pedidos
          .Include(p => p.Itens)
              .ThenInclude(p => p.Produto)
          .ToList();

      Console.WriteLine(pedidos.Count);
    }

    private static void CadastrarPedido(ApplicationContext db)
    {
      var cliente = db.Clientes.FirstOrDefault();
      var produto = db.Produtos.FirstOrDefault();

      var pedido = new Pedido
      {
        ClienteId = cliente.Id,
        IniciadoEm = DateTime.Now,
        FinalizadoEm = DateTime.Now,
        Observacao = "Pedido Teste",
        Status = StatusPedido.Analise,
        TipoFrete = TipoFrete.SemFrete,
        Itens = new List<PedidoItem>
                 {
                     new PedidoItem
                     {
                         ProdutoId = produto.Id,
                         Desconto = 0,
                         Quantidade = 1,
                         Valor = 10,
                     }
                 }
      };

      db.Pedidos.Add(pedido);

      db.SaveChanges();
    }

    private static void ConsultarDados(ApplicationContext db)
    {
      //var consultaPorSintaxe = (from c in db.Clientes where c.Id>0 select c).ToList();
      var consultaPorMetodo = db.Clientes
          .Where(p => p.Id > 0)
          .OrderBy(p => p.Id)
          .ToList();

      foreach (var cliente in consultaPorMetodo)
      {
        Console.WriteLine($"Consultando Cliente: {cliente.Id}");
        //db.Clientes.Find(cliente.Id);
        db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
      }
    }

    private static void InserirDadosEmMassa(ApplicationContext db)
    {
      var produto = new Produto
      {
        Descricao = "Produto Teste",
        CodigoBarras = "1234567891231",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };

      var cliente = new Cliente
      {
        Nome = "Rafael Almeida",
        CEP = "99999000",
        Cidade = "Itabaiana",
        Estado = "SE",
        Telefone = "99000001111",
      };

      var listaClientes = new[]
      {
                new Cliente
                {
                    Nome = "Teste 1",
                    CEP = "99999000",
                    Cidade = "Itabaiana",
                    Estado = "SE",
                    Telefone = "99000001115",
                },
                new Cliente
                {
                    Nome = "Teste 2",
                    CEP = "99999000",
                    Cidade = "Itabaiana",
                    Estado = "SE",
                    Telefone = "99000001116",
                },
            };

      //db.AddRange(produto, cliente);
      db.Set<Cliente>().AddRange(listaClientes);
      //db.Clientes.AddRange(listaClientes);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total Registro(s): {registros}");
    }

    private static void InserirDados(ApplicationContext db)
    {
      var produto = new Produto
      {
        Descricao = "Produto Teste",
        CodigoBarras = "1234567891231",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };
      //db.Produtos.Add(produto);
      //db.Set<Produto>().Add(produto);
      //db.Entry(produto).State = EntityState.Added;
      db.Add(produto);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total Registro(s): {registros}");
    }
  }
}